<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ManageOrg.aspx.cs" Inherits="VolTeer.Org.ManageOrg" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />

    <telerik:RadGrid ID="RadGrid1" DataSourceID="ObjectDataSource1" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None"
        OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="RadGrid1_ItemCommand"
        AllowPaging="True" AllowAutomaticUpdates="True" AllowAutomaticInserts="True"
        AllowAutomaticDeletes="True" AllowSorting="True" OnItemCreated="RadGrid1_ItemCreated"
        OnItemInserted="RadGrid1_ItemInserted" OnPreRender="RadGrid1_PreRender" Skin="Office2010Silver" AllowFilteringByColumn="True">
        <PagerStyle Mode="NextPrevAndNumeric" />
        <GroupingSettings CaseSensitive="False" />
        <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" DataKeyNames="GroupID">            
            <Columns>
                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                </telerik:GridEditCommandColumn>

                <telerik:GridBoundColumn DataField="GroupID" ReadOnly="true" SortExpression="GroupID" FilterControlAltText="Filter GroupID column" HeaderText="Group ID" UniqueName="GroupID" DataType="System.Int32">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="GroupName" SortExpression="GroupName" FilterControlAltText="Filter GroupName column" HeaderText="Group Name" UniqueName="GroupName">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="ParticipationLevelID" SortExpression="ParticipationLevelID" FilterControlAltText="Filter Participation Level ID column" HeaderText="ParticipationLevelID" UniqueName="ParticipationLevelID" DataType="System.Int32">
                </telerik:GridBoundColumn>

                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ConfirmText="Are you sure you want to delete this?" ButtonType="ImageButton" />
            </Columns>
            <EditFormSettings>
                <EditColumn ButtonType="ImageButton" />
            </EditFormSettings>

        </MasterTableView>
    </telerik:RadGrid>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        SelectMethod="ListGroups" InsertMethod="InsertGroup" UpdateMethod="UpdateGroup" DeleteMethod="DeleteGroup"
        TypeName="VolTeer.BusinessLogicLayer.VT.Vol.sp_Group_BLL">
        <SelectParameters>
            <asp:Parameter Name="IGroupID" DefaultValue="0" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="GroupID" Type="Int32" />
            <asp:Parameter Name="GroupName" Type="String" />
            <asp:Parameter Name="participationLevelID" Type="Int32" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="GroupID" Type="Int32" />
            <asp:Parameter Name="ActiveFlg" Type="Boolean" DefaultValue="False" />
        </DeleteParameters>

    </asp:ObjectDataSource>
</asp:Content>
