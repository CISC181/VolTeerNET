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
using VolTeer.BusinessLogicLayer.VT.Vend;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.BusinessLogicLayer.VT.Other;
using VolTeer.Cache.VT.Vol;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.GoogleAPI;
using System.Web.ApplicationServices;
using System.Web.Security;

using VolTeer.DomainModels.Service;
using VolTeer.GoogleAPI;
using System.IO;


namespace Vend.Common.WebControls
{
    public partial class ucVendorAddress : System.Web.UI.UserControl
    {
        // Event handler to call method on the main page.
        public event EventHandler ShowErrorOccurs;

        // Pass in the AddrOwner (VolID, GroupID, etc) and the RecordType (what kind of record it is)
        MembershipUser currentUser;
        public int iRecordTypeID;

        //  Object References
        private sp_Vol_Address_BLL VolAddrBLL = new sp_Vol_Address_BLL();
        private sp_Vol_Address_Cache VolAddrCash = new sp_Vol_Address_Cache();
        private sp_VendAddress_BLL VendAddressBLL = new sp_VendAddress_BLL();

        private sp_State_BLL stBLL = new sp_State_BLL();
        //trying some BS
        int pre_ID = 0;

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

            pnlSingleAddress.Visible = false;
            pnlAddressGrid.Visible = true;
            sp_Vol_Address_DM VolDM = new sp_Vol_Address_DM();
            sp_VendAddress_DM VendDM = new sp_VendAddress_DM();
            //VendDM.AddrID = (int)currentUser.ProviderUserKey;
            VolDM.VolID = (Guid)currentUser.ProviderUserKey;
            //rGridAddress.DataSource = VolAddrBLL.ListAddresses(VolDM);

            rGridAddress.DataSource = VolAddrCash.ListAddresses(VolDM);
            rGridAddress.DataBind();

        }

        /// <summary>
        /// SetPrimaryValues - Paint the screen with default values (use non-telerik controls)
        /// </summary>
        protected void SetPrimaryValues()
        {
            sp_VendAddress_DM VendDM = new sp_VendAddress_DM();
            sp_Vol_Address_DM VolDM = new sp_Vol_Address_DM();
            StringBuilder sb = new StringBuilder();

            try
            {
                VolDM.VolID = (Guid)currentUser.ProviderUserKey;
                VolDM = VolAddrCash.ListPrimaryAddress(VolDM);

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

        #region Native Telerik Methods

        /// <summary>
        /// rGridAddress_ItemDataBound - handle items that have to be addressed at databound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridAddress_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    GridEditableItem edtItem = (GridEditableItem)e.Item;

                    RadDropDownList rDDSt = (RadDropDownList)edtItem.FindControl("rDDSt");
                    rDDSt.DataSource = stBLL.ListStates();
                    rDDSt.DataValueField = "StateAbbr";
                    rDDSt.DataTextField = "StateName";
                    rDDSt.DataBind();

                    if (e.Item is GridEditFormInsertItem)
                    {
                        CheckBox ckActive = (CheckBox)edtItem.FindControl("chkActive");
                        ckActive.Checked = true;
                    }
                    else
                    {

                        rDDSt.SelectedValue = DataBinder.Eval(edtItem.DataItem, "St").ToString();

                        CheckBox ckActive = (CheckBox)edtItem.FindControl("chkActive");
                        ckActive.Checked = (bool)DataBinder.Eval(edtItem.DataItem, "ActiveFlg");


                    }
                }



                else if (e.Item is GridItem)
                {
                    //  If the address is the primary address, don't let the user delete it
                    GridItem Item = (GridItem)e.Item;
                    CheckBox bPrimaryAddr = (CheckBox)Item.FindControl("chkPrimaryAddr");
                    if (bPrimaryAddr != null)
                    {
                        bPrimaryAddr.Enabled = false;
                        if (bPrimaryAddr.Checked)
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
        /// rGridAddress_NeedDataSource - Called when the grid needs a data source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridAddress_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                
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

        #region Address CRUD
        /// <summary>
        /// rGridAddress_UpdateCommand - Handles Update click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridAddress_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            rGridAdress_UpdIns(sender, e, (int)RecordAction.Update);
        }

        /// <summary>
        /// rGridAddress_InsertCommand - Handles insert click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridAddress_InsertCommand(object sender, GridCommandEventArgs e)
        {
            rGridAdress_UpdIns(sender, e, (int)RecordAction.Insert);
        }

        /// <summary>
        /// rGridAdress_UpdIns - Handle update/insert in a common procedure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="iAction"></param>
        protected void rGridAdress_UpdIns(object sender, GridCommandEventArgs e, int iAction)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;

                sp_VendAddress_DM VendAddressDM = new sp_VendAddress_DM();
                sp_VendorAddr_DM VendAddrDM = new sp_VendorAddr_DM();

                VendAddrDM.AddrID = (int)currentUser.ProviderUserKey; ;

                VendAddressDM.AddrID = (int)currentUser.ProviderUserKey;
                if (iAction == (int)RecordAction.Update)
                {
                    VendAddressDM.AddrID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["AddrID"]);
                    pre_ID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["AddrID"]);
                    VendAddrDM.AddrID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["AddrID"]);
                }
                VendAddressDM.ActiveFlg = (eeditedItem.FindControl("chkActive") as CheckBox).Checked;
                VendAddressDM.AddrLine1 = (eeditedItem.FindControl("rTBAddr1") as RadTextBox).Text.ToString();
                VendAddressDM.AddrLine2 = (eeditedItem.FindControl("rTBAddr2") as RadTextBox).Text.ToString();
                VendAddressDM.AddrLine3 = (eeditedItem.FindControl("rTBAddr3") as RadTextBox).Text.ToString();
                VendAddressDM.City = (eeditedItem.FindControl("rTBCity") as RadTextBox).Text.ToString();
                VendAddressDM.St = (eeditedItem.FindControl("rDDSt") as RadDropDownList).SelectedValue.ToString();
                VendAddressDM.Zip = Convert.ToInt32((eeditedItem.FindControl("rNTBZip") as RadNumericTextBox).Text);
                string strZip4 = ((eeditedItem.FindControl("rNTBZip4") as RadNumericTextBox).Text).ToString();
                if (strZip4 == string.Empty)
                {
                    VendAddressDM.Zip4 = null;
                }
                else
                {
                    VendAddressDM.Zip4 = Convert.ToInt32(strZip4.ToString());
                }
                //TODO - Test to see if GeoCode works without USA at end
                //   VolAddressDM.GeoCodeGetSet = GetGeoCode(VolAddressDM);

                if (iAction == (int)RecordAction.Update)
                {
                    

                }
                else if (iAction == (int)RecordAction.Insert)
                {

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
        protected void rGridAddress_DeleteCommand(object sender, GridCommandEventArgs e)
        {

            try
            {

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

        protected string GetGeoCode(sp_VendAddress_DM VendAddr)
        {
            GoogleAddress googleAddress = new GoogleAddress();
            googleAddress.FormattedAddress = VendAddr.AddrLine1 + ", " +
               VendAddr.City + ", " + VendAddr.St + " " + VendAddr.Zip;
            //Assume we want to send the request to Google using SSL
            IGeocoder geoCoder = new GoogleGeocoder(true);
            String geoCoderXML = geoCoder.GetLatLongFromAddress(googleAddress);
            String latitude;
            String longitude;

            using (XmlReader reader = XmlReader.Create(new StringReader(geoCoderXML)))
            {
                reader.ReadToFollowing("lat");
                reader.MoveToFirstAttribute();
                latitude = reader.Value;

                reader.ReadToFollowing("lon");
                longitude = reader.Value;
            }

            String gcReturn;
            if (latitude.Contains("unknown") || longitude.Contains("unknown"))
            {
                gcReturn = null;
            }
            else
            {
                gcReturn = "'POINT(" + longitude + " " + latitude + ")'";
            }

            return gcReturn;
        }

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

        protected void rGridAddress_PreRender(object sender, EventArgs e)
        {
            //foreach column
            //For Each column As GridColumn In RadGrid.MasterTableView.AutoGeneratedColumns
            // If column.UniqueName = "ID" Then
            //column.Visible = False

        }

    }

}