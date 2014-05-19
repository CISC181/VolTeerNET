<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ManageVendor.aspx.cs" Inherits="VolTeer.Volunteer.ManageVendor" %>

<%@ Register Src="~/Common/WebControls/ucVendorProjects.ascx" TagPrefix="uc1" TagName="ucVendorProjects" %>
<%@ Register Src="~/Common/WebControls/ucVendorSearch.ascx" TagPrefix="uc1" TagName="ucVendorSearch" %>
<%@ Register Src="~/Common/WebControls/ucVendorMail.ascx" TagPrefix="uc1" TagName="ucVendorMail" %>
<%@ Register Src="~/Common/WebControls/ucVendorContact.ascx" TagPrefix="uc1" TagName="ucVendorContact" %>
<%@ Register Src="~/Common/WebControls/ucVendorAddress.ascx" TagPrefix="uc1" TagName="ucVendorAddress" %>
<%@ Register Src="~/Common/WebControls/ucVendorProfile.ascx" TagPrefix="uc1" TagName="ucVendorProfile" %>

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
                <telerik:RadTab Text="Search" Height="25px" Width="200px"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>


        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">

            <telerik:RadPageView runat="server" ID="RadPageView1">

                <telerik:RadTabStrip runat="server" ID="RadTabStrip2" MultiPageID="RadMultiPage2"
                    Orientation="VerticalLeft" Skin='<%$ AppSettings:Telerik.Skin %>' Width="100px" Height="475px" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab Text="Profile" Height="90px"></telerik:RadTab>
                        <telerik:RadTab Text="Mail" Height="90px"></telerik:RadTab>
                        <telerik:RadTab Text="Contacts" Height="90px"></telerik:RadTab>
                        <telerik:RadTab Text="Address" Height="90px"></telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>

                <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" CssClass="innerMultiPage" Height="100%" Width="90%">
                    <telerik:RadPageView runat="server" ID="PageView1" Height="100%" Width="100%">
                        <uc1:ucVendorProfile runat="server" ID="ucVendorProfile" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView2" Height="100%" Width="100%">
                        <uc1:ucVendorMail runat="server" ID="ucVendorMail" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView3" Height="100%" Width="100%">
                        <uc1:ucVendorContact runat="server" ID="ucVendorContact" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView4" Height="100%" Width="100%">
                        <uc1:ucVendorAddress runat="server" ID="ucVendorAddress" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView2">
                <uc1:ucVendorProjects runat="server" ID="ucVendorProjects" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView3">
                <uc1:ucVendorSearch runat="server" ID="ucVendorSearch" />
            </telerik:RadPageView>

        </telerik:RadMultiPage>
    </div>
</asp:Content>