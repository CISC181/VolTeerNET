<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateControls.aspx.cs" Inherits="VolTeer.SampleControls.DateControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <div>
        </div>

        <telerik:RadGrid ID="rGridAvailability" OnInsertCommand="rGridAvailability_InsertCommand" OnUpdateCommand="rGridAvailability_UpdateCommand" 
            
            runat="server" AutoGenerateColumns="False" OnNeedDataSource="rGridAvailability_NeedDataSource">
            <MasterTableView EditMode="PopUp" CommandItemDisplay="Top">
                <CommandItemSettings ShowCancelChangesButton="True" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" ShowSaveChangesButton="True" />
                <Columns>
                    <telerik:GridTemplateColumn FilterControlAltText="CalRangeSelectFilter" UniqueName="CalRangeSelect" HeaderText="Select Date Range">
                        <ItemTemplate>
                            <telerik:RadCalendar ID="rCalRangeSelect" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;"
                                SelectedDate="" Skin="Web20" RangeSelectionMode="ConsecutiveClicks">
                                <WeekendDayStyle CssClass="rcWeekend"></WeekendDayStyle>
                                <CalendarTableStyle CssClass="rcMainTable"></CalendarTableStyle>
                                <OtherMonthDayStyle CssClass="rcOtherMonth"></OtherMonthDayStyle>
                                <OutOfRangeDayStyle CssClass="rcOutOfRange"></OutOfRangeDayStyle>
                                <DisabledDayStyle CssClass="rcDisabled"></DisabledDayStyle>
                                <SelectedDayStyle CssClass="rcSelected"></SelectedDayStyle>
                                <DayOverStyle CssClass="rcHover"></DayOverStyle>
                                <FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Web20"></FastNavigationStyle>
                                <ViewSelectorStyle CssClass="rcViewSel"></ViewSelectorStyle>
                            </telerik:RadCalendar>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadCalendar ID="rCalRangeSelectUpd" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;"
                                SelectedDate="" Skin="Web20" RangeSelectionMode="ConsecutiveClicks">
                                <WeekendDayStyle CssClass="rcWeekend"></WeekendDayStyle>
                                <CalendarTableStyle CssClass="rcMainTable"></CalendarTableStyle>
                                <OtherMonthDayStyle CssClass="rcOtherMonth"></OtherMonthDayStyle>
                                <OutOfRangeDayStyle CssClass="rcOutOfRange"></OutOfRangeDayStyle>
                                <DisabledDayStyle CssClass="rcDisabled"></DisabledDayStyle>
                                <SelectedDayStyle CssClass="rcSelected"></SelectedDayStyle>
                                <DayOverStyle CssClass="rcHover"></DayOverStyle>
                                <FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Web20"></FastNavigationStyle>
                                <ViewSelectorStyle CssClass="rcViewSel"></ViewSelectorStyle>
                            </telerik:RadCalendar>
                            </ItemTemplate>

                        </EditItemTemplate>

                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn FilterControlAltText="CalDaysAvailable" UniqueName="CalDaysAvaiable" HeaderText="Select Dates Available">
                        <ItemTemplate>
                            <telerik:RadCalendar ID="rCalDaysAvailable" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;"
                                SelectedDate="" Skin="Web20" RangeSelectionMode="None">
                                <WeekendDayStyle CssClass="rcWeekend"></WeekendDayStyle>
                                <CalendarTableStyle CssClass="rcMainTable"></CalendarTableStyle>
                                <OtherMonthDayStyle CssClass="rcOtherMonth"></OtherMonthDayStyle>
                                <OutOfRangeDayStyle CssClass="rcOutOfRange"></OutOfRangeDayStyle>
                                <DisabledDayStyle CssClass="rcDisabled"></DisabledDayStyle>
                                <SelectedDayStyle CssClass="rcSelected"></SelectedDayStyle>
                                <DayOverStyle CssClass="rcHover"></DayOverStyle>
                                <FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Web20"></FastNavigationStyle>
                                <ViewSelectorStyle CssClass="rcViewSel"></ViewSelectorStyle>
                            </telerik:RadCalendar>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadCalendar ID="rCalDaysAvailableUpd" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;"
                                SelectedDate="" Skin="Web20" RangeSelectionMode="None">
                                <WeekendDayStyle CssClass="rcWeekend"></WeekendDayStyle>
                                <CalendarTableStyle CssClass="rcMainTable"></CalendarTableStyle>
                                <OtherMonthDayStyle CssClass="rcOtherMonth"></OtherMonthDayStyle>
                                <OutOfRangeDayStyle CssClass="rcOutOfRange"></OutOfRangeDayStyle>
                                <DisabledDayStyle CssClass="rcDisabled"></DisabledDayStyle>
                                <SelectedDayStyle CssClass="rcSelected"></SelectedDayStyle>
                                <DayOverStyle CssClass="rcHover"></DayOverStyle>
                                <FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Web20"></FastNavigationStyle>
                                <ViewSelectorStyle CssClass="rcViewSel"></ViewSelectorStyle>
                            </telerik:RadCalendar>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="TimeBegin" UniqueName="TimeBegin" HeaderText="Start Time Available">
                        <ItemTemplate>
                            <telerik:RadTimePicker ID="rTimeBegin" runat="server"></telerik:RadTimePicker>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTimePicker ID="rTimeBeginUpd" runat="server"></telerik:RadTimePicker>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="TimeStart" UniqueName="TimeEnd" HeaderText="End Time Available">
                        <ItemTemplate>
                            <telerik:RadTimePicker ID="rTimeEnd" runat="server"></telerik:RadTimePicker>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTimePicker ID="rTimeEndUpd" runat="server"></telerik:RadTimePicker>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="TimeEnd" UniqueName="TotalHours" HeaderText="# Hours Available">
                        <EditItemTemplate>
                            <telerik:RadNumericTextBox ID="tNTTotalHours" runat="server" EmptyMessage="# Hours"></telerik:RadNumericTextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTotalHours" runat="server"></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                </Columns>
            </MasterTableView>

        </telerik:RadGrid>

    </form>
</body>
</html>
