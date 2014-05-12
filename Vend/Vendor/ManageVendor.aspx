<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ManageVendor.aspx.cs" Inherits="VolTeer.Volunteer.ManageVendor" %>

<%@ Register Src="~/Common/WebControls/ucVendorProjects.ascx" TagPrefix="uc1" TagName="ucVendorProjects" %>
<%@ Register Src="~/Common/WebControls/ucVendorContacts.ascx" TagPrefix="uc1" TagName="ucVendorContacts" %>
<%@ Register Src="~/Common/WebControls/ucVendorSearch.ascx" TagPrefix="uc1" TagName="ucVendorSearch" %>
<%@ Register Src="~/Common/WebControls/ucAccountMaint.ascx" TagPrefix="uc1" TagName="ucAccountMaint" %>





<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <div class="exampleWrapper">
        <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Web20">
            <Tabs>
                <telerik:RadTab Text="Projects"></telerik:RadTab>
                <telerik:RadTab Text="Vendor Contacts"></telerik:RadTab>
                <telerik:RadTab Text="Search"></telerik:RadTab>
                <telerik:RadTab Text="Account Maint"></telerik:RadTab>

            </Tabs>
        </telerik:RadTabStrip>


        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView runat="server" ID="RadPageView1">
                <uc1:ucVendorProjects runat="server" id="ucVendorProjects" />
            </telerik:RadPageView>


            <telerik:RadPageView runat="server" ID="RadPageView2">
               <uc1:ucVendorContacts runat="server" id="ucVendorContacts" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView3">
                <uc1:ucVendorSearch runat="server" id="ucVendorSearch" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView4">
                <uc1:ucAccountMaint runat="server" id="ucAccountMaint" />
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
</asp:Content>

