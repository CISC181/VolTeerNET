<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="TestRoles.aspx.cs" Inherits="VolTeer.SampleControls.TestRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server"  ID="lblAdmin" Text="Admin Can See This" Visible="false" >

    </asp:Label>
    <br />

    <asp:label runat="server" ID="lblNonAdmin" Text="Non-admin Can See This" Visible="false"></asp:label>

</asp:Content>
