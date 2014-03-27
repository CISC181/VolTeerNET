using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.BusinessLogicLayer.VT.Other;
using VolTeer.DomainModels.VT.Other;
using Telerik.Web.UI;
using VolTeer.App_Code;
using System.Data.SqlClient;

namespace VolTeer.SampleControls
{
    public partial class SampleAddressContext : System.Web.UI.Page
    {
        sp_Sample_Address_BLL BLL = new sp_Sample_Address_BLL();
        sp_State_BLL stBLL = new sp_State_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// rGridAddress_NeedDataSource - Executed if the grid senses it needs a datasource.  No binding is necessary.. Telerik takes control of binding.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridAddress_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rGridAddress.DataSource = BLL.ListSampleAddress();
            }
            catch (SqlException sex)
            {
                //TODO: Implement error page to display SQL Exception errors
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// rGridAddress_ItemDataBound - Executed for each and every row painted on the grid, no matter what state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// rGridAddress_UpdateCommand - Is executed if the 'Update' command is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridAddress_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            rGridAdress_UpdIns(sender, e, (int)RecordAction.Update);
        }

        /// <summary>
        /// rGridAddress_InsertCommand - Is executed if the 'Insert' command is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridAddress_InsertCommand(object sender, GridCommandEventArgs e)
        {
            rGridAdress_UpdIns(sender, e, (int)RecordAction.Insert);
        }

        /// <summary>
        /// rGridAdress_UpdIns - Call this shared method if insert or update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="iAction"></param>
        protected void rGridAdress_UpdIns(object sender, GridCommandEventArgs e, int iAction)
        {
            GridEditableItem eeditedItem = e.Item as GridEditableItem;
            sp_Sample_Address_Select_DM cSampleAddress = new sp_Sample_Address_Select_DM();

            if (iAction == (int)RecordAction.Update)
            {
                cSampleAddress.AddrID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["AddrID"]);
            }
            else if (iAction == (int)RecordAction.Insert)
            {
                cSampleAddress.AddrID = 0;
            }

            cSampleAddress.AddrLine1 = (eeditedItem.FindControl("rTXTAddrLine1") as RadTextBox).Text.ToString();
            cSampleAddress.AddrLine2 = (eeditedItem.FindControl("rTXTAddrLine2") as RadTextBox).Text.ToString();
            cSampleAddress.AddrLine3 = (eeditedItem.FindControl("rTXTAddrLine3") as RadTextBox).Text.ToString();
            cSampleAddress.City = (eeditedItem.FindControl("rTXTCity") as RadTextBox).Text.ToString();
            RadDropDownList rddSt = (RadDropDownList)eeditedItem.FindControl("rDDState");
            cSampleAddress.St = rddSt.SelectedValue.ToString();
            cSampleAddress.Zip = Convert.ToInt32((eeditedItem.FindControl("rMTZip") as RadMaskedTextBox).Text);
            string strZip4 = ((eeditedItem.FindControl("rMTZip4") as RadMaskedTextBox).Text).ToString();
            if (strZip4 == string.Empty)
            {
                cSampleAddress.Zip4 = null;
            }
            else
            {
                cSampleAddress.Zip4 = Convert.ToInt32(strZip4.ToString());
            }

            if (iAction == (int)RecordAction.Update)
            {
                cSampleAddress.ActiveFlg = (eeditedItem.FindControl("chkActiveUpd") as CheckBox).Checked;
                try
                {
                    BLL.UpdateSampleAddressContext(cSampleAddress);
                }
                catch (SqlException sex)
                {
                    //TODO: Implement error page to display SQL Exception errors
                }
                catch (Exception ex)
                {
                    //TODO: Implement error page to display SQL Exception errors
                }
            }
            else if (iAction == (int)RecordAction.Insert)
            {
                cSampleAddress.ActiveFlg = (eeditedItem.FindControl("chkActiveIns") as CheckBox).Checked;

                try
                {
                    BLL.InsertSampleAddressContext(cSampleAddress);
                }
                catch (SqlException sex)
                {
                    //TODO: Implement error page to display SQL Exception errors
                }
                catch (Exception ex)
                {
                    //TODO: Implement error page to display SQL Exception errors
                }

            }
        }

        /// <summary>
        /// rGridAddress_DeleteCommand - Is executed if the 'Delete' command is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridAddress_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eeditedItem = e.Item as GridEditableItem;
            sp_Sample_Address_Select_DM cSampleAddress = new sp_Sample_Address_Select_DM();
            cSampleAddress.AddrID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["AddrID"]);
            BLL.DeleteSampleAddressContext(cSampleAddress);
        }

    }
}