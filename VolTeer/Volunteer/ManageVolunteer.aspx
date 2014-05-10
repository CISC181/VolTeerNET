<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ManageVolunteer.aspx.cs" Inherits="VolTeer.Volunteer.ManageVolunteer" %>

<%@ Register TagPrefix="uc" TagName="ucSkill"
    Src="~/Common/WebControls/ucSkillSearch.ascx" %>
<%@ Register Src="~/Common/WebControls/ucAddress.ascx" TagPrefix="uc" TagName="ucAddress" %>
<%@ Register Src="~/Common/WebControls/ucPrimary.ascx" TagPrefix="uc" TagName="ucPrimary" %>
<%@ Register Src="~/Common/WebControls/ucGroups.ascx" TagPrefix="uc" TagName="ucGroups" %>
<%@ Register Src="~/Common/WebControls/ucEmail.ascx" TagPrefix="uc" TagName="ucEmail" %>
<%@ Register Src="~/Common/WebControls/ucGroupVolInvite.ascx" TagPrefix="uc" TagName="ucGroupVolInvite" %>





<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <div class="exampleWrapper">
        <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" Height="26px" SelectedIndex="0" Skin='<%$ AppSettings:Telerik.Skin %>'>
            <Tabs>
                <telerik:RadTab Text="Home" ImageUrl="../Content/imageLibrary/PNG/home_16.png" Height="26px"  Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Groups" ImageUrl="../Content/imageLibrary/PNG/group_16.png" Height="26px"  Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Skills" ImageUrl="../Content/imageLibrary/PNG/paint_16.png" Height="26px"  Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="History" ImageUrl="../Content/imageLibrary/PNG/hist_16.png" Height="26px"  Width="200px"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>


        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" Width="95%" Height="95%" CssClass="outerMultiPage">
            <telerik:RadPageView runat="server" ID="RadPageView1">

                <telerik:RadTabStrip runat="server" ID="RadTabStrip2" MultiPageID="RadMultiPage2"
                    Orientation="VerticalLeft" Skin='<%$ AppSettings:Telerik.Skin %>' Width="100px" Height="475px" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab Height="90px" ImageUrl="../Content/imageLibrary/PNG/about_32.png"></telerik:RadTab>
                        <telerik:RadTab Height="90px" ImageUrl="../Content/imageLibrary/PNG/mail_32.png"></telerik:RadTab>
                        <telerik:RadTab Height="90px" ImageUrl="../Content/imageLibrary/PNG/phone_32.png"></telerik:RadTab>
                        <telerik:RadTab Height="90px" ImageUrl="../Content/imageLibrary/PNG/addbk_32.png"></telerik:RadTab>
                        <telerik:RadTab Height="90px" ImageUrl="../Content/imageLibrary/PNG/user_32.png"></telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>

                <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" CssClass="innerMultiPage" Height="100%" Width="90%">
                    <telerik:RadPageView runat="server" ID="PageView1" Height="100%" Width="100%">
                        <uc:ucPrimary runat="server" ID="ucPrimary" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView2" Height="100%" Width="100%">
                        <uc:ucEmail runat="server" ID="ucEmail" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView3" Height="100%" Width="100%">
                        <asp:Label ID="Label1" runat="server" Text="Fix Phone"></asp:Label>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView4" Height="100%" Width="100%">
                        <uc:ucAddress runat="server" ID="ucAddress" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView5" Height="100%" Width="100%">
                        <asp:Label ID="Label3" runat="server" Text="Fix Account"></asp:Label>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </telerik:RadPageView>


            <telerik:RadPageView runat="server" ID="RadPageView2">
                <telerik:RadTabStrip runat="server" ID="RadTabStrip3" MultiPageID="RadMultiPage5"
                    Orientation="VerticalLeft" Skin='<%$ AppSettings:Telerik.Skin %>' Width="150px" Height="475px" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab Text="My Groups"></telerik:RadTab>
                        <telerik:RadTab Text="Create Group"></telerik:RadTab>
                        <telerik:RadTab Text="Invite To Group"></telerik:RadTab>
                        <telerik:RadTab Text="Search for Groups"></telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>

                <telerik:RadMultiPage runat="server" ID="RadMultiPage5" SelectedIndex="0" Height="475px" CssClass="innerMultiPage">
                    <telerik:RadPageView runat="server" ID="RadPageView5">
                        <uc:ucGroups runat="server" ID="ucGroups" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView6">
                        Create a Group
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView8">
                        <uc:ucGroupVolInvite runat="server" ID="ucGroupVolInvite" />
                    </telerik:RadPageView>



                    <telerik:RadPageView runat="server" ID="RadPageView7">
                        Search for Groups
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" Height="475px" ID="RadPageView3">
                <uc:ucSkill ID="ucSkills" runat="server" />
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" Height="475px" ID="RadPageView4">
                My History
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
</asp:Content>

