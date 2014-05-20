<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVendorProjectCreate.ascx.cs" Inherits="Vend.Common.WebControls.ucVendorProjectCreate" %>

<link href="../../Content/CustomCSS.css" rel="stylesheet" type="text/css" />

<div style="margin-left: 20px; margin-top: 20px">
    <asp:Panel ID="projectCreation" runat="server" Height="100%" Width="800px" CssClass="ucForm">
        <asp:Table ID="projCreateForm" runat="server" Height="100%" Width="100%">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="newProjTitle" runat="server" Text="New Project" CssClass="formSectionTitle" />
                    <br />
                    <br />
                    <br />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblProjName" runat="server" Text="Project Name: " CssClass="formBoxLabel"></asp:Label>
                </asp:TableCell><asp:TableCell>
                    <telerik:RadTextBox ID="rTBProjName" runat="server" Width="300px" EmptyMessage="Enter Project Name">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblProjDesc" runat="server" Text="Project Description: " CssClass="formBoxLabel"></asp:Label>
                    <div style="margin-right: 30px; font-size: 10px;">
                        <asp:Label ID="lblCharMax" runat="server" Text="(max 500 char) " CssClass="formBoxLabel"></asp:Label>
                    </div>
                </asp:TableCell><asp:TableCell>
                    <telerik:RadTextBox ID="rTBProjDesc" runat="server" AutoCompleteType="None" MaxLength="500"
                        Height="150px" Width="300px" EmptyMessage="Enter Description Here">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="addrHead" runat="server" Text="Address Information" CssClass="formSectionTitle" />
                    <br />
                    <br />
                    <br />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="addrLine1" runat="server" Text="Address: " CssClass="formBoxLabel"></asp:Label>
                </asp:TableCell><asp:TableCell>
                    <telerik:RadTextBox ID="addrLine1Box" runat="server" Width="300px" EmptyMessage="Enter Address Line 1 Here">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <div style="margin-left: auto; margin-right: auto; text-align: right;">
                        <asp:Label ID="addrLine2" runat="server" Text=""></asp:Label>
                    </div>
                </asp:TableCell><asp:TableCell>
                    <telerik:RadTextBox ID="addrLine2Box" runat="server" Width="300px" EmptyMessage="Enter Address Line 2 Here">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="addrLine3" runat="server" Text=""></asp:Label>
                </asp:TableCell><asp:TableCell>
                    <telerik:RadTextBox ID="addrLine3Box" runat="server" Width="300px" EmptyMessage="Enter Address Line 2 Here">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblProjCity" runat="server" Text="City: " CssClass="formBoxLabel"></asp:Label>
                </asp:TableCell><asp:TableCell>
                    <telerik:RadTextBox ID="rTBProjCity" runat="server" Width="300px" EmptyMessage="Enter City Name Here">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblProjState" runat="server" Text="State: " CssClass="formBoxLabel"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadComboBox ID="rCBState" runat="server" Width="300px">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Alabama" />
                            <telerik:RadComboBoxItem runat="server" Text="Alaska" />
                            <telerik:RadComboBoxItem runat="server" Text="Arizona" />
                            <telerik:RadComboBoxItem runat="server" Text="Arkansas" />
                            <telerik:RadComboBoxItem runat="server" Text="California" />
                            <telerik:RadComboBoxItem runat="server" Text="Colorado" />
                            <telerik:RadComboBoxItem runat="server" Text="Connecticut" />
                            <telerik:RadComboBoxItem runat="server" Text="Delaware" />
                            <telerik:RadComboBoxItem runat="server" Text="Florida" />
                            <telerik:RadComboBoxItem runat="server" Text="Georgia" />
                            <telerik:RadComboBoxItem runat="server" Text="Hawaii" />
                            <telerik:RadComboBoxItem runat="server" Text="Idaho" />
                            <telerik:RadComboBoxItem runat="server" Text="Illinois" />
                            <telerik:RadComboBoxItem runat="server" Text="Indiana" />
                            <telerik:RadComboBoxItem runat="server" Text="Iowa" />
                            <telerik:RadComboBoxItem runat="server" Text="Kansas" />
                            <telerik:RadComboBoxItem runat="server" Text="Kentucky" />
                            <telerik:RadComboBoxItem runat="server" Text="Louisiana" />
                            <telerik:RadComboBoxItem runat="server" Text="Maine" />
                            <telerik:RadComboBoxItem runat="server" Text="Maryland" />
                            <telerik:RadComboBoxItem runat="server" Text="Massachusetts" />
                            <telerik:RadComboBoxItem runat="server" Text="Michigan" />
                            <telerik:RadComboBoxItem runat="server" Text="Minnesota" />
                            <telerik:RadComboBoxItem runat="server" Text="Mississippi" />
                            <telerik:RadComboBoxItem runat="server" Text="Missouri" />
                            <telerik:RadComboBoxItem runat="server" Text="Montana" />
                            <telerik:RadComboBoxItem runat="server" Text="Nebraska" />
                            <telerik:RadComboBoxItem runat="server" Text="Nevada" />
                            <telerik:RadComboBoxItem runat="server" Text="New Hampshire" />
                            <telerik:RadComboBoxItem runat="server" Text="New Jersey" />
                            <telerik:RadComboBoxItem runat="server" Text="New Mexico" />
                            <telerik:RadComboBoxItem runat="server" Text="New York" />
                            <telerik:RadComboBoxItem runat="server" Text="North Carolina" />
                            <telerik:RadComboBoxItem runat="server" Text="North Dakota" />
                            <telerik:RadComboBoxItem runat="server" Text="Ohio" />
                            <telerik:RadComboBoxItem runat="server" Text="Oklahoma" />
                            <telerik:RadComboBoxItem runat="server" Text="Oregon" />
                            <telerik:RadComboBoxItem runat="server" Text="Pennsylvania" />
                            <telerik:RadComboBoxItem runat="server" Text="Rhode Island" />
                            <telerik:RadComboBoxItem runat="server" Text="South Carolina" />
                            <telerik:RadComboBoxItem runat="server" Text="South Dakota" />
                            <telerik:RadComboBoxItem runat="server" Text="Tennessee" />
                            <telerik:RadComboBoxItem runat="server" Text="Texas" />
                            <telerik:RadComboBoxItem runat="server" Text="Utah" />
                            <telerik:RadComboBoxItem runat="server" Text="Vermont" />
                            <telerik:RadComboBoxItem runat="server" Text="Virginia" />
                            <telerik:RadComboBoxItem runat="server" Text="Washington" />
                            <telerik:RadComboBoxItem runat="server" Text="West Virginia" />
                            <telerik:RadComboBoxItem runat="server" Text="Wisconsin" />
                            <telerik:RadComboBoxItem runat="server" Text="Wyoming" />
                        </Items>
                    </telerik:RadComboBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</div>
