<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="VolunterInfo.aspx.cs" Inherits="VolTeer.Volunteer.VolunterInfo" %>

<%@ Register TagPrefix="uc" TagName="VolBasicInfo" Src="~/Common/WebControls/ucVolBasicInfo.ascx" %>
<%@ Register TagPrefix="uc" TagName="VolAddress" Src="~/Common/WebControls/ucAddress.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rTSVolunteer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rMPVolunteer" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="rGridAddress" LoadingPanelID="RadAjaxLoadingPanel1" />

                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
    <telerik:RadTabStrip runat="server"
        ID="rTSVolunteer" Width="90%"
        AutoPostBack="True"
        MultiPageID="rMPVolunteer"
        SelectedIndex="2" Skin='<%$ AppSettings:Telerik.Skin %>'>
        <Tabs>
            <telerik:RadTab Text="Demographics" Value="1" Font-Bold="true" Width="200px"></telerik:RadTab>
            <telerik:RadTab Text="Skills" Value="2" Font-Bold="true" Width="200px"></telerik:RadTab>
            <telerik:RadTab Text="History" Value="3" Font-Bold="true" Width="200px" Selected="True"></telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="rMPVolunteer" SelectedIndex="0">
        <telerik:RadPageView runat="server" ID="rPVBasic" Height="400px" BorderStyle="Solid" BorderWidth="1px">
            <asp:HiddenField ID="hdVolID" runat="server" />
            <asp:HiddenField ID="hdEditView" runat="server" />
            <uc:VolBasicInfo ID="ucVolBasicInfo" runat="server" />
            <uc:VolAddress ID="ucVolAddress" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rPVSkills" Height="400px" BorderStyle="Solid" BorderWidth="1px">
            Skills
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rPVHistory" Height="400px" BorderStyle="Solid" BorderWidth="1px">
            History
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <telerik:RadButton ID="RadButton1" runat="server" OnClick="RadButton1_Click" Text="RadButton"></telerik:RadButton>


    <asp:Panel ID="pnlError" runat="server" Visible="false">
        <table id="tblError" runat="server" visible="false">
        </table>
    </asp:Panel>

</asp:Content>
