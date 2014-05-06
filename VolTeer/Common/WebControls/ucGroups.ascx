<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGroups.ascx.cs" Inherits="VolTeer.Common.WebControls.ucGroups" %>


<asp:Panel ID="pnlAddressGrid" runat="server" CssClass="exampleWrapper" Width="90%" Height="200px">

    <telerik:RadGrid ID="rGridGroupVol"
        runat="server"
        OnNeedDataSource="rGridGroupVol_NeedDataSource"
        OnItemDataBound="rGridGroupVol_ItemDataBound"
        OnDeleteCommand="rGridGroupVol_DeleteCommand"
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
                <telerik:GridCheckBoxColumn DataField="GroupActive"  ItemStyle-Width="50px" HeaderText="Group Active" DataType="System.Boolean" FilterControlAltText="Filter column1 column" UniqueName="GroupActive">
                </telerik:GridCheckBoxColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Group Name" DataField="GroupName" UniqueName="GroupName">
                    <ItemTemplate>
                        <asp:Label ID="lblGroupName" runat="server" Width="150px" Text='<%# DataBinder.Eval(Container, "DataItem.GroupName") %>' ></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ItemStyle-Width="50px" UniqueName="Delete" ConfirmText="Are you sure you leave this group?" ButtonType="ImageButton" />

            </Columns>

        </MasterTableView>
    </telerik:RadGrid>
</asp:Panel>



