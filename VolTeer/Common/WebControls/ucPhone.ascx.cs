using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VolTeer.App_Code;
using VolTeer.BusinessLogicLayer.VT.Other;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.Cache.VT.Vol;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.Common.WebControls
{
    public partial class ucPhone : System.Web.UI.UserControl
    {

        // Event handler to call method on the main page.
        public event EventHandler ShowErrorOccurs;

        // Pass in the PhoneOwner (VolID, GroupID, etc) and the RecordType (what kind of record it is)
        MembershipUser currentUser;
        public int iRecordTypeID;

        //  Object References
        private sp_VolPhone_BLL VolPhoneBLL = new sp_VolPhone_BLL();
        private sp_VolPhone_Cache VolPhoneCash = new sp_VolPhone_Cache();
        private sp_State_BLL stBLL = new sp_State_BLL();



        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = Membership.GetUser();

            if (!IsPostBack)
            {
                HandleScreenLoad();
            }
        }


        #region Screen Setup
        protected void HandleScreenLoad()
        {


            currentUser = Membership.GetUser();

            //pnlSingleAddress.Visible = false;
            pnlPhoneGrid.Visible = true;
            //sp_Vol_Address_DM VolDM = new sp_Vol_Address_DM();
            sp_Phone_DM VolDM = new sp_Phone_DM();
            VolDM.VolID = (Guid)currentUser.ProviderUserKey;
            //rGridAddress.DataSource = VolAddrBLL.ListAddresses(VolDM);

            rGridPhone.DataSource = VolPhoneCash.ListPhones(VolDM);
            rGridPhone.DataBind();
        }



        #endregion

        #region Native Telerik Methods

        /// <summary>
        /// rGridAddress_ItemDataBound - handle items that have to be addressed at databound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridPhone_ItemDataBound(object sender, GridItemEventArgs e)
        {



            try
            {
                if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    if (e.Item is GridEditFormInsertItem)
                    {
                        GridEditableItem edtItem = (GridEditableItem)e.Item;
                        CheckBox ckActive = (CheckBox)edtItem.FindControl("chkActive");
                        ckActive.Checked = true;
                    }
                    else
                    {

                        GridEditableItem edtItem = (GridEditableItem)e.Item;

                        CheckBox ckActive = (CheckBox)edtItem.FindControl("chkActive");
                        ckActive.Checked = (bool)DataBinder.Eval(edtItem.DataItem, "ActiveFlg");

                        CheckBox chkPrimaryAddr = (CheckBox)edtItem.FindControl("chkPrimaryFlg");
                        chkPrimaryAddr.Checked = (bool)DataBinder.Eval(edtItem.DataItem, "PrimaryFlg");



                        if (chkPrimaryAddr.Checked)
                        {
                            chkPrimaryAddr.Enabled = false;
                            //Make control unclickable
                        }
                    }
                }



                else if (e.Item is GridItem)
                {
                    //  If the Email is the primary Email, don't let the user delete it
                    GridItem Item = (GridItem)e.Item;
                    CheckBox bPrimaryPhone = (CheckBox)Item.FindControl("PrimaryFlg");
                    if (bPrimaryPhone != null)
                    {
                        bPrimaryPhone.Enabled = false;

                        if (bPrimaryPhone.Checked)
                        {
                            GridDataItem ditem = (GridDataItem)e.Item;
                            ImageButton imgBtn = (ImageButton)ditem["Delete"].Controls[0];
                            imgBtn.Visible = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.
            }
        }

        /// <summary>
        /// rGridEmail_NeedDataSource - Called when the grid needs a data source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridPhone_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                sp_Phone_DM VolDM = new sp_Phone_DM();
                VolDM.VolID = (Guid)currentUser.ProviderUserKey;
                //rGridAddress.DataSource = VolAddrBLL.ListAddresses(VolDM);

                rGridPhone.DataSource = VolPhoneCash.ListPhones(VolDM);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.

            }

        }



        #endregion
        

        #region Handle Button clicks
        /// <summary>
        /// btnEdit_Click - Handles 'edit' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var hdEditView = (HiddenField)Parent.FindControl("hdEditView");
                hdEditView.Value = "2";
                HandleScreenLoad();
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.

            }
        }

        /// <summary>
        /// btnCancel_Click - Handles 'cancel' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                var hdEditView = (HiddenField)Parent.FindControl("hdEditView");
                hdEditView.Value = "1";
                HandleScreenLoad();
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.

            }
        }
        #endregion

       

        #region Phone CRUD
        /// <summary>
        /// rGridPhone_UpdateCommand - Handles Update click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridPhone_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            rGridPhone_UpdIns(sender, e, (int)RecordAction.Update);
        }

        /// <summary>
        /// rGridAddress_InsertCommand - Handles insert click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridPhone_InsertCommand(object sender, GridCommandEventArgs e)
        {
            rGridPhone_UpdIns(sender, e, (int)RecordAction.Insert);
        }

        /// <summary>
        /// rGridPhone_UpdIns - Handle update/insert in a common procedure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="iAction"></param>
        protected void rGridPhone_UpdIns(object sender, GridCommandEventArgs e, int iAction)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;

                sp_Phone_DM VolPhoneDM = new sp_Phone_DM();
                VolPhoneDM.VolID = (Guid)currentUser.ProviderUserKey;

                if (iAction == (int)RecordAction.Update)
                {
              
                    VolPhoneDM.PhoneID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["PhoneID"]);
                 }
                VolPhoneDM.ActiveFlg = (eeditedItem.FindControl("chkActive") as CheckBox).Checked;
                VolPhoneDM.PrimaryFlg = (eeditedItem.FindControl("chkPrimaryFlg") as CheckBox).Checked;
                VolPhoneDM.PhoneNbr = (eeditedItem.FindControl("rTBPhone") as RadTextBox).Text.ToString();
               // VolPhoneDM.AddrLine2 = (eeditedItem.FindControl("rTBPhone2") as RadTextBox).Text.ToString();
              //  VolPhoneDM.AddrLine3 = (eeditedItem.FindControl("rTBPhone3") as RadTextBox).Text.ToString();

                if (iAction == (int)RecordAction.Update)
                {
                    VolPhoneBLL.UpdatePhoneNbr(VolPhoneDM);
                   // VolAddrBLL.UpdateAddressContext(VolAddressDM, VolAddrDM);

                }
                else if (iAction == (int)RecordAction.Insert)
                {
                    VolPhoneBLL.InsertPhoneContext(VolPhoneDM);
                   // VolPhoneBLL.InsertAddressContext(ref VolPhoneDM, ref VolPhoDM);
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.
            }


            try
            {
                HandleScreenLoad();
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.
            }
        }

        /// <summary>
        /// rGridAddress_DeleteCommand - Handle the delete command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridPhone_DeleteCommand(object sender, GridCommandEventArgs e)
        {


            sp_Phone_DM VolPhoneDM = new sp_Phone_DM();

            try
            {
                VolPhoneDM.VolID = (Guid)currentUser.ProviderUserKey;
                VolPhoneDM.PhoneID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PhoneID"];

                VolPhoneBLL.DeletePhonesContext(VolPhoneDM);
                // VolPhoneBLL.DeleteAddressContext(VolPhoneDM, VolPhoDM);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.

            }
        }
        #endregion

       


        /// <summary>
        /// DisplayError - Pass the exception to the main page.
        /// </summary>
        /// <param name="ex"></param>
        public void DisplayError(Exception ex)
        {
            if (ex != null)
            {
                ShowErrorOccurs(ex, null);
            }

        }
    }
}