<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadSchedulerWebForm.aspx.cs" Inherits="RadSchedulerWebForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <script type="text/javascript">
        //Put your JavaScript code here.
    </script>
 
    <script type="text/javascript">

        var teacherID = "all";

        function OnClientSelectedIndexChanged(sender, args) {
            teacherID = args.get_item().get_value();
            var scheduler = $find('<%=RadScheduler1.ClientID %>');
            scheduler.rebind();
        }

        function OnClientAppointmentsPopulating(sender, eventArgs) {
            eventArgs.get_schedulerInfo().TeacherID = teacherID;
        }
    </script>
    <p>
        Filter appointments by teacher (resource):
    </p>
    <p>
        <telerik:RadComboBox ID="RadComboBox1" runat="server" OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
            <Items>
                <telerik:RadComboBoxItem Text="All" Value="all" />
                <telerik:RadComboBoxItem Text="Teacher 1" Value="1" />
                <telerik:RadComboBoxItem Text="Teacher 2" Value="2" />
            </Items>
        </telerik:RadComboBox>
    </p>
    <telerik:RadScheduler ID="RadScheduler1" runat="server" OnClientAppointmentsPopulating="OnClientAppointmentsPopulating"
        AppointmentStyleMode="Default" SelectedView="WeekView" SelectedDate="2011-01-21"
        Width="600px">
        <WebServiceSettings Path="SchedulerWebService.asmx" ResourcePopulationMode="ServerSide" />
        <ResourceStyles>
            <telerik:ResourceStyleMapping Type="Teacher" Key="1" BackColor="Orange" />
            <telerik:ResourceStyleMapping Type="Teacher" Key="2" BackColor="Aqua" />
        </ResourceStyles>
    </telerik:RadScheduler>
    </form>
</body>
</html>
