using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.DescribeDB;
using VolTeer.DataAccessLayer.Describe;
using System.Configuration;
using Telerik.Web.UI;
using System.Data.Common;


namespace VolTeer.BusinessLogicLayer.Describe
{
    public class DescribeBLL
    {

        private DescribeDAL DAL = new DescribeDAL();

        public List<TableColumnDM> ListTableColumns()
        {
            return DAL.ListTableColumns();
        }

        public List<CheckConstraintsDM> ListCheckConstraints()
        {
            return DAL.ListCheckConstraints();
        }



    }
}
