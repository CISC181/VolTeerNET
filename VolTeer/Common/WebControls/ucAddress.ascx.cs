using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.App_Code;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.DomainModels.VT.Vol;


namespace VolTeer.Common.WebControls
{
    public partial class ucAddress : System.Web.UI.UserControl
    {
        // Pass in the AddrOwner (VolID, GroupID, etc) and the RecordType (what kind of record it is)
        public Guid gAddrOwner;
        public int iRecordTypeID;
        private sp_Vol_Address_BLL BLL = new sp_Vol_Address_BLL();

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

            switch (iRecordTypeID)
            {
                case (int)RecordType.Volunteer:
                    {
                        //rGridAddress
                        sp_Vol_Address_DM VolDM = new sp_Vol_Address_DM();
                        VolDM.VolID = gAddrOwner;
                        rGridAddress.DataSource = BLL.ListAddresses(VolDM);

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

            rGridAddress.DataBind();
        }


    }
}