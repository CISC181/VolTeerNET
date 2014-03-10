<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataManipulation.aspx.cs" Inherits="VolTeer.SampleControls.DataManipulation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <br />
            <telerik:RadGrid ID="RadGrid1" OnNeedDataSource="RadGrid1_NeedDataSource" MasterTableView-DataKeyNames="RoleID" OnItemCommand="RadGrid1_ItemCommand" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None">
                <MasterTableView>
                    <Columns>
                        <%--                    <telerik:GridButtonColumn CommandArgument='<%# Bind("RoleID") %>' CommandName="Delete" FilterControlAltText="Filter column column" Text="Delete" UniqueName="column">
                    </telerik:GridButtonColumn>--%>

                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("RoleName")%>' CommandName="Delete" Text="Delete">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridBoundColumn DataField="ApplicationId" FilterControlAltText="Filter column1 column" UniqueName="column1">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Description" FilterControlAltText="Filter column2 column" UniqueName="column2">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LoweredRoleName" FilterControlAltText="Filter column3 column" UniqueName="column3">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RoleId" FilterControlAltText="Filter column4 column" UniqueName="column4">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RoleName" FilterControlAltText="Filter column5 column" UniqueName="column5">
                        </telerik:GridBoundColumn>

                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>

            <br />
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblRoleAdd" runat="server" Text="Add Role"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadTextBox ID="txtRole" runat="server" EmptyMessage="Enter RoleName"></telerik:RadTextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadButton ID="btnAddRole" runat="server" OnClick="btnAddRole_Click"></telerik:RadButton>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
