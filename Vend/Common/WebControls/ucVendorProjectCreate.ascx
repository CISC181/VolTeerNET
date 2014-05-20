<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVendorProjectCreate.ascx.cs" Inherits="Vend.Common.WebControls.ucVendorProjectCreate" %>

<div>
    <br />
    <br />
    <br />
    <asp:Panel ID="projectCreation" runat="server" Height="100%" Width="100%" CssClass="exampleWrapper">
        <asp:Table ID="projCreateForm" runat="server" Height="100%" Width="100%">
            <asp:TableRow>
                <asp:TableCell>
                    <div style="margin-left: auto; margin-right: auto; text-align: right;">
                        <asp:Label ID="lblProjName" runat="server" Text="Project Name"></asp:Label>
                    </div>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadTextBox ID="rTBProjName" runat="server" Width="300px" EmptyMessage="Enter Project Name">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <div style="margin-left: auto; margin-right: auto; text-align: right;">
                        <asp:Label ID="lblProjDesc" runat="server" Text="Project Description"></asp:Label>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="(max 500 char)"></asp:Label>
                    </div>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadTextBox ID="rTBProjDesc" runat="server" AutoCompleteType="None" MaxLength="500"
                        Height="150px" Width="300px" EmptyMessage="Enter Description Name">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="addrHead" runat="server" Text="Address Information" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <div style="margin-left: auto; margin-right: auto; text-align: right;">
                        <asp:Label ID="addrLine1" runat="server" Text="Address Line 1: "></asp:Label>
                    </div>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadTextBox ID="addrLine1Box" runat="server" Width="300px" EmptyMessage="Enter Address Line 1 Here">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <div style="margin-left: auto; margin-right: auto; text-align: right;">
                        <asp:Label ID="addrLine2" runat="server" Text="Address Line 2: "></asp:Label>
                    </div>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadTextBox ID="addrLine2Box" runat="server" Width="300px" EmptyMessage="Enter Address Line 2 Here">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <div style="margin-left: auto; margin-right: auto; text-align: right;">
                        <asp:Label ID="addrLine3" runat="server" Text="Address Line 3: "></asp:Label>
                    </div>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadTextBox ID="addrLine3Box" runat="server" Width="300px" EmptyMessage="Enter Address Line 2 Here">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</div>

