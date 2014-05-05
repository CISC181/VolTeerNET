using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolTeer.App_Code
{
    public static class cCommonFunctions
    {
        /// <summary>
        /// If the object that's passed is null, or is an invalid reference, return a string.empty
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string HandleDBNull(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            else
            {
                return Convert.ToString(obj);
            }
        }

        /// <summary>
        /// If the object that's passed is a string.empty, return a null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SetNullIfEmpty(object obj)
        {
            if (Convert.ToString(obj) == string.Empty)
            {
                return null;
            }
            else
            {
                return Convert.ToString(obj).Trim();
            }
        }

    }
}