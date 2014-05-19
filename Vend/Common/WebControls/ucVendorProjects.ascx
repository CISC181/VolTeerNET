<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVendorProjects.ascx.cs" Inherits="Vend.Common.WebControls.ucVendorProjects" %>


<asp:Panel ID="pnlAddressGrid" runat="server" CssClass="exampleWrapper" Width="90%" Height="200px">

    <telerik:RadGrid ID="rGridVendProjects"
        runat="server"
        OnNeedDataSource="rGridVendProjects_NeedDataSource"
        OnItemDataBound="rGridVendProjects_ItemDataBound"
        OnDeleteCommand="rGridVendProjects_DeleteCommand"
        OnItemCommand="rGridVendProjects_ItemCommand"
        AutoGenerateColumns="False"
        AllowFilteringByColumn="False"
        AllowSorting="True"
        Skin='<%$ AppSettings:Telerik.Skin %>'
        CellSpacing="0"
        GridLines="None"
        AllowMultiRowEdit="True"
        AllowMultiRowSelection="True">
        <GroupingSettings CaseSensitive="False" />
        <MasterTableView DataKeyNames="ProjectID"
            CommandItemDisplay="None"
            EditMode="InPlace"
            EnableHeaderContextAggregatesMenu="True"
            EnableHeaderContextFilterMenu="True"
            EnableHeaderContextMenu="True">
            <Columns>
                <telerik:GridTemplateColumn DataField="ProjectName" HeaderText="Project Name" UniqueName="ProjectName">
                    <ItemTemplate>
                        <asp:Label ID="lblProjectName" runat="server" Width="100px" Text='<%# DataBinder.Eval(Container, "DataItem.ProjectName") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="ProjectDesc" HeaderText="Description" UniqueName="ProjectDesc">
                    <ItemTemplate>
                        <asp:Label ID="lblProjectDesc" runat="server" Width="200px" Text='<%# DataBinder.Eval(Container, "DataItem.ProjectDesc") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridCheckBoxColumn DataField="ActiveFlg" ItemStyle-Width="50px" HeaderText="Active" DataType="System.Boolean" FilterControlAltText="Filter column1 column" UniqueName="Active">
                </telerik:GridCheckBoxColumn>
                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ItemStyle-Width="50px" UniqueName="Delete" ConfirmText="Are you sure you leave this group?" ButtonType="ImageButton" />

            </Columns>

        </MasterTableView>
    </telerik:RadGrid>
</asp:Panel>
