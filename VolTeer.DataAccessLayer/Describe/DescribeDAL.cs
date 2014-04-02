using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.DescribeDB;

namespace VolTeer.DataAccessLayer.Describe
{
    public class DescribeDAL
    {
        public List<TableColumnDM> ListTableColumns()
        {
            List<TableColumnDM> list = new List<TableColumnDM>();
            using (DescribeEntities context = new DescribeEntities())
            {
                list = (from result in context.Describe_TableColumns()
                        select new TableColumnDM
                        {
                            table_catalog = result.table_catalog,
                            table_name = result.table_name,
                            table_schema = result.table_schema,
                            character_maximum_length = result.character_maximum_length,
                            column_name = result.column_name,
                            Column_Default = result.Column_Default,
                            datetime_precision = result.datetime_precision,
                            Data_type = result.Data_type,
                            is_nullable = result.is_nullable,
                            numeric_precision = result.numeric_precision,
                            numeric_scale = result.numeric_scale,
                            ordinal_position = result.ordinal_position,
                            container_name = result.container_name,
                            control_name = result.control_name
                        }).ToList();
            } // Guaranteed to close the Connection

            return list;
        }




        public List<CheckConstraintsDM> ListCheckConstraints()
        {
            List<CheckConstraintsDM> list = new List<CheckConstraintsDM>();
            using (DescribeEntities context = new DescribeEntities())
            {
                list = (from result in context.Describe_CheckConstraints()
                        select new CheckConstraintsDM
                        {
                            Table_Catalog = result.Table_Catalog,
                            Table_Schema = result.Table_Schema,
                            table_name = result.table_name,
                            check_clause = result.check_clause,
                            column_name = result.column_name,
                            constraint_catalog = result.constraint_catalog,
                            Constraint_name = result.Constraint_name
                        }).ToList();
            } // Guaranteed to close the Connection

            return list;
        }


    }
}