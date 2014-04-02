using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.DescribeDB
{
    public class TableColumnDM
    {
        public string table_catalog { get; set; }
        public string table_schema { get; set; }
        public string table_name { get; set; }
        public string column_name { get; set; }
        public Nullable<int> ordinal_position { get; set; }
        public string Column_Default { get; set; }
        public string is_nullable { get; set; }
        public string Data_type { get; set; }
        public Nullable<int> character_maximum_length { get; set; }
        public Nullable<byte> numeric_precision { get; set; }
        public Nullable<int> numeric_scale { get; set; }
        public Nullable<short> datetime_precision { get; set; }
    }
}
