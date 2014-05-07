<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPrimary.ascx.cs" Inherits="VolTeer.Common.WebControls.ucPrimary" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="pnlPrimaryInfo" runat="server" Width="90%">
    <asp:Table ID="tblMainTable" runat="server" CellSpacing="0" CellPadding="1" Width="100%"
        Style="border-collapse: collapse;" >
        <asp:TableRow ID="rowEmail">
            <asp:TableCell>
                <asp:Label ID="PrimaryEmail" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowPhone">
            <asp:TableCell>
                <asp:Label ID="PrimaryPhone" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowAddress">
            <asp:TableCell>
                <asp:Label ID="PrimaryAddress" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Panel>
