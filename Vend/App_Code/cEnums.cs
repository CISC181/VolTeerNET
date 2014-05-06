using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolTeer.App_Code
{
    public enum RecordType
    {
        Volunteer,
        Group,
        Contact,
        VolAddr
    }

    public enum RecordAction
    {
        Select = 0,
        Update = 1,
        Insert = 2, 
        Delete = 3
    }

    public enum PageViewType
    {
        PrimaryEdit = 1,
        MultiEdit = 2
    }

    public class Methods
    {
        public static int ToInt32(String value)
        {
            if (String.IsNullOrEmpty(value))
                return 0;
            return Int32.Parse(value);
        }
    }

}