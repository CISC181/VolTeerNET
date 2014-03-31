<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadScheduler.aspx.cs" Inherits="VolTeer.SampleControls.RadScheduler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />


        <%--        <script type="text/javascript">

            var AddrID = "all";

            function OnClientSelectedIndexChanged(sender, args) {
                AddrID = args.get_item().get_value();
                var scheduler = $find('<%=RadScheduler1.ClientID %>');
                scheduler.rebind();
            }

            function OnClientAppointmentsPopulating(sender, eventArgs) {
                var VolID = $find('<%=HiddenVolID.ClientID %>');
                eventArgs.get_schedulerInfo().VolID = VolID;
                eventArgs.get_schedulerInfo().AddrID = AddrID;
            }
        </script>--%>

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

        <asp:HiddenField ID="HiddenVolID" runat="server" />

        <telerik:RadComboBox ID="RadComboBox1" runat="server">
            <Items>
                <telerik:RadComboBoxItem Text="All" Value="all" />
                <telerik:RadComboBoxItem Text="Addr 1" Value="1" />
                <telerik:RadComboBoxItem Text="Addr 2" Value="2" />
            </Items>
        </telerik:RadComboBox>

        <div class="exampleContainer">
            <telerik:RadScheduler runat="server" ID="RadScheduler1"
                Width="750px" SelectedView="MonthView" Height="100%" DataKeyField="AvailID"
                OnAppointmentInsert="RadScheduler1_AppointmentInsert"
                OnAppointmentDelete="RadScheduler1_AppointmentDelete" 
                OnAppointmentUpdate="RadScheduler1_AppointmentUpdate" 
                OnAppointmentCancelingEdit="RadScheduler1_AppointmentCancelingEdit" 
                OnAppointmentClick="RadScheduler1_AppointmentClick" 
                OnAppointmentCommand="RadScheduler1_AppointmentCommand" 
                OnAppointmentContextMenuItemClicked="RadScheduler1_AppointmentContextMenuItemClicked" 
                OnAppointmentContextMenuItemClicking="RadScheduler1_AppointmentContextMenuItemClicking" 
                OnAppointmentDataBound="RadScheduler1_AppointmentDataBound" 
                OnAppointmentsPopulating="RadScheduler1_AppointmentsPopulating1" 
                AllowDelete="true" AllowEdit="true"
                TimeZoneOffset="00:00:00" DayStartTime="08:00:00" DayEndTime="18:00:00"
                ReadOnly="false" OnAppointmentCreated="RadScheduler1_AppointmentCreated"
                ProviderName="VolTeerSchedulerData">
                <AdvancedForm Modal="true" />
                <MonthView AdaptiveRowHeight="true" ColumnHeaderDateFormat="ddd" MinimumRowHeight="4" />                
                <TimelineView UserSelectable="false"></TimelineView>
                <TimeSlotContextMenuSettings EnableDefault="true"></TimeSlotContextMenuSettings>
                <AppointmentContextMenuSettings EnableDefault="true"></AppointmentContextMenuSettings>
            </telerik:RadScheduler>
        </div>
    </form>
</body>
</html>
