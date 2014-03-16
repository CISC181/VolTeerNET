<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVolBasicInfo.ascx.cs" Inherits="VolTeer.Common.WebControls.ucVolBasicInfo" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Table id="tblBasicInfo" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <telerik:RadTextBox ID="rTBFirstName" runat="server" EmptyMessage="First Name" Width="90px">
            </telerik:RadTextBox>
            &nbsp;
                        <telerik:RadTextBox ID="rTBMiddleName" runat="server" EmptyMessage="Middle Name" Width="80px">
                        </telerik:RadTextBox>
            &nbsp;
                        <telerik:RadTextBox ID="rTBLastName" runat="server" EmptyMessage="Last Name" Width="125px">
                        </telerik:RadTextBox>

        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
