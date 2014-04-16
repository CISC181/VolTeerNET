using System.Collections.Generic;
using System.Linq;

namespace System.Reflection
{
	/// <summary>
	/// This is a generic helper class that encapsulates some of the simple 'Reflection' based tasks.
	/// </summary>
	internal static class Reflector
	{
		private static readonly Dictionary<Type, DefaultCreatorDelegate> _defaultConstructors =
			new Dictionary<Type, DefaultCreatorDelegate>();

		private static readonly Dictionary<string, GetterDelegate> _fieldGetters = new Dictionary<string, GetterDelegate>();
		private static readonly Dictionary<string, SetterDelegate> _fieldSetters = new Dictionary<string, SetterDelegate>();
		private static readonly Dictionary<string, GetterDelegate> _propertyGetters = new Dictionary<string, GetterDelegate>();
		private static readonly Dictionary<string, SetterDelegate> _propertySetters = new Dictionary<string, SetterDelegate>();
		private static readonly Dictionary<string, Type> _types = new Dictionary<string, Type>();

		private const BindingFlags InstanceBindingFlags =
			BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase;

		private const BindingFlags StaticBindingFlags =
			BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase;

		/// <summary>
		/// Clones the specified object.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <returns>A cloned object</returns>
		/// <exception cref="Exception"><c>Exception</c>.</exception>
		public static object Clone(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			MethodInfo cloneMethod = obj.GetType().GetMethod("MemberwiseClone", InstanceBindingFlags);
			if (cloneMethod == null)
			{
				string message = string.Format("MemberwiseClone() is not supported on {0}.", obj.GetType());
				throw new Exception(message);
			}
			object clone = cloneMethod.Invoke(obj, new object[] {});
			return clone;
		}

		///// <summary>
		///// Compares two assembly assembly name strings.
		///// </summary>
		///// <param name="typeName1"></param>
		///// <param name="typeName2"></param>
		///// <returns></returns>
		//public static bool CompareAssemblyQualifiedTypeNames(string typeName1, string typeName2)
		//{
		//    int pos = -1;

		//    if (typeName1.IndexOf(",") == -1)
		//    {
		//        if ((pos = typeName2.IndexOf(",")) > -1)
		//        {
		//            typeName2 = typeName2.Substring(0, pos);
		//        }
		//    }
		//    else if (typeName2.IndexOf(",") == -1)
		//    {
		//        if ((pos = typeName1.IndexOf(",")) > -1)
		//        {
		//            typeName1 = typeName1.Substring(0, pos);
		//        }
		//    }

		//    return typeName1.Replace(" ", "") == typeName2.Replace(" ", "");
		//}

		/// <summary>
		/// Constructs the default instance.
		/// </summary>
		/// <param name="typeNamespace">The type namespace.</param>
		/// <param name="typeName">Name of the type.</param>
		/// <returns>An object of type name</returns>
		public static object ConstructDefault(string typeNamespace, string typeName)
		{
			return ConstructDefault(GetObjectType(typeNamespace, typeName));
		}

		/// <summary>
		/// Constructs the default instance.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>An object of specified type</returns>
		public static object ConstructDefault(Type type)
		{
			if (_defaultConstructors.ContainsKey(type))
			{
				return _defaultConstructors[type]();
			}

			DefaultCreatorDelegate creatorDelegate = DynamicMethodCompiler.CreateDefaultConstructorDelegate(type);
			_defaultConstructors.Add(type, creatorDelegate);
			return creatorDelegate();
		}

		/// <summary>
		/// Gets assembly qualified name of the type in format: {type name}, {assembly name}.
		/// </summary>
		/// <param name="type"></param>
		/// <returns>An object of specified type</returns>
		public static string GetAssemblyQualifiedTypeName(Type type)
		{
			return string.Format("{0}, {1}", type.FullName, type.Assembly.GetName().Name);
		}

		/// <summary>
		/// Gets the attributes of the specified type on the Type Definition of the supplied object.
		/// </summary>
		/// <param name="obj">Obj.</param>
		/// <param name="attributeType">Attribute type.</param>
		/// <returns>An object of specified attribute type</returns>
		public static object GetAttribute(object obj, Type attributeType)
		{
			object[] all = GetAttributes(obj, attributeType);
			return (all.Length > 0) ? all[0] : null;
		}

		/// <summary>
		/// Gets the attributes of the specified type on the Type Definition of the supplied object.
		/// </summary>
		/// <typeparam name="TAttributeType">The type of the attribute.</typeparam>
		/// <param name="obj">The obj.</param>
		/// <returns>An attribute of specified type of object</returns>
		public static TAttributeType GetAttribute<TAttributeType>(object obj) where TAttributeType : Attribute
		{
			object[] all = GetAttributes(obj, typeof(TAttributeType));
			return (all.Length > 0) ? (TAttributeType)all[0] : null;
		}

		/// <summary>
		/// Gets the attributes of the specified type on the Type Definition of the supplied object.
		/// </summary>
		/// <param name="obj">Obj.</param>
		/// <param name="attributeType">Attribute type.</param>
		/// <returns>An array of objects of specified attribute type</returns>
		public static object[] GetAttributes(object obj, Type attributeType)
		{
			return obj.GetType().GetCustomAttributes(attributeType, false);
		}

		/// <summary>
		/// Gets the attributes of the specified type on the Type Definition of the supplied object.
		/// </summary>
		/// <typeparam name="TAttributeType">The type of the attribute.</typeparam>
		/// <param name="obj">The object to inspect.</param>
		/// <returns>An array of attributes of object</returns>
		public static TAttributeType[] GetAttributes<TAttributeType>(object obj) where TAttributeType : Attribute
		{
			return GetAttributes(obj, typeof(TAttributeType)).Select(value => (TAttributeType)value).ToArray();
		}

		/// <summary>
		/// Gets the attributes.
		/// </summary>
		/// <param name="member">The member.</param>
		/// <param name="attributeType">Attribute type.</param>
		/// <returns>An array of objects of the specified type of attribute.</returns>
		public static object[] GetAttributes(MemberInfo member, Type attributeType)
		{
			return member.GetCustomAttributes(attributeType, false);
		}

		/// <summary>
		/// Gets the attributes.
		/// </summary>
		/// <typeparam name="TAttributeType">The type of the attribute type.</typeparam>
		/// <param name="member">The member.</param>
		/// <returns>An array of attributes of the specified member</returns>
		public static TAttributeType[] GetAttributes<TAttributeType>(MemberInfo member) where TAttributeType : Attribute
		{
			return GetAttributes(member, typeof(TAttributeType)).Select(value => (TAttributeType)value).ToArray();
		}

#if !CompactFramework
		/// <summary>
		/// Gets the attributes of member.
		/// </summary>
		/// <typeparam name="TAttributeType">The type of the attribute type.</typeparam>
		/// <param name="obj">The obj.</param>
		/// <param name="memberName">Name of the member.</param>
		/// <returns>An array of attributes of the specified object</returns>
		/// <exception cref="Exception"><c>Exception</c>.</exception>
		public static TAttributeType[] GetAttributesOfMember<TAttributeType>(object obj, string memberName)
			where TAttributeType : Attribute
		{
			Type objType = (obj is Type) ? (Type)obj : obj.GetType();
			MemberInfo[] members = objType.FindMembers(MemberTypes.All,
			                                           InstanceBindingFlags,
			                                           (memberInfo, searchName) =>
			                                           string.Equals(memberInfo.Name,
			                                                         (string)searchName,
			                                                         StringComparison.OrdinalIgnoreCase),
			                                           memberName);

			if ((members == null) || (members.Length == 0))
			{
				throwMissingMemberException(objType, memberName);
			}
			if (members.Length > 1)
			{
				throw new Exception("Multiple '" + memberName + "' members were found when looking for only one.");
			}
			return GetAttributes<TAttributeType>(members[0]);
		}
#endif

		/// <summary>
		/// Gets the field value.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>An object with the specified field name</returns>
		public static object GetFieldValue(object obj, string fieldName)
		{
			Type type = obj.GetType();
			string key = string.Format("{0}.{1}", type, fieldName);
			if (!_fieldGetters.ContainsKey(key))
			{
				BuildDynamicFieldAccessors(type, fieldName);
			}
			return _fieldGetters[key](obj);
		}

		/// <summary>
		/// Gets the method.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="methodName">Name of the method.</param>
		/// <returns><see cref="MethodInfo"/> of the specified object</returns>
		public static MethodInfo GetMethod(object obj, string methodName)
		{
			if (obj is Type)
			{
				return (obj as Type).GetMethod(methodName, StaticBindingFlags);
			}
			return obj.GetType().GetMethod(methodName, InstanceBindingFlags);
		}

		/// <summary>
		/// Gets the method.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="parameterTypes">The parameter types.</param>
		/// <returns><see cref="MethodInfo"/> of the specified object with parameter types</returns>
		public static MethodInfo GetMethod(object obj, string methodName, params Type[] parameterTypes)
		{
			if (obj is Type)
			{
				return (obj as Type).GetMethod(methodName, StaticBindingFlags, null, parameterTypes, null);
			}
			return obj.GetType().GetMethod(methodName, InstanceBindingFlags, null, parameterTypes, null);
		}

		/// <summary>
		/// Gets the type of the object.
		/// </summary>
		/// <param name="typeNamespace">The type <c>namespace</c>.</param>
		/// <param name="typeName">Name of the type.</param>
		/// <returns>the type of specified type name</returns>
		/// <exception cref="Exception"><c>Exception</c>.</exception>
		public static Type GetObjectType(string typeNamespace, string typeName)
		{
			string fullTypeName = string.Format("{0}.{1}", typeNamespace, typeName);
			if (_types.ContainsKey(fullTypeName))
			{
				return _types[fullTypeName];
			}

			string assemblyName = typeNamespace;
			Assembly assembly = null;
			while (assemblyName.Length > 0)
			{
				try
				{
					assembly = Assembly.Load(assemblyName);
					break;
				}
				catch
				{
					int lastPeriod = assemblyName.LastIndexOf('.');
					assemblyName = (lastPeriod > 0) ? assemblyName.Substring(0, lastPeriod) : string.Empty;
				}
			}
			if (assembly == null)
			{
				throw new Exception("Could not load an assembly for '" + typeNamespace + "'.");
			}
#if CompactFramework || SILVERLIGHT
			Type type = assembly.GetType(typeNamespace + "." + typeName, true);
#else
			Type type = assembly.GetType(typeNamespace + "." + typeName, true, true);
#endif
			_types[fullTypeName] = type;
			return type;
		}

		/// <summary>
		/// Gets the properties by attribute.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="attributeType">Type of the attribute.</param>
		/// <returns><see cref="PropertyInfo"/> of the specified object</returns>
		public static PropertyInfo[] GetPropertiesByAttribute(object obj, Type attributeType)
		{
			Type objType = (obj is Type) ? (Type)obj : obj.GetType();
			PropertyInfo[] allProperties = objType.GetProperties(InstanceBindingFlags);
			return allProperties.Where(property => property.IsDefined(attributeType, true)).ToArray();
		}

		/// <summary>
		/// Gets the property.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns><see cref="PropertyInfo"/> of the specified object with property name</returns>
		public static PropertyInfo GetProperty(object obj, string propertyName)
		{
			Type objType = (obj is Type) ? (Type)obj : obj.GetType();
			return objType.GetProperty(propertyName, InstanceBindingFlags);
		}

		/// <summary>
		/// Gets the type of the property.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>The type of the specified object.</returns>
		public static Type GetPropertyType(object obj, string propertyName)
		{
			return GetProperty(obj, propertyName).PropertyType;
		}

		/// <summary>
		/// Gets the property value.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>An object with specified property name</returns>
		/// <exception cref="MissingMemberException"><c>MissingMemberException</c>.</exception>
		public static object GetPropertyValue(object obj, string propertyName)
		{
			Type type = obj.GetType();
			string key = BuildMemberKey(type, propertyName);
			if (!_propertyGetters.ContainsKey(key))
			{
				BuildDynamicPropertyAccessors(type, propertyName);
			}
			GetterDelegate getSpecificPropertyValue = _propertyGetters[key];
			if (getSpecificPropertyValue == null)
			{
				throw new MissingMemberException("Missing Getter on '" + key + "'");
			}
			return getSpecificPropertyValue(obj);
		}

		/// <summary>
		/// Determines whether the specified object has the requested attribute.
		/// </summary>
		/// <param name="obj">Obj.</param>
		/// <param name="attributeType">Attribute type.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object has attribute; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasAttribute(object obj, Type attributeType)
		{
			return obj.GetType().GetCustomAttributes(attributeType, true).Length > 0;
		}

		/// <summary>
		/// Determines whether the specified object has the requested attribute.
		/// </summary>
		/// <typeparam name="TAttributeType">The type of the attribute.</typeparam>
		/// <param name="obj">The obj.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object has attribute; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasAttribute<TAttributeType>(object obj) where TAttributeType : Attribute
		{
			return HasAttribute(obj, typeof(TAttributeType));
		}

		/// <summary>
		/// Determines whether the specified member has the requested attribute.
		/// </summary>
		/// <param name="member">The member.</param>
		/// <param name="attributeType">Attribute type.</param>
		/// <returns>
		/// 	<c>true</c> if the specified member has attribute; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasAttribute(MemberInfo member, Type attributeType)
		{
			return member.GetCustomAttributes(attributeType, true).Length > 0;
		}

		/// <summary>
		/// Determines whether the specified member has the requested attribute.
		/// </summary>
		/// <typeparam name="TAttributeType">The type of the attribute type.</typeparam>
		/// <param name="member">The member.</param>
		/// <returns>
		/// 	<c>true</c> if the specified member has attribute; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasAttribute<TAttributeType>(MemberInfo member) where TAttributeType : Attribute
		{
			return HasAttribute(member, typeof(TAttributeType));
		}

		/// <summary>
		/// Invokes the method.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="method">The method.</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns>An object with specified method info</returns>
		public static object InvokeMethod(object obj, MethodInfo method, params object[] parameters)
		{
			return method.Invoke(obj, parameters);
		}

		/// <summary>
		/// Invokes the method.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns>An object with specified method name</returns>
		public static object InvokeMethod(object obj, string methodName, params object[] parameters)
		{
			Type[] parameterTypes;
			if (parameters == null)
			{
				parameterTypes = new Type[0];
			}
			else
			{
				parameterTypes = new Type[parameters.Length];
				for (int i = 0; i < parameterTypes.Length; i++)
				{
					parameterTypes[i] = parameters[i].GetType();
				}
			}
			MethodInfo method = GetMethod(obj, methodName, parameterTypes);
			return InvokeMethod(obj, method, parameters);
		}

		/// <summary>
		/// Invokes the method if exists.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns>An object if specified method name exists</returns>
		public static object InvokeMethodIfExists(object obj, string methodName, params object[] parameters)
		{
			MethodInfo method = GetMethod(obj, methodName);
			if (method != null)
			{
				return InvokeMethod(obj, method, parameters);
			}
			return null;
		}

		/// <summary>
		/// Sets the field value.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <param name="newValue">The new value.</param>
		public static void SetFieldValue(object obj, string fieldName, object newValue)
		{
			Type type = obj.GetType();
			string key = string.Format("{0}.{1}", type, fieldName);
			if (!_fieldSetters.ContainsKey(key))
			{
				BuildDynamicFieldAccessors(type, fieldName);
			}
			_fieldSetters[key](obj, newValue);
		}

		/// <summary>
		/// Sets the property value.
		/// </summary>
		/// <param name="obj">Obj.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="newValue">The new value.</param>
		/// <exception cref="MissingMemberException"><c>MissingMemberException</c>.</exception>
		public static void SetPropertyValue(object obj, string propertyName, object newValue)
		{
			Type type = obj.GetType();
			string key = BuildMemberKey(type, propertyName);
			if (!_propertySetters.ContainsKey(key))
			{
				BuildDynamicPropertyAccessors(type, propertyName);
			}
			SetterDelegate setSpecificPropertyValue = _propertySetters[key];
			if (setSpecificPropertyValue == null)
			{
				throw new MissingMemberException("Missing Setter on '" + key + "'");
			}
			setSpecificPropertyValue(obj, newValue);
		}

		/// <summary>
		/// Builds the dynamic field accessors.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="fieldName">Name of the field.</param>
		private static void BuildDynamicFieldAccessors(Type type, string fieldName)
		{
			string key = BuildMemberKey(type, fieldName);
			FieldInfo fieldInfo = type.GetField(fieldName, InstanceBindingFlags);
			if (fieldInfo == null)
			{
				throwMissingMemberException(type, fieldName);
			}
			_fieldGetters[key] = DynamicMethodCompiler.CreateGetterDelegate(type, fieldInfo);
			_fieldSetters[key] = DynamicMethodCompiler.CreateSetterDelegate(type, fieldInfo);
		}

		/// <summary>
		/// Builds the dynamic property accessors.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="propertyName">Name of the property.</param>
		private static void BuildDynamicPropertyAccessors(Type type, string propertyName)
		{
			string key = BuildMemberKey(type, propertyName);
			PropertyInfo propertyInfo = type.GetProperty(propertyName, InstanceBindingFlags);
			if (propertyInfo == null)
			{
				throwMissingMemberException(type, propertyName);
			}
			_propertyGetters[key] = (propertyInfo.CanRead) ? DynamicMethodCompiler.CreateGetterDelegate(type, propertyInfo) : null;
			_propertySetters[key] = (propertyInfo.CanWrite) ? DynamicMethodCompiler.CreateSetterDelegate(type, propertyInfo) : null;
		}

		/// <summary>
		/// Builds the member key.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>The string value with specified property name.</returns>
		private static string BuildMemberKey(Type type, string propertyName)
		{
			return string.Format("{0}.{1}", type, propertyName);
		}

		/// <summary>
		/// Throws the missing member exception.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="memberName">Name of the member.</param>
		/// <exception cref="MissingMemberException"><c>MissingMemberException</c>.</exception>
		private static void throwMissingMemberException(Type type, string memberName)
		{
#if CompactFramework || SILVERLIGHT
			string message = string.Format("Member: '{0}' is missing on type: {1}", memberName, type.FullName);
			throw new MissingMemberException(message);
#else
			throw new MissingMemberException(type.FullName, memberName);
#endif
		}
	}
}