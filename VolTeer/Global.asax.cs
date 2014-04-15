using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
//using System.Web.Security;
//using VolTeer;
//using System.ComponentModel;
//using System.Web.SessionState;
using VolTeer.BusinessLogicLayer.Describe;
using VolTeer.DomainModels.DescribeDB;


namespace VolTeer
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //DescribeBLL BLL = new DescribeBLL();

            //List<TableColumnDM> ListTableColumns = new List<TableColumnDM>();
            //List<CheckConstraintsDM> ListCheckConstraints = new List<CheckConstraintsDM>();

            //ListTableColumns = BLL.ListTableColumns();
            //ListCheckConstraints = BLL.ListCheckConstraints();

            //Application["ListTableColumns"] = ListTableColumns;
            //Application["ListCheckConstraints"] = ListCheckConstraints;


        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }   

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}