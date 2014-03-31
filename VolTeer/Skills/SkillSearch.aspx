<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="SkillSearch.aspx.cs" Inherits="VolTeer.Skills.SkillSearch" %>
<%@ Register TagPrefix="uc" TagName="ucSkill"
    Src="~/Common/WebControls/ucSkillSearch.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <uc:ucSkill ID="ucSkills"
        runat="server" />

</asp:Content>
