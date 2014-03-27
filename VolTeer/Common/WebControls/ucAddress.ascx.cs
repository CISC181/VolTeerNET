using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.App_Code;
using VolTeer.BusinessLogicLayer.VT.Vol;

namespace VolTeer.Common.WebControls
{
    public partial class ucAddress : System.Web.UI.UserControl
    {
        // Pass in the AddrOwner (VolID, GroupID, etc) and the RecordType (what kind of record it is)
        public int iAddrOwner;
        public Guid gAddrOwner;
        public int iRecordTypeID;
        //private sp_Address_BLL BLL = new sp_Address_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            // Set the data source and bind the grid
            //rGridAddress.DataSource = BLL.ListAddress(iAddrOwner, gAddrOwner, iRecordTypeID);
            rGridAddress.DataBind();

            //TODO: Tailor any messages based on iRecordTypeID
            switch (iRecordTypeID)
            {
                case (int)RecordType.Volunteer:
                    {
                    }

                    break;
                case (int)RecordType.Group:
                    {
                    }

                    break;
                case (int)RecordType.Contact:
                    {
                    }
                    break;
            }

        }


    }
}