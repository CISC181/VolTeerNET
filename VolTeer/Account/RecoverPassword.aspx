<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="VolTeer.Account.RecoverPassword1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <asp:PasswordRecovery ID="PasswordRecovery1"  Font-Size="Small" OnSendingMail="PasswordRecovery1_SendingMail" OnUserLookupError="PasswordRecovery1_UserLookupError" runat="server">

    </asp:PasswordRecovery>

    <asp:Panel ID="pnlContinue" runat="server" Visible="false">
        <asp:Label ID="lblUserNotFound" runat="server" Text="User Not Found" Visible="false">
        </asp:Label>
        <br />
        <telerik:RadButton ID="rBTNContinue" runat="server" PostBackUrl="Login.aspx" Text="Login" Visible="false"  Skin='<%$ AppSettings:Telerik.Skin %>'>
        </telerik:RadButton>
    </asp:Panel>
</asp:Content>
