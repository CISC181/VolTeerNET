using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.BusinessLogicLayer.VT;
using VolTeer.DomainModels.VT;
using Telerik.Web.UI;
using VolTeer.App_Code;

namespace VolTeer.SampleControls
{
    public partial class SampleAddress : System.Web.UI.Page
    {
        sp_Sample_Address_BLL BLL = new sp_Sample_Address_BLL();
        sp_State_BLL stBLL = new sp_State_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rGridAddress_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            rGridAddress.DataSource = BLL.ListSampleAddress();
        }


        protected void rGridAddress_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem edtItem = (GridEditableItem)e.Item;

                RadDropDownList rDDState = (RadDropDownList)edtItem.FindControl("rDDState");
                rDDState.DataSource = stBLL.ListStates();
                rDDState.DataValueField = "StateAbbr";
                rDDState.DataTextField = "StateName";
                rDDState.DataBind();

                rDDState.SelectedValue = DataBinder.Eval(edtItem.DataItem, "St").ToString();
            }
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
            int iAddrID = 0;
            if (iAction == (int)RecordAction.Update)
            {
                iAddrID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["AddrID"]);
            }
            string AddrLine1 = (eeditedItem.FindControl("rTXTAddrLine1") as RadTextBox).Text.ToString();
            string AddrLine2 = (eeditedItem.FindControl("rTXTAddrLine2") as RadTextBox).Text.ToString();
            string AddrLine3 = (eeditedItem.FindControl("rTXTAddrLine3") as RadTextBox).Text.ToString();
            string City = (eeditedItem.FindControl("rTXTCity") as RadTextBox).Text.ToString();
            RadDropDownList rddSt = (RadDropDownList)eeditedItem.FindControl("rDDState");
            int Zip = Convert.ToInt32((eeditedItem.FindControl("rMTZip") as RadMaskedTextBox).Text);
            string strZip4 = ((eeditedItem.FindControl("rMTZip4") as RadMaskedTextBox).Text).ToString();
            int? Zip4 = 0;
            if (strZip4 == string.Empty)
            {
                Zip4 = null;
            }
            else
            {
                Zip4 = Convert.ToInt32(strZip4.ToString());
            }

            if (iAction == (int)RecordAction.Update)
            {
                CheckBox ActiveFlg = (CheckBox)eeditedItem.FindControl("chkActiveUpd");
                BLL.UpdateSampleAddress(iAddrID, AddrLine1, AddrLine2, AddrLine3, City, rddSt.SelectedValue.ToString(), Zip, Zip4, ActiveFlg.Checked);
            }
            else if (iAction == (int)RecordAction.Insert)
            {
                CheckBox ActiveFlg = (CheckBox)eeditedItem.FindControl("chkActiveIns");
                BLL.InsertSampleAddress(AddrLine1, AddrLine2, AddrLine3, City, rddSt.SelectedValue.ToString(), Zip, Zip4, ActiveFlg.Checked);
            }

        }

        protected void rGridAddress_DeleteCommand(object sender, GridCommandEventArgs e)
        {

            GridEditableItem eeditedItem = e.Item as GridEditableItem;
            int iAddrID = 0;
            iAddrID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["AddrID"]);
            BLL.DeleteSampleAddress(iAddrID);

        }

    }
}