<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPrimary.ascx.cs" Inherits="VolTeer.Common.WebControls.ucPrimary" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="pnlPrimaryInfo" runat="server" Width="90%">
    <telerik:RadButton ID="PrimaryEmail" runat="server" 
                            ButtonType="SkinnedButton" 
                            CommandName="Find_Emails" 
                            AutoPostBack="true" 
                            OnClick="PrimaryEmail_Click" 
                            CommandArgument='<%# DataBinder.Eval(Container, "DataItem.EmailID") %>'
                            >
    </telerik:RadButton>
    <telerik:RadButton ID="PrimaryPhone" runat="server" 
                            ButtonType="SkinnedButton" 
                            CommandName="Find_Phones" 
                            AutoPostBack="true" 
                            OnClick="PrimaryPhone_Click" 
                            CommandArgument='<%# DataBinder.Eval(Container, "DataItem.PhoneID") %>'
                            >
    </telerik:RadButton>
    <telerik:RadButton ID="PrimaryAddress" runat="server" 
                            ButtonType="SkinnedButton" 
                            CommandName="Find_Adrresses" 
                            AutoPostBack="true" 
                            OnClick="PrimaryAddress_Click"
                            CommandArgument='<%# DataBinder.Eval(Container, "DataItem.AddressID") %>'
                            >
    </telerik:RadButton>
</asp:Panel>
