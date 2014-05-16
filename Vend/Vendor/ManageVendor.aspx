<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ManageVendor.aspx.cs" Inherits="VolTeer.Volunteer.ManageVendor" %>

<%@ Register Src="~/Common/WebControls/ucVendorProjects.ascx" TagPrefix="uc1" TagName="ucVendorProjects" %>
<%@ Register Src="~/Common/WebControls/ucVendorContacts.ascx" TagPrefix="uc1" TagName="ucVendorContacts" %>
<%@ Register Src="~/Common/WebControls/ucVendorSearch.ascx" TagPrefix="uc1" TagName="ucVendorSearch" %>
<%@ Register Src="~/Common/WebControls/ucAccountMaint.ascx" TagPrefix="uc1" TagName="ucAccountMaint" %>
<%@ Register Src="~/Common/WebControls/ucVendorMail.ascx" TagPrefix="uc1" TagName="ucVendorMail" %>
<%@ Register Src="~/Common/WebControls/ucVendorContact.ascx" TagPrefix="uc1" TagName="ucVendorContact" %>
<%@ Register Src="~/Common/WebControls/ucVendorAddress.ascx" TagPrefix="uc1" TagName="ucVendorAddress" %>









<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <div class="exampleWrapper">
        <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" Height="26px" SelectedIndex="0" Skin='<%$ AppSettings:Telerik.Skin %>'>
            <Tabs>
                <telerik:RadTab Text="Vendor" Height="25px" Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Projects" Height="25px" Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Vendor Contacts" Height="25px" Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Search" Height="25px" Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Account Maint" Height="25px" Width="200px"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>


        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">

            <telerik:RadPageView runat="server" ID="RadPageView1">

                <telerik:RadTabStrip runat="server" ID="RadTabStrip2" MultiPageID="RadMultiPage2"
                    Orientation="VerticalLeft" Skin='<%$ AppSettings:Telerik.Skin %>' Width="100px" Height="475px" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab Height="90px" ImageUrl="../Content/imageLibrary/PNG/mail_32.png"></telerik:RadTab>
                        <telerik:RadTab Height="90px" ImageUrl="../Content/imageLibrary/PNG/phone_32.png"></telerik:RadTab>
                        <telerik:RadTab Height="90px" ImageUrl="../Content/imageLibrary/PNG/addbk_32.png"></telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>

                <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" CssClass="innerMultiPage" Height="100%" Width="90%">
                    <telerik:RadPageView runat="server" ID="PageView1" Height="100%" Width="100%">
                        <uc1:ucVendorMail runat="server" id="ucVendorMail" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView2" Height="100%" Width="100%">
                        <uc1:ucVendorContact runat="server" id="ucVendorContact" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView3" Height="100%" Width="100%">
                        <uc1:ucVendorAddress runat="server" id="ucVendorAddress" />
                    </telerik:RadPageView>

                </telerik:RadMultiPage>

            </telerik:RadPageView>






            <telerik:RadPageView runat="server" ID="RadPageView2">
                <uc1:ucVendorProjects runat="server" ID="ucVendorProjects" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView3">
                <uc1:ucVendorContacts runat="server" ID="ucVendorContacts" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView4">
                <uc1:ucVendorSearch runat="server" ID="ucVendorSearch" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView5">
                <uc1:ucAccountMaint runat="server" ID="ucAccountMaint" />
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
</asp:Content>

