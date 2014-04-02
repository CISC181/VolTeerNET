using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using VolTeer.DataAccessLayer.Describe;
using VolTeer.DomainModels.DescribeDB;
using System.Web.SessionState;

namespace VolTeer.Session
{
    public class DescribeSession
    {
        private DescribeDAL Dal = new DescribeDAL();

        public List<TableColumnDM> ListTableColumns()
        {
            return Dal.ListTableColumns();
        }

        public List<CheckConstraintsDM> ListCheckConstraints()
        {
            return Dal.ListCheckConstraints();
        }
    }
}

