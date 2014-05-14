<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ManageSkills.aspx.cs" Inherits="VolTeer.SampleControls.ManageSkills" %>

<%@ Register Src="~/Common/WebControls/ucSkillsManage.ascx" TagPrefix="uc1" TagName="ucSkillsManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:ucSkillsManage runat="server" id="ucSkillsManage" />
</asp:Content>
