<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="EditSkills.aspx.cs" Inherits="VolTeer.Skills.EditSkills" %>

<%@ Register TagPrefix="uc" TagName="ucSkill"
    Src="~/Common/WebControls/ucEditSkill.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="../Common/JavaScripts/TreeScripts.js" ></script>


    <uc:ucSkill ID="ucSkills"
        runat="server" />


</asp:Content>
