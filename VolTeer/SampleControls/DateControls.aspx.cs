using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.BusinessLogicLayer.VT.Vol;
using System.Web.Security;
using Telerik.Web.UI;
using VolTeer.App_Code;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.SampleControls
{
    public partial class DateControls : System.Web.UI.Page
    {
        sp_Availablity_BLL BLL = new sp_Availablity_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void rGridAvailability_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            MembershipUser currentUser;
            currentUser = Membership.GetUser();
            Guid? VolID;
            VolID = (Guid)currentUser.ProviderUserKey;
            rGridAvailability.DataSource = BLL.ListVolunteerAvailability(VolID);

        }

        protected void rGridAvailability_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

            rGridAvailability_UpdIns(sender, e, (int)RecordAction.Insert);
        }

        protected void rGridAvailability_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rGridAvailability_UpdIns(object sender, GridCommandEventArgs e, int iAction)
        {
            GridEditableItem eeditedItem = e.Item as GridEditableItem;

            //int iAddrID = 0;
            //if (iAction == (int)RecordAction.Update)
            //{
            //    iAddrID = Convert.ToInt32(eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["AddrID"]);
            //}

            RadCalendar rCalRangeSelectUpd = (eeditedItem.FindControl("rCalRangeSelectUpd") as RadCalendar);
            RadCalendar rCalDaysAvailableUpd = (eeditedItem.FindControl("rCalDaysAvailableUpd") as RadCalendar);
            RadTimePicker rTimeBeginUpd = (eeditedItem.FindControl("rTimeBeginUpd") as RadTimePicker);
            RadTimePicker rTimeEndUpd = (eeditedItem.FindControl("rTimeEndUpd") as RadTimePicker);
            RadNumericTextBox tNTTotalHours = (eeditedItem.FindControl("tNTTotalHours") as RadNumericTextBox);


            sp_Availablity_DM AvailDM = new sp_Availablity_DM();
            AvailDM.AvailStartDate = rCalRangeSelectUpd.RangeMinDate;
            AvailDM.AvailEndDate  = rCalRangeSelectUpd.RangeMaxDate;
            AvailDM.StartTime = rTimeBeginUpd.SelectedTime.Value;
            AvailDM.EndTime = rTimeEndUpd.SelectedTime.Value;

            


        }
    }
}