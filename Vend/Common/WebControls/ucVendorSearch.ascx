<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVendorSearch.ascx.cs" Inherits="Vend.Common.WebControls.ucVendorSearch" %>

 <asp:Panel ID="pnlVendorSearch" Visible="false" runat="server">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
            <label for="RadAutoCompleteBox1">Find Volunteers:</label>
            <telerik:RadAutoCompleteBox ID="rACSkills"
                runat="server"
                Width="674px"
                DropDownWidth="400"
                DropDownHeight="150"
                AllowCustomEntry="true"
                EmptyMessage="Find a Volunteer"
                Height="35px">
            </telerik:RadAutoCompleteBox>
            <br />
            <telerik:RadButton ID="rBTNProcess" runat="server" Text="Search" OnClick="rBTNSearch_Click">
            </telerik:RadButton>
        </telerik:RadAjaxPanel>
    </asp:Panel>