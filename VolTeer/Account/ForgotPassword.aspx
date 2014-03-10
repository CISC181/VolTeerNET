<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="VolTeer.Account.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblForgotTitle" runat="server" Text="Please enter your email address and press 'Submit'">

    </asp:Label>
    <br />
    <asp:Table runat="server" Width="60%">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblEmail" runat="server" Text="Email Address"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadTextBox ID="rTBEmail" runat="server"></telerik:RadTextBox>
            </asp:TableCell>

            <asp:TableCell>
                <telerik:RadButton ID="rBTSubmit" runat="server" OnClick="rBTSubmit_Click" Text="Submit"></telerik:RadButton>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
