<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ManageOrg.aspx.cs" Inherits="VolTeer.Org.ManageOrg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnNeedDataSource="RadGrid1_NeedDataSource" CellSpacing="0" GridLines="None">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="GroupID" FilterControlAltText="Filter column column" UniqueName="column">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="GroupName" FilterControlAltText="Filter column1 column" UniqueName="column1">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ParticipationLevelID" FilterControlAltText="Filter column2 column" UniqueName="column2">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
