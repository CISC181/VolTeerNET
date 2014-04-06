using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VolTeer.App_Code;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Other;


using VolTeer.DomainModels.Service;
using VolTeer.GoogleAPI;


namespace VolTeer.Common.WebControls
{
    public partial class ucAddress : System.Web.UI.UserControl
    {














        // Pass in the AddrOwner (VolID, GroupID, etc) and the RecordType (what kind of record it is)
        private Guid gAddrOwner;
        public int iRecordTypeID;

        //  Object References
        private sp_Vol_Address_BLL VolAddrBLL = new sp_Vol_Address_BLL();
        private sp_State_BLL stBLL = new sp_State_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            gAddrOwner = new Guid(((HiddenField)Parent.FindControl("hdVolID")).Value);

            if (!IsPostBack)
            {
                HandleScreenLoad();
            }
        }


        protected void HandleScreenLoad()
        {
            var hdEditView = (HiddenField)Parent.FindControl("hdEditView");
            gAddrOwner = new Guid(((HiddenField)Parent.FindControl("hdVolID")).Value);
            if (hdEditView.Value == "1")
            {
                pnlSingleAddress.Visible = true;
                pnlAddressGrid.Visible = false;
                SetPrimaryValues();

            }
            else if (hdEditView.Value == "2")
            {
                pnlSingleAddress.Visible = false;
                pnlAddressGrid.Visible = true;
                sp_Vol_Address_DM VolDM = new sp_Vol_Address_DM();
                VolDM.VolID = gAddrOwner;
                rGridAddress.DataSource = VolAddrBLL.ListAddresses(VolDM);
                rGridAddress.DataBind();
            }
        }


        protected void SetPrimaryValues()
        {

            sp_Vol_Address_DM VolDM = new sp_Vol_Address_DM();
            StringBuilder sb = new StringBuilder();


            VolDM.VolID = gAddrOwner;
            VolDM = VolAddrBLL.ListPrimaryAddress(VolDM);

            lblAddr1.Text = VolDM.AddrLine1;
            lblAddr2.Text = VolDM.AddrLine2;
            if (string.IsNullOrEmpty(lblAddr2.Text))
            {
                rowAddr2.Visible = false;
            }
            else
            {
                rowAddr2.Visible = true;
            }

            lblAddr3.Text = VolDM.AddrLine3;
            if (string.IsNullOrEmpty(lblAddr3.Text))
            {
                rowAddr3.Visible = false;
            }
            else
            {
                rowAddr3.Visible = true;
            }

            sb.Clear();
            sb.Append(VolDM.City.ToString());
            sb.Append(", ");
            sb.Append(VolDM.St.ToString());
            sb.Append("   ");
            sb.Append(VolDM.Zip.ToString());
            if (!string.IsNullOrEmpty(VolDM.Zip4.ToString()))
            {
                sb.Append('-');
                sb.Append(VolDM.Zip4.ToString());
            }

            lblCityStZip.Text = sb.ToString();

        }
        /// <summary>
        /// rGridAddress_ItemDataBound - handle items that have to be addressed at databound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridAddress_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem edtItem = (GridEditableItem)e.Item;

                RadDropDownList rDDSt = (RadDropDownList)edtItem.FindControl("rDDSt");
                rDDSt.DataSource = stBLL.ListStates();
                rDDSt.DataValueField = "StateAbbr";
                rDDSt.DataTextField = "StateName";
                rDDSt.DataBind();

                rDDSt.SelectedValue = DataBinder.Eval(edtItem.DataItem, "St").ToString();
            }
        }

        protected void rGridAddress_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            try
            {
                sp_Vol_Address_DM VolDM = new sp_Vol_Address_DM();
                VolDM.VolID = gAddrOwner;
                rGridAddress.DataSource = VolAddrBLL.ListAddresses(VolDM);
            }
            catch (Exception ex)
            {
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var hdEditView = (HiddenField)Parent.FindControl("hdEditView");
            hdEditView.Value = "2";
            HandleScreenLoad();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var hdEditView = (HiddenField)Parent.FindControl("hdEditView");
            hdEditView.Value = "1";
            HandleScreenLoad();
        }


        protected void rGridAddress_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            rGridAdress_UpdIns(sender, e, (int)RecordAction.Update);
        }

        protected void rGridAddress_InsertCommand(object sender, GridCommandEventArgs e)
        {
            rGridAdress_UpdIns(sender, e, (int)RecordAction.Insert);
        }

        protected void rGridAdress_UpdIns(object sender, GridCommandEventArgs e, int iAction)
        {
            GridEditableItem eeditedItem = e.Item as GridEditableItem;

            sp_Vol_Address_DM VolAddressDM = new sp_Vol_Address_DM();
            sp_Vol_Addr_DM VolAddrDM = new sp_Vol_Addr_DM();

            VolAddrDM.VolID = gAddrOwner;

            VolAddressDM.VolID = gAddrOwner;
            VolAddressDM.AddrID = 0;
            if (iAction == (int)RecordAction.Update)
            {
                VolAddressDM.AddrID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["AddrID"]);
            }
            VolAddressDM.ActiveFlg = (eeditedItem.FindControl("chkActive") as CheckBox).Checked;
            VolAddressDM.AddrLine1 = (eeditedItem.FindControl("rTBAddr1") as RadTextBox).Text.ToString();
            VolAddressDM.AddrLine2 = (eeditedItem.FindControl("rTBAddr2") as RadTextBox).Text.ToString();
            VolAddressDM.AddrLine3 = (eeditedItem.FindControl("rTBAddr3") as RadTextBox).Text.ToString();
            VolAddressDM.City = (eeditedItem.FindControl("rTBCity") as RadTextBox).Text.ToString();
            VolAddressDM.St = (eeditedItem.FindControl("rDDSt") as RadDropDownList).SelectedValue.ToString();
            VolAddressDM.Zip = Convert.ToInt32((eeditedItem.FindControl("rNTBZip") as RadNumericTextBox).Text);
            string strZip4 = ((eeditedItem.FindControl("rNTBZip4") as RadNumericTextBox).Text).ToString();
            if (strZip4 == string.Empty)
            {
                VolAddressDM.Zip4 = null;
            }
            else
            {
                VolAddressDM.Zip4 = Convert.ToInt32(strZip4.ToString());
            }

            if (iAction == (int)RecordAction.Update)
            {
                VolAddrBLL.UpdateAddressContext(VolAddressDM, VolAddrDM);

            }
            else if (iAction == (int)RecordAction.Insert)
            {
                VolAddrBLL.InsertAddressContext(ref VolAddressDM, ref VolAddrDM);
            }

            var hdEditView = (HiddenField)Parent.FindControl("hdEditView");
            hdEditView.Value = "1";
            HandleScreenLoad();
        }

        protected string GetGeoCode(sp_Vol_Address_DM VolAddr)
        {
            GoogleAddress GC = new GoogleAddress();
            GoogleGeocoder GCoder = new GoogleGeocoder(true);


            return string.Empty;

        }

        protected void rGridAddress_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            sp_Vol_Address_DM VolAddressDM = new sp_Vol_Address_DM();
            sp_Vol_Addr_DM VolAddrDM = new sp_Vol_Addr_DM();

            VolAddressDM.VolID = gAddrOwner;
            VolAddressDM.AddrID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AddrID"];

            VolAddrDM.VolID = gAddrOwner;
            VolAddrDM.AddrID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AddrID"];

            VolAddrBLL.DeleteAddressContext(VolAddressDM, VolAddrDM);
        }

    }

}