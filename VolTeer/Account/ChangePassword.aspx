<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="VolTeer.Account.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="groupWrapper">
        <asp:ChangePassword ID="ChangePassword1" 
            runat="server" 
            Width="385px" ChangePasswordTitleText="Change Password"
            TitleTextStyle-CssClass="PasswordChangeTitle" 
            SuccessTitleText="Your password has changed."
            EnableViewState="false" 
            OnContinueButtonClick="ChangePassword1_ContinueButtonClick" 
            OnCancelButtonClick="ChangePassword1_CancelButtonClick"            
            OnChangingPassword="ChangePassword1_ChangingPassword">
        </asp:ChangePassword>
        <asp:Label ID="LabelChangePassword" Text="" Font-Size="Large" ForeColor="Green" runat="server"></asp:Label>
    </div>
</asp:Content>
