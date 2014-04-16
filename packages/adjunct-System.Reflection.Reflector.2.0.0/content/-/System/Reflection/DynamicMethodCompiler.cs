#if !CompactFramework
using System.Reflection.Emit;

#endif

namespace System.Reflection
{
	/// <summary>
	/// creates delegate
	/// </summary>
	/// <returns>delegate</returns>
	internal delegate object DefaultCreatorDelegate();

	/// <summary>
	/// gets delegate
	/// </summary>
	/// <param name="obj"></param>
	/// <returns>delegate</returns>
	internal delegate object GetterDelegate(object obj);

	/// <summary>
	/// sets delegate
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="newValue"></param>
	internal delegate void SetterDelegate(object obj, object newValue);

	/// <summary>
	/// This class defines Dynamic method compiler functions
	/// </summary>
	internal static class DynamicMethodCompiler
	{
		/// <summary>
		/// Creates the default constructor delegate.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>a <see cref="DefaultCreatorDelegate"/></returns>
		/// <exception cref="Exception"><c>Exception</c>.</exception>
		public static DefaultCreatorDelegate CreateDefaultConstructorDelegate(Type type)
		{
			ConstructorInfo constructorInfo = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
			                                                      null,
			                                                      new Type[0],
			                                                      null);
			if (constructorInfo == null)
			{
				throw new Exception(
					string.Format(
						"The type {0} must declare an empty constructor (the constructor may be private, internal, protected, protected internal, or public).",
						type));
			}

#if !CompactFramework
			DynamicMethod dynamicMethod = new DynamicMethod("InstantiateObject",
			                                                MethodAttributes.Static | MethodAttributes.Public,
			                                                CallingConventions.Standard,
			                                                typeof(object),
			                                                null,
			                                                type,
			                                                true);
			ILGenerator generator = dynamicMethod.GetILGenerator();
			generator.Emit(OpCodes.Newobj, constructorInfo);
			generator.Emit(OpCodes.Ret);
			return (DefaultCreatorDelegate)dynamicMethod.CreateDelegate(typeof(DefaultCreatorDelegate));
#else
			return () => constructorInfo.Invoke(null);
#endif
		}

		/// <summary>
		/// Creates the getter delegate.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="propertyInfo">The property info.</param>
		/// <returns>a <see cref="GetterDelegate"/></returns>
		public static GetterDelegate CreateGetterDelegate(Type type, PropertyInfo propertyInfo)
		{
			MethodInfo getMethodInfo = propertyInfo.GetGetMethod(true);
#if !CompactFramework
			DynamicMethod dynamicGet = CreateDynamicGetMethod(type);
			ILGenerator getGenerator = dynamicGet.GetILGenerator();

			getGenerator.Emit(OpCodes.Ldarg_0);
			getGenerator.Emit(OpCodes.Call, getMethodInfo);
			BoxIfNeeded(getMethodInfo.ReturnType, getGenerator);
			getGenerator.Emit(OpCodes.Ret);

			return (GetterDelegate)dynamicGet.CreateDelegate(typeof(GetterDelegate));
#else
			return (obj) => getMethodInfo.Invoke(obj, null);
#endif
		}

		/// <summary>
		/// Creates the getter delegate.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="fieldInfo">The field info.</param>
		/// <returns>a <see cref="GetterDelegate"/></returns>
		public static GetterDelegate CreateGetterDelegate(Type type, FieldInfo fieldInfo)
		{
#if !CompactFramework
			DynamicMethod dynamicGet = CreateDynamicGetMethod(type);
			ILGenerator getGenerator = dynamicGet.GetILGenerator();

			getGenerator.Emit(OpCodes.Ldarg_0);
			getGenerator.Emit(OpCodes.Ldfld, fieldInfo);
			BoxIfNeeded(fieldInfo.FieldType, getGenerator);
			getGenerator.Emit(OpCodes.Ret);

			return (GetterDelegate)dynamicGet.CreateDelegate(typeof(GetterDelegate));
#else
			return (obj) => fieldInfo.GetValue(obj);
#endif
		}

		/// <summary>
		/// Creates the setter delegate.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="propertyInfo">The property info.</param>
		/// <returns>a <see cref="SetterDelegate"/></returns>
		public static SetterDelegate CreateSetterDelegate(Type type, PropertyInfo propertyInfo)
		{
			MethodInfo setMethodInfo = propertyInfo.GetSetMethod(true);
#if !CompactFramework
			DynamicMethod dynamicSet = CreateDynamicSetMethod(type);
			ILGenerator setGenerator = dynamicSet.GetILGenerator();

			setGenerator.Emit(OpCodes.Ldarg_0);
			setGenerator.Emit(OpCodes.Ldarg_1);
			UnboxIfNeeded(setMethodInfo.GetParameters()[0].ParameterType, setGenerator);
			setGenerator.Emit(OpCodes.Call, setMethodInfo);
			setGenerator.Emit(OpCodes.Ret);

			return (SetterDelegate)dynamicSet.CreateDelegate(typeof(SetterDelegate));
#else
			return (obj, newValue) => setMethodInfo.Invoke(obj, new[] { newValue });
#endif
		}

		/// <summary>
		/// Creates the setter delegate.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="fieldInfo">The field info.</param>
		/// <returns>a <see cref="SetterDelegate"/></returns>
		public static SetterDelegate CreateSetterDelegate(Type type, FieldInfo fieldInfo)
		{
#if !CompactFramework
			DynamicMethod dynamicSet = CreateDynamicSetMethod(type);
			ILGenerator setGenerator = dynamicSet.GetILGenerator();

			setGenerator.Emit(OpCodes.Ldarg_0);
			setGenerator.Emit(OpCodes.Ldarg_1);
			UnboxIfNeeded(fieldInfo.FieldType, setGenerator);
			setGenerator.Emit(OpCodes.Stfld, fieldInfo);
			setGenerator.Emit(OpCodes.Ret);

			return (SetterDelegate)dynamicSet.CreateDelegate(typeof(SetterDelegate));
#else
			return (obj, newValue) => fieldInfo.SetValue(obj, newValue);
#endif
		}

#if !CompactFramework
		/// <summary>
		/// Creates the dynamic get method.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>a <see cref="DynamicMethod"/></returns>
		private static DynamicMethod CreateDynamicGetMethod(Type type)
		{
			return new DynamicMethod("DynamicGet", typeof(object), new[] {typeof(object)}, type, true);
		}

		/// <summary>
		/// Creates the dynamic set method.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>a <see cref="DynamicMethod"/></returns>
		private static DynamicMethod CreateDynamicSetMethod(Type type)
		{
			return new DynamicMethod("DynamicSet", typeof(void), new[] {typeof(object), typeof(object)}, type, true);
		}

		/// <summary>
		/// Boxes if needed.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="generator">The generator.</param>
		private static void BoxIfNeeded(Type type, ILGenerator generator)
		{
			if (type.IsValueType)
			{
				generator.Emit(OpCodes.Box, type);
			}
		}

		/// <summary>
		/// Unboxes if needed.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="generator">The generator.</param>
		private static void UnboxIfNeeded(Type type, ILGenerator generator)
		{
			if (type.IsValueType)
			{
				generator.Emit(OpCodes.Unbox_Any, type);
			}
		}
#endif
	}
}