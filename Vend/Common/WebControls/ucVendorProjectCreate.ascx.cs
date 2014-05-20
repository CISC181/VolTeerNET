using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.BusinessLogicLayer.VT.Vend;
namespace Vend.Common.WebControls
{
    public partial class ucVendorProjectCreate : System.Web.UI.UserControl
    {


        sp_VendAddress_DM addrDM = new sp_VendAddress_DM();

        MembershipUser currentUser;

        //we may not end up needing this. I added the states into the actual ascx file as items
        static List<String> states = new List<String>();
        List<sp_Contact_DM> contacts = new List<sp_Contact_DM>();

        static ucVendorProjectCreate()
        {
            //I just learned all my states
            //states.Add("Initial state");
            states.Add("Alabama");
            states.Add("Alaska");
            states.Add("Arizona");
            states.Add("Arkansas");
            states.Add("California");
            states.Add("Colorado");
            states.Add("Connecticut");
            states.Add("Delaware");
            states.Add("Florida");
            states.Add("Georgia");
            states.Add("Hawaii");
            states.Add("Idaho");
            states.Add("Illinois");
            states.Add("Indiana");
            states.Add("Iowa");
            states.Add("Kansas");
            states.Add("Kentucky");
            states.Add("Louisiana");
            states.Add("Maine");
            states.Add("Maryland");
            states.Add("Massachusetts");
            states.Add("Michigan");
            states.Add("Minnesota");
            states.Add("Mississippi");
            states.Add("Missouri");
            states.Add("Montana");
            states.Add("Nebraska");
            states.Add("Nevada");
            states.Add("New Hampshire");
            states.Add("New Jersey");
            states.Add("New Mexico");
            states.Add("New York");
            states.Add("North Carolina");
            states.Add("North Dakota");
            states.Add("Ohio");
            states.Add("Oklahoma");
            states.Add("Oregon");
            states.Add("Pennsylvania");
            states.Add("Rhode Island");
            states.Add("South Carolina");
            states.Add("South Dakota");
            states.Add("Tennessee");
            states.Add("Texas");
            states.Add("Utah");
            states.Add("Vermont");
            states.Add("Virginia");
            states.Add("Washington");
            states.Add("West Virginia");
            states.Add("Wisconsin");
            states.Add("Wyoming");
            //states.Add("Final State");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = Membership.GetUser();
            if (!Page.IsPostBack)
            {
                getContacts();
                RadComboBoxItem newItem = new RadComboBoxItem();
                newItem.Text = "--";
                newItem.Value = "1";
                rCBContact.Items.Add(newItem);
                foreach (sp_Contact_DM contact in contacts)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = contact.ContactFirstName + " ";
                    if (contact.ContactMiddleName != null)
                    {
                        item.Text += contact.ContactMiddleName + " ";
                    }
                    item.Text += contact.ContactLastName;
                    rCBContact.Items.Add(item);

                }
            }
        }

        protected void getContacts()
        {
            sp_VendContact_BLL vendContactBLL = new sp_VendContact_BLL();
            sp_Contact_BLL contactBLL = new sp_Contact_BLL();
            List<sp_VendContact_DM> vendContacts = vendContactBLL.ListVendContacts((Guid)currentUser.ProviderUserKey, null);
            foreach (sp_VendContact_DM vendCont in vendContacts)
            {
                contacts.Add(contactBLL.ListContacts(vendCont.ContactID));
                
            }

            //Uncomment to see that the combobox loads correctly
            /*sp_Contact_DM newCont = new sp_Contact_DM();
            newCont.ContactID = Guid.NewGuid();
            newCont.ContactFirstName = "Daniel";
            newCont.ContactMiddleName = "Lees";
            newCont.ContactLastName = "Barker";
            newCont.ActiveFlg = true;
            contacts.Add(newCont);*/

        }

        protected void saveForm()
        {
            sp_Project_DM projectDM = new sp_Project_DM();
            sp_VendorProjContact_DM vpContactDM = new sp_VendorProjContact_DM();

            vpContactDM.VendorID = (Guid)currentUser.ProviderUserKey;
            Guid projectID = Guid.NewGuid();

            vpContactDM.ProjectID = projectID;

            int contectIndex = rCBContact.SelectedIndex;
            if (rCBContact.SelectedIndex != 0)
            {
                vpContactDM.ContactID = contacts.ElementAt(rCBContact.SelectedIndex - 1).ContactID;
            }


            projectDM.ProjectID = projectID;
            projectDM.ProjectName = rTBProjName.Text;
            projectDM.ProjectDesc = rTBProjDesc.Text;
            projectDM.ActiveFlg = false;

            sp_Project_BLL projectBLL = new sp_Project_BLL();
            sp_VendorProjContact_BLL vpContactBLL = new sp_VendorProjContact_BLL();

            //Why is it by ref? That's weird.
            projectBLL.InsertProjectContext(ref projectDM);
            vpContactBLL.InsertContactContext(vpContactDM);
        }

    }
}