<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAvailability.ascx.cs" Inherits="VolTeer.Common.WebControls.ucAvailability" %>


<telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" Skin="Web20">
    <MasterTableView>
        <Columns>

            <telerik:GridEditCommandColumn>
            </telerik:GridEditCommandColumn>

            <telerik:GridTemplateColumn HeaderText="Start Date" FilterControlAltText="Filter TemplateColumn column" UniqueName="AvailStartDate">
                <ItemTemplate>
                    <telerik:RadDateInput ID="tDTStartDate" DateFormat="mm/dd/yyyy" DisplayText='<%# DataBinder.Eval(Container, "DataItem.AvailStartDate") %>' runat="server"></telerik:RadDateInput>
                </ItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn HeaderText="End Date" FilterControlAltText="Filter TemplateColumn column" UniqueName="AvailEndDate">
                <ItemTemplate>
                    <telerik:RadDateInput ID="tDTEndDate" DateFormat="mm/dd/yyyy" DisplayText='<%# DataBinder.Eval(Container, "DataItem.AvailEndDate") %>' runat="server"></telerik:RadDateInput>
                </ItemTemplate>
            </telerik:GridTemplateColumn>


            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" UniqueName="DayID" HeaderText="Day of Week">
                <ItemTemplate>
                    <asp:Label ID="lblDay" runat="server">
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <telerik:RadDropDownList ID="rDDDay" runat="server">
                        <Items>
                            <telerik:DropDownListItem Text="Sunday" Value="1" />
                            <telerik:DropDownListItem Text="Monday" Value="2" />
                            <telerik:DropDownListItem Text="Tuesday" Value="3" />
                            <telerik:DropDownListItem Text="Wednesday" Value="4" />
                            <telerik:DropDownListItem Text="Thursday" Value="5" />
                            <telerik:DropDownListItem Text="Friday" Value="6" />
                            <telerik:DropDownListItem Text="Saturday" Value="7" />
                        </Items>
                    </telerik:RadDropDownList>
                </EditItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" UniqueName="StartTime" HeaderText="Start Time">
                <ItemTemplate>
                    <asp:Label ID="lblStartTime" runat="server">
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <telerik:RadTimePicker ID="rTPStartTime" runat="server" >
                    </telerik:RadTimePicker>                    
                </EditItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" UniqueName="EndTime" HeaderText="End Time">
                <ItemTemplate>
                    <asp:Label ID="lblEndTime" runat="server">
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <telerik:RadTimePicker ID="rTPEndTime" runat="server" >
                    </telerik:RadTimePicker>                    
                </EditItemTemplate>
            </telerik:GridTemplateColumn>

        </Columns>
    </MasterTableView>
</telerik:RadGrid>

