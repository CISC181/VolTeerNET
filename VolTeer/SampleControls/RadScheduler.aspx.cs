using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VolTeer.DomainModels.VT.Vol;
using System.Web.Security;

namespace VolTeer.SampleControls
{
    public partial class RadScheduler : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RadScheduler1.SelectedDate = DateTime.Now;

            MembershipUser user = Membership.GetUser();
            HiddenVolID.Value = user.ProviderUserKey.ToString();

        }

        protected void RadScheduler1_AppointmentCreated(object sender, AppointmentCreatedEventArgs e)
        {
            sp_Availablity_DM cAvail = new sp_Availablity_DM();

            string strVolID = "6CD40064-CF05-4B55-93C0-6E4D7F9CCE34";
            Guid VolID = new Guid(strVolID);
            cAvail.VolID = VolID;
            cAvail.AddrID = 1;


        }

        protected void RadScheduler1_AppointmentsPopulating(object sender, AppointmentsPopulatingEventArgs e)
        {

        }

        protected void RadScheduler1_AppointmentInsert(object sender, AppointmentInsertEventArgs e)
        {
            e.Appointment.Attributes.Add("VolID", "6CD40064-CF05-4B55-93C0-6E4D7F9CCE34");
            e.Appointment.Attributes.Add("AddrID", "1");

        }

        protected void RadScheduler1_AppointmentDelete(object sender, AppointmentDeleteEventArgs e)
        {

        }

        protected void RadScheduler1_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
        {

        }

        protected void RadScheduler1_AppointmentCancelingEdit(object sender, AppointmentCancelingEditEventArgs e)
        {

        }

        protected void RadScheduler1_AppointmentClick(object sender, SchedulerEventArgs e)
        {

        }

        protected void RadScheduler1_AppointmentCommand(object sender, AppointmentCommandEventArgs e)
        {

        }

        protected void RadScheduler1_AppointmentContextMenuItemClicked(object sender, AppointmentContextMenuItemClickedEventArgs e)
        {

        }

        protected void RadScheduler1_AppointmentContextMenuItemClicking(object sender, AppointmentContextMenuItemClickingEventArgs e)
        {

        }

        protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {

        }

        protected void RadScheduler1_AppointmentsPopulating1(object sender, AppointmentsPopulatingEventArgs e)
        {

        }
    }
}