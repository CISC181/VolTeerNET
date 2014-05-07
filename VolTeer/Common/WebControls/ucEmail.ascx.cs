using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Telerik.Web.UI;
using VolTeer.App_Code;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Other;
using VolTeer.Cache.VT.Vol;
using VolTeer.GoogleAPI;
using System.Web.ApplicationServices;
using System.Web.Security;

using VolTeer.DomainModels.Service;
using VolTeer.GoogleAPI;
using System.IO;


namespace VolTeer.Common.WebControls
{
    public partial class ucEmail : System.Web.UI.UserControl
    {
        // Event handler to call method on the main page.
        public event EventHandler ShowErrorOccurs;

        // Pass in the AddrOwner (VolID, GroupID, etc) and the RecordType (what kind of record it is)
        MembershipUser currentUser;
        public int iRecordTypeID;

        //  Object References
        //private sp_Vol_Address_BLL VolAddrBLL = new sp_Vol_Address_BLL();
        //private sp_Vol_Address_Cache VolAddrCash = new sp_Vol_Address_Cache();
        
        private sp_VolEmail_BLL VolEmailBLL = new sp_VolEmail_BLL();
        private sp_VolEmail_Cache VolEmailCash = new sp_VolEmail_Cache(); 
        
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
            pnlEmailGrid.Visible = true;
            //sp_Vol_Address_DM VolDM = new sp_Vol_Address_DM();
            sp_Email_DM VolDM = new sp_Email_DM();
            VolDM.VolID = (Guid)currentUser.ProviderUserKey;
            //rGridAddress.DataSource = VolAddrBLL.ListAddresses(VolDM);

            rGridEmail.DataSource = VolEmailCash.ListEmails(VolDM);
            rGridEmail.DataBind();

        }

        
        #endregion

        #region Native Telerik Methods

        /// <summary>
        /// rGridEmail_ItemDataBound - handle items that have to be addressed at databound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridEmail_ItemDataBound(object sender, GridItemEventArgs e)
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

                        //RadDropDownList rDDSt = (RadDropDownList)edtItem.FindControl("rDDSt");
                        //rDDSt.DataSource = stBLL.ListStates();
                        //rDDSt.DataValueField = "StateAbbr";
                        //rDDSt.DataTextField = "StateName";
                        //rDDSt.DataBind();

                        //rDDSt.SelectedValue = DataBinder.Eval(edtItem.DataItem, "St").ToString();

                        CheckBox ckActive = (CheckBox)edtItem.FindControl("chkActive");
                        ckActive.Checked = (bool)DataBinder.Eval(edtItem.DataItem, "ActiveFlg");

                        CheckBox chkPrimaryAddr = (CheckBox)edtItem.FindControl("chkPrimaryFlg");
                        chkPrimaryAddr.Checked = (bool)DataBinder.Eval(edtItem.DataItem, "PrimaryFlg");
                    }
                }



                else if (e.Item is GridItem)
                {
                    //  If the Email is the primary Email, don't let the user delete it
                    GridItem Item = (GridItem)e.Item;
                    CheckBox bPrimaryEmail = (CheckBox)Item.FindControl("chkPrimaryEmail");
                    if (bPrimaryEmail != null)
                    {
                        if (bPrimaryEmail.Checked)
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
        protected void rGridEmail_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                sp_Email_DM VolDM = new sp_Email_DM();
                VolDM.VolID = (Guid)currentUser.ProviderUserKey;
                //rGridAddress.DataSource = VolAddrBLL.ListAddresses(VolDM);

                rGridEmail.DataSource = VolEmailCash.ListEmails(VolDM);
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

        

        #region Email CRUD
        /// <summary>
        /// rGridEmail_UpdateCommand - Handles Update click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridEmail_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            rGridEmail_UpdIns(sender, e, (int)RecordAction.Update);
        }

        /// <summary>
        /// rGridEmail_InsertCommand - Handles insert click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridEmail_InsertCommand(object sender, GridCommandEventArgs e)
        {
            rGridEmail_UpdIns(sender, e, (int)RecordAction.Insert);
        }

        /// <summary>
        /// rGridAdress_UpdIns - Handle update/insert in a common procedure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="iAction"></param>
        protected void rGridEmail_UpdIns(object sender, GridCommandEventArgs e, int iAction)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;

                //sp_Vol_Address_DM VolAddressDM = new sp_Vol_Address_DM();
                //sp_Vol_Addr_DM VolAddrDM = new sp_Vol_Addr_DM();

                sp_Email_DM VolEmailDM = new sp_Email_DM();
                VolEmailDM.VolID = (Guid)currentUser.ProviderUserKey;
                //VolAddrDM.VolID = (Guid)currentUser.ProviderUserKey; ;

                //VolAddressDM.VolID = (Guid)currentUser.ProviderUserKey;
                if (iAction == (int)RecordAction.Update)
                {
                    VolEmailDM.EmailID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["EmailID"]);
                    //VolAddrDM.AddrID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["AddrID"]);
                }
                VolEmailDM.ActiveFlg = (eeditedItem.FindControl("chkActive") as CheckBox).Checked;
                VolEmailDM.PrimaryFlg = (eeditedItem.FindControl("chkPrimaryFlg") as CheckBox).Checked;

                VolEmailDM.EmailAddr = (eeditedItem.FindControl("rTBEmail") as RadTextBox).Text.ToString();
                //TODO - Test to see if GeoCode works without USA at end
                //   VolAddressDM.GeoCodeGetSet = GetGeoCode(VolAddressDM);

                if (iAction == (int)RecordAction.Update)
                {
                    //VolAddrBLL.UpdateAddressContext(VolAddressDM, VolAddrDM);
                    VolEmailBLL.UpdateEmailAddr(VolEmailDM);

                }
                else if (iAction == (int)RecordAction.Insert)
                {
                    //VolAddrBLL.InsertAddressContext(ref VolAddressDM, ref VolAddrDM);
                    VolEmailBLL.InsertEmailContext(ref VolEmailDM);
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
        /// rGridEmail_DeleteCommand - Handle the delete command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridEmail_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            //sp_Vol_Address_DM VolAddressDM = new sp_Vol_Address_DM();
            //sp_Vol_Addr_DM VolAddrDM = new sp_Vol_Addr_DM();

            sp_Email_DM VolEmailDM = new sp_Email_DM();
            try
            {
                VolEmailDM.VolID = (Guid)currentUser.ProviderUserKey;
                VolEmailDM.EmailID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["EmailID"];

                VolEmailBLL.DeleteEmailsContext(VolEmailDM);
                //VolEmailBLL.DeleteAddressContext(VolAddressDM, VolAddrDM);
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