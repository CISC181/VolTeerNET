<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ManageSkills.aspx.cs" Inherits="VolTeer.Skills.ManageSkills" %>

<%@ Register TagPrefix="uc" TagName="Spinner" 
    Src="~/Common/WebControls/ucSkill.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

        <uc:Spinner id="Spinner1" 
        runat="server" />

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AspNetProviderConnectionString %>" SelectCommand="SELECT * FROM [vw_aspnet_Applications]"></asp:SqlDataSource>

</asp:Content>
