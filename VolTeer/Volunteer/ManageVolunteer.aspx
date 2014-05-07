<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ManageVolunteer.aspx.cs" Inherits="VolTeer.Volunteer.ManageVolunteer" %>

<%@ Register TagPrefix="uc" TagName="ucSkill"
    Src="~/Common/WebControls/ucSkillSearch.ascx" %>
<%@ Register Src="~/Common/WebControls/ucAddress.ascx" TagPrefix="uc" TagName="ucAddress" %>
<%@ Register Src="~/Common/WebControls/ucPrimary.ascx" TagPrefix="uc" TagName="ucPrimary" %>
<%@ Register Src="~/Common/WebControls/ucGroups.ascx" TagPrefix="uc" TagName="ucGroups" %>
<%@ Register Src="~/Common/WebControls/ucEmail.ascx" TagPrefix="uc" TagName="ucEmail" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <div class="exampleWrapper">
        <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="0"  Skin='<%$ AppSettings:Telerik.Skin %>'>
            <Tabs>
                <telerik:RadTab Text="Primary Info" Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Groups" Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Skills" Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="History" Width="200px" ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>


        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" Width="95%" Height="95%" CssClass="outerMultiPage">
            <telerik:RadPageView runat="server" ID="RadPageView1">
 
                <telerik:RadTabStrip runat="server" ID="RadTabStrip2" MultiPageID="RadMultiPage2"
                    Orientation="VerticalLeft" Skin='<%$ AppSettings:Telerik.Skin %>' Width="100px" Height="355px" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab Text="Primary"></telerik:RadTab>
                        <telerik:RadTab Text="Email"></telerik:RadTab>
                        <telerik:RadTab Text="Phone"></telerik:RadTab>
                        <telerik:RadTab Text="Address"></telerik:RadTab>
                        <telerik:RadTab Text="Account"></telerik:RadTab>


                        <%--                        <telerik:RadTab ImageUrl="../Content/images/icon_AllRecipes.png" ToolTip="Main Course" SelectedImageUrl="../Content/images/icon_AllRecipes_hover.png" HoveredImageUrl="../Content/images/icon_AllRecipes_hover.png" Height="40px"></telerik:RadTab>
                        <telerik:RadTab ImageUrl="../Content/images/icon_Desserts.png" ToolTip="Desserts" SelectedImageUrl="../Content/images/icon_Desserts_hover.png" HoveredImageUrl="../Content/images/icon_Desserts_hover.png" Height="40px"></telerik:RadTab>
                        <telerik:RadTab ImageUrl="../Content/images/icon_Soups.png" ToolTip="Soups" SelectedImageUrl="../Content/images/icon_Soups_hover.png" HoveredImageUrl="../Content/images/icon_Soups_hover.png" Height="40px"></telerik:RadTab>
                        <telerik:RadTab ImageUrl="../Content/images/icon_Seafood.png" ToolTip="Seafood" SelectedImageUrl="../Content/images/icon_Seafood_hover.png" HoveredImageUrl="../Content/images/icon_Seafood_hover.png" Height="40px"></telerik:RadTab>--%>
                    </Tabs>
                </telerik:RadTabStrip>



                <telerik:RadMultiPage runat="server"  ID="RadMultiPage2" SelectedIndex="0" CssClass="innerMultiPage" Height="100%" Width="90%">
                    <telerik:RadPageView runat="server" ID="PageView1"   Height="100%" Width="100%">
                        <uc:ucPrimary runat="server" ID="ucPrimary" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView2"  Height="100%" Width="100%">
                        <uc:ucEmail runat="server" id="ucEmail" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView3"   Height="100%" Width="100%">
                        <asp:Label ID="Label1" runat="server" Text="Fix Phone"></asp:Label>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView4"  Height="100%" Width="100%">                        
                        <uc:ucAddress runat="server" ID="ucAddress"  />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="PageView5"   Height="100%" Width="100%">
                        <asp:Label ID="Label3" runat="server" Text="Fix Account"></asp:Label>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </telerik:RadPageView>


            <telerik:RadPageView runat="server" ID="RadPageView2">
                <telerik:RadTabStrip runat="server" ID="RadTabStrip3" MultiPageID="RadMultiPage5"
                    Orientation="VerticalLeft" Skin='<%$ AppSettings:Telerik.Skin %>' Width="150px" Height="125px" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab Text="My Groups"></telerik:RadTab>
                        <telerik:RadTab Text="Create Group"></telerik:RadTab>
                        <telerik:RadTab Text="Search for Groups"></telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>

                <telerik:RadMultiPage runat="server" ID="RadMultiPage5" SelectedIndex="0" CssClass="innerMultiPage">
                    <telerik:RadPageView runat="server" ID="RadPageView5">
                        <uc:ucGroups runat="server" id="ucGroups" />
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView6">
                        Create a Group
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView7">
                        Search for Groups
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView3">
                <uc:ucSkill ID="ucSkills" runat="server" />
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="RadPageView4">
                My History
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
</asp:Content>

