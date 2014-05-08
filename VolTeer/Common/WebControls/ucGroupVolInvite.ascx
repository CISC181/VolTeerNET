<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGroupVolInvite.ascx.cs" Inherits="VolTeer.Common.WebControls.ucGroupVolInvite" %>

<asp:Panel ID="pnlAddressGrid" runat="server" CssClass="exampleWrapper" Width="90%" Height="200px">

    <telerik:RadGrid ID="rGridGroupVol"
        runat="server"
        OnNeedDataSource="rGridGroupVol_NeedDataSource"
        OnItemDataBound="rGridGroupVol_ItemDataBound" OnItemCommand ="rGridGroupVol_ItemCommand"
        AutoGenerateColumns="False"
        AllowFilteringByColumn="False"
        AllowSorting="True"
        Skin='<%$ AppSettings:Telerik.Skin %>'
        CellSpacing="0"
        GridLines="None"
        AllowMultiRowEdit="True"
        AllowMultiRowSelection="True">
        <GroupingSettings CaseSensitive="False" />

        <MasterTableView DataKeyNames="GroupID, VolID"
            CommandItemDisplay="None"
            EditMode="InPlace"
            EnableHeaderContextAggregatesMenu="True"
            EnableHeaderContextFilterMenu="True"
            EnableHeaderContextMenu="True">
            <Columns>

                <telerik:GridButtonColumn CommandName="Select" Text="Select" UniqueName="Select">
                </telerik:GridButtonColumn>

                <telerik:GridButtonColumn CommandName="Deselect" Text="Deselect" UniqueName="Deselect">
                </telerik:GridButtonColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Group Name" DataField="GroupName" UniqueName="GroupName">
                    <ItemTemplate>
                        <asp:Label ID="lblGroupName" runat="server" Width="150px" Text='<%# DataBinder.Eval(Container, "DataItem.GroupName") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>


            </Columns>

        </MasterTableView>
    </telerik:RadGrid>


    <telerik:RadGrid ID="rGridVolInvite"
        runat="server"
        OnNeedDataSource="rGridVolInvite_NeedDataSource"
        OnItemDataBound="rGridVolInvite_ItemDataBound"
        AutoGenerateColumns="False"
        AllowFilteringByColumn="True"
        AllowSorting="True"
        Skin='<%$ AppSettings:Telerik.Skin %>'
        CellSpacing="0" AllowPaging ="true" PageSize ="5"
        GridLines="None"
        AllowMultiRowEdit="True"
        AllowMultiRowSelection="True">
        <GroupingSettings CaseSensitive="False" />

        <MasterTableView DataKeyNames="VolID"
            CommandItemDisplay="None"
            EditMode="InPlace"
            EnableHeaderContextAggregatesMenu="True"
            EnableHeaderContextFilterMenu="True"
            EnableHeaderContextMenu="True">
            <Columns>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" AllowFiltering ="false"  HeaderText="Invite" UniqueName="Invite">
                    <ItemTemplate>
                        <telerik:RadButton ID="rBTNInvite" Enabled="false" runat="server" Text="Invite" AutoPostBack="true" OnClick="rBTNInvite_Click" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.VolID") %>'></telerik:RadButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="First Name" DataField="VolFirstName" UniqueName="VolFirstName">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" Width="150px" Text='<%# DataBinder.Eval(Container, "DataItem.VolFirstName") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Middle Name" DataField="VolMiddleName" UniqueName="VolMiddleName">
                    <ItemTemplate>
                        <asp:Label ID="lblMiddleName" runat="server" Width="150px" Text='<%# DataBinder.Eval(Container, "DataItem.VolMiddleName") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Last Name" DataField="VolLastName" UniqueName="VolLastName">
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Width="150px" Text='<%# DataBinder.Eval(Container, "DataItem.VolLastName") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

        </MasterTableView>
    </telerik:RadGrid>



</asp:Panel>

