using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Telerik.Web.UI;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.Common.WebControls
{
    public partial class ucVolAddrSchedule : System.Web.UI.UserControl
    {

        sp_Availablity_BLL AvailBLL = new sp_Availablity_BLL();

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        //protected void RadScheduler1_AppointmentUpdate(object sender, Telerik.Web.UI.AppointmentUpdateEventArgs e)
        //{

        //}

        //protected void RadScheduler1_AppointmentDelete(object sender, Telerik.Web.UI.AppointmentDeleteEventArgs e)
        //{

        //}

        //protected void RadScheduler1_AppointmentInsert(object sender, Telerik.Web.UI.AppointmentInsertEventArgs e)
        //{

        //}




            //private const string AppointmentsKey = "Telerik.Web.Examples.Scheduler.BindToList.CS.Apts";

            //private List<sp_Availablity_DM> Appointments
            //{
            //    get
            //    {
            //        List<sp_Availablity_DM> sessApts = Session[AppointmentsKey] as List<sp_Availablity_DM>;
            //        if (sessApts == null)
            //        {
            //            sessApts = new List<sp_Availablity_DM>();
            //            Session[AppointmentsKey] = sessApts;
            //        }

            //        return sessApts;
            //    }
            //}

            //protected override void OnInit(EventArgs e)
            //{
            //    base.OnInit(e);

            //    if (!IsPostBack)
            //    {
            //        Session.Remove(AppointmentsKey);

            //        InitializeResources();
            //        InitializeAppointments();
            //    }

            //    RadScheduler1.DataSource = Appointments;
            //}

            //protected void RadScheduler1_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
            //{
            //    sp_Availablity_DM AvailDM = new sp_Availablity_DM();

                
            //    Appointments.Add(new sp_Availablity_DM());
            //}

            //protected void RadScheduler1_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
            //{
            //    sp_Availablity_DM ai = FindById(e.ModifiedAppointment.ID);


            //    RecurrenceRule rrule;

            //    if (RecurrenceRule.TryParse(e.ModifiedAppointment.RecurrenceRule, out rrule))
            //    {
            //        rrule.Range.Start = e.ModifiedAppointment.Start;
            //        rrule.Range.EventDuration = e.ModifiedAppointment.End - e.ModifiedAppointment.Start;
            //        TimeSpan startTimeChange = e.ModifiedAppointment.Start - e.Appointment.Start;
            //        for (int i = 0; i < rrule.Exceptions.Count; i++)
            //        {
            //            rrule.Exceptions[i] = rrule.Exceptions[i].Add(startTimeChange);
            //        }
            //        e.ModifiedAppointment.RecurrenceRule = rrule.ToString();
            //    }

            //    ai.CopyInfo(e.ModifiedAppointment);
            //}

            //protected void RadScheduler1_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
            //{
            //    Appointments.Remove(FindById(e.Appointment.ID));
            //}

            //private void InitializeResources()
            //{
            //    ResourceType resType = new ResourceType("User");
            //    resType.ForeignKeyField = "UserID";

            //    RadScheduler1.ResourceTypes.Add(resType);
            //    RadScheduler1.Resources.Add(new Resource("User", 1, "Alex"));
            //    RadScheduler1.Resources.Add(new Resource("User", 2, "Bob"));
            //    RadScheduler1.Resources.Add(new Resource("User", 3, "Charlie"));
            //}

            //private void InitializeAppointments()
            //{
            //    DateTime start = DateTime.UtcNow.Date;
            //    start = start.AddHours(6);
            //    Appointments.Add(new sp_Availablity_DM("Take the car to the service", start, start.AddHours(1), string.Empty, null, new Reminder(30).ToString(), 1));
            //    Appointments.Add(new sp_Availablity_DM("Meeting with Alex", start.AddHours(2), start.AddHours(3), string.Empty, null, string.Empty, 2));

            //    start = start.AddDays(-1);
            //    DateTime dayStart = RadScheduler1.UtcDayStart(start);
            //    Appointments.Add(new sp_Availablity_DM("Bob's Birthday", dayStart, dayStart.AddDays(1), string.Empty, null, string.Empty, 1));
            //    Appointments.Add(new sp_Availablity_DM("Call Charlie about the Project", start.AddHours(2), start.AddHours(3), string.Empty, null, string.Empty, 2));

            //    start = start.AddDays(2);
            //    Appointments.Add(new sp_Availablity_DM("Get the car from the service", start.AddHours(2), start.AddHours(3), string.Empty, null, string.Empty, 1));
            //}

            //private sp_Availablity_DM FindById(object ID)
            //{
            //    foreach (sp_Availablity_DM ai in Appointments)
            //    {
            //        if (ai.ID.Equals(ID))
            //        {
            //            return ai;
            //        }
            //    }

            //    return null;
            //}
        }






}