<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="VolTeer.Account.RecoverPassword1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:PasswordRecovery ID="PasswordRecovery2" runat="server"
        BackColor="#E3EAEB" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid"
        BorderWidth="1px" Font-Names="Verdana">
        <MailDefinition From="someone@example.com">
        </MailDefinition>
        <SuccessTextStyle Font-Bold="True" ForeColor="#1C5E55" />
        <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <SubmitButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#1C5E55" />
        <SuccessTemplate>
            <asp:Label ID="lblContinue" runat="server" Text="Your password has been emailed.">
            </asp:Label>
            <br />
            <telerik:RadButton ID="rBTNContinue" runat="server" PostBackUrl="Login.aspx" Text="Login" Visible="false" Skin='<%$ AppSettings:Telerik.Skin %>'>
            </telerik:RadButton>
        </SuccessTemplate>

    </asp:PasswordRecovery>

<%--    <asp:PasswordRecovery ID="PasswordRecovery1"
        Font-Size="Small"
        OnSendingMail="PasswordRecovery1_SendingMail"
        OnUserLookupError="PasswordRecovery1_UserLookupError"
        runat="server">

    </asp:PasswordRecovery>--%>

</asp:Content>
