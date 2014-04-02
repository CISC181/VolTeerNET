using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.DescribeDB
{
    public class CheckConstraintsDM
    {
        public string Table_Catalog { get; set; }
        public string Table_Schema { get; set; }
        public string table_name { get; set; }
        public string column_name { get; set; }
        public string constraint_catalog { get; set; }
        public string Constraint_name { get; set; }
        public string check_clause { get; set; }
    }
}
