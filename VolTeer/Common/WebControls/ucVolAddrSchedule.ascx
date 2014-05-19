<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVolAddrSchedule.ascx.cs" Inherits="VolTeer.Common.WebControls.ucVolAddrSchedule" %>


<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="RadScheduler1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
</telerik:RadAjaxLoadingPanel>
<div class="exampleContainer">
    <telerik:RadScheduler runat="server" ID="RadScheduler1" 
        Width="750px" 
        DayStartTime="08:00:00"
        DayEndTime="18:00:00" 
        TimeZoneOffset="03:00:00"
        OnAppointmentInsert="RadScheduler1_AppointmentInsert"
        OnAppointmentUpdate="RadScheduler1_AppointmentUpdate"
        OnAppointmentDelete="RadScheduler1_AppointmentDelete"
        DataKeyField="ID"
        DataSubjectField="Subject"
        DataStartField="Start"
        DataEndField="End"
        DataRecurrenceField="RecurrenceRule"
        DataRecurrenceParentKeyField="RecurrenceParentId"
        DataReminderField="Reminder">
        <AdvancedForm Modal="true"></AdvancedForm>
        <TimelineView UserSelectable="false"></TimelineView>
        <TimeSlotContextMenuSettings EnableDefault="true"></TimeSlotContextMenuSettings>
        <AppointmentContextMenuSettings EnableDefault="true"></AppointmentContextMenuSettings>
        <Reminders Enabled="true"></Reminders>
    </telerik:RadScheduler>
</div>