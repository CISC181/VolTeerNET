<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPrimary.ascx.cs" Inherits="VolTeer.Common.WebControls.ucPrimary" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="pnlPrimaryInfo" runat="server" Width="700px">
    <asp:Table 
        ID="tblPrimaryInfo" 
        runat="server"                 
        BorderWidth="1px"
        Skin="Vista"
        CellSpacing="2" CellPadding="1"
        Style="border-collapse: collapse;" >   
            <asp:TableHeaderRow runat="server" ForeColor="Black" BackColor="AliceBlue" BorderWidth="2" BorderStyle="Ridge"  >  
                <asp:TableHeaderCell BackColor="Azure" Width="220px" Font-Size="Small"> Primary Email </asp:TableHeaderCell>  
                <asp:TableHeaderCell BackColor="Azure" Width="160px" Font-Size="Small"> Primary Phone </asp:TableHeaderCell>  
                <asp:TableHeaderCell BackColor="Azure" Width="320px" Font-Size="Small"> Primary Address </asp:TableHeaderCell>  
            </asp:TableHeaderRow>  
            <asp:TableRow ID="TableRow1" runat="server" ForeColor="Teal" BorderWidth="2" BorderStyle="Ridge" >  
                <asp:TableCell>  
                    <telerik:RadButton ID="PrimaryEmail" runat="server" 
                            ButtonType="SkinnedButton" 
                            CommandName="Find_Emails" 
                            AutoPostBack="true" 
                            OnClick="PrimaryEmail_Click" 
                            CommandArgument='<%# DataBinder.Eval(Container, "DataItem.EmailID") %>'
                            >
                    </telerik:RadButton>
                </asp:TableCell>  
                <asp:TableCell> 
                    <telerik:RadButton ID="PrimaryPhone" runat="server" 
                            ButtonType="SkinnedButton" 
                            CommandName="Find_Phones" 
                            AutoPostBack="true" 
                            OnClick="PrimaryPhone_Click" 
                            CommandArgument='<%# DataBinder.Eval(Container, "DataItem.PhoneID") %>'
                            >
                     </telerik:RadButton>
                </asp:TableCell>  
                <asp:TableCell> 
                    <telerik:RadButton ID="PrimaryAddress" runat="server" 
                            ButtonType="SkinnedButton" 
                            CommandName="Find_Adrresses" 
                            AutoPostBack="true" 
                            OnClick="PrimaryAddress_Click"
                            CommandArgument='<%# DataBinder.Eval(Container, "DataItem.AddressID") %>'
                            >
                      </telerik:RadButton>
                </asp:TableCell>  
            </asp:TableRow>  
        </asp:Table>     
</asp:Panel>
