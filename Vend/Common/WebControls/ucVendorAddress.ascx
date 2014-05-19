<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVendorAddress.ascx.cs" Inherits="Vend.Common.WebControls.ucVendorAddress" %>

<asp:Panel ID="pnlSingleAddress" runat="server" Width="90%" >
    <asp:Table ID="tblMainTable" runat="server">
        <asp:TableRow>
            <asp:TableCell ID="TableCell1" runat="server" Width="40%">
                <asp:Table ID="tblViewPrimAddr" runat="server" CellSpacing="0" CellPadding="1" Width="100%"
                    Style="border-collapse: collapse;">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblAddr1" runat="server"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="rowAddr2">
                        <asp:TableCell>
                            <asp:Label ID="lblAddr2" runat="server"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="rowAddr3">
                            <asp:Label ID="lblAddr3" runat="server"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblCityStZip" runat="server"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="tblButtons" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <telerik:RadButton ID="btnEdit" Skin='<%$ AppSettings:Telerik.Skin %>' runat="server" Text="Edit" OnClick="btnEdit_Click">
                </telerik:RadButton>
                &nbsp;
            <telerik:RadButton ID="btnCancel" Skin='<%$ AppSettings:Telerik.Skin %>' runat="server" Text="Cancel" OnClick="btnCancel_Click">
            </telerik:RadButton>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Panel>

<asp:Panel ID="pnlAddressGrid" runat="server" CssClass="exampleWrapper" Width="90%" Height="200px">

    <telerik:RadGrid ID="rGridAddress"
        runat="server"
        OnNeedDataSource="rGridAddress_NeedDataSource"
        OnItemDataBound="rGridAddress_ItemDataBound"
        OnUpdateCommand="rGridAddress_UpdateCommand"
        OnInsertCommand="rGridAddress_InsertCommand"
        OnDeleteCommand="rGridAddress_DeleteCommand"
        AutoGenerateColumns="False"
        AllowFilteringByColumn="False"
        AllowSorting="True"
        Skin='<%$ AppSettings:Telerik.Skin %>'
        CellSpacing="0"
        GridLines="None" 
        OnPreRender="rGridAddress_PreRender"
        AllowMultiRowEdit="True"
        AllowMultiRowSelection="True">
        <GroupingSettings CaseSensitive="False" />
        <MasterTableView DataKeyNames="AddrID"
            CommandItemDisplay="Bottom"
            EditMode="EditForms"
            EnableHeaderContextAggregatesMenu="True"
            EnableHeaderContextFilterMenu="True"
            EnableHeaderContextMenu="True">
  
            <Columns>
             
                <telerik:GridCheckBoxColumn DataField="ActiveFlg" HeaderText="Active" DataType="System.Boolean" FilterControlAltText="Filter column1 column" UniqueName="ActiveFlg">
                </telerik:GridCheckBoxColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Address 1" DataField="AddrLine1" UniqueName="AddrLine1">
                    <ItemTemplate>
                        <asp:Label ID="lblAddressLine1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Address 2" DataField="AddrLine2" UniqueName="AddrLine2">
                    <ItemTemplate>
                        <asp:Label ID="lblAddressLine2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Address 3" DataField="AddrLine3" UniqueName="AddrLine3">
                    <ItemTemplate>
                        <asp:Label ID="lblAddressLine3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine3") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="City" DataField="City" UniqueName="City">
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.City") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="State" DataField="ST" UniqueName="ST">
                    <ItemTemplate>
                        <asp:Label ID="lblST" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ST") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="ZIP" DataField="ZIP" UniqueName="ZIP">
                    <ItemTemplate>
                        <asp:Label ID="lblZIP" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ZIP") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="ZIP4" DataField="ZIP4" UniqueName="ZIP4">
                    <ItemTemplate>
                        <asp:Label ID="lblZIP4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ZIP4") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Are you sure you want to delete this?" ButtonType="ImageButton" />

            </Columns>
            <EditFormSettings EditFormType="Template">
                <EditColumn UniqueName="EditCommandColumn1" ButtonType="PushButton" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>
                <FormTemplate>
                    <asp:Table ID="tblEnterAddress" runat="server" CellSpacing="2" CellPadding="1" Width="100%"
                        Style="border-collapse: collapse;">
                        <asp:TableRow>
                            <asp:TableCell Width="10%">
                                <asp:Label ID="lblActive" runat="server" Text="Active">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:CheckBox ID="chkActive" runat="server"></asp:CheckBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Width="10%">
                                <asp:Label ID="lblAddressLine1" runat="server" Text="Address Line">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="rTBAddr1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine1") %>'>
                                </telerik:RadTextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblAddressLine2" runat="server">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="rTBAddr2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine2") %>'>
                                </telerik:RadTextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblAddressLine3" runat="server">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="rTBAddr3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine3") %>'>
                                </telerik:RadTextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblCity" runat="server" Text="City / St / Zip">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="rTBCity" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.City") %>'>
                                </telerik:RadTextBox>
                                &nbsp;
                                <telerik:RadDropDownList ID="rDDSt" DropDownHeight="100px" runat="server">
                                </telerik:RadDropDownList>
                                &nbsp;
                                
                                <telerik:RadNumericTextBox ID="rNTBZip" runat="server" Type="Number" MinValue="0" MaxValue="99999" Width="45px"
                                    ValidationGroup="Group1" Text='<%# DataBinder.Eval(Container, "DataItem.Zip") %>'>
                                    <NumberFormat GroupSeparator="" DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                                &nbsp;
                                <telerik:RadNumericTextBox ID="rNTBZip4" runat="server" MaxValue="9999" Type="Number" Width="40px"
                                    ValidationGroup="Group1" Text='<%# DataBinder.Eval(Container, "DataItem.Zip4") %>'>
                                    <NumberFormat GroupSeparator="" DecimalDigits="0" />

                                </telerik:RadNumericTextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>

                            <asp:TableCell ColumnSpan="2">
                                <telerik:RadButton ID="btnUpdate" Text='<%# (Container is GridEditFormInsertItem) ? "Insert" : "Update" %>'
                                    runat="server" ButtonType="SkinnedButton" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                </telerik:RadButton>
                                &nbsp;
                                <telerik:RadButton ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" ButtonType="SkinnedButton"
                                    CommandName="Cancel">
                                </telerik:RadButton>

                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </FormTemplate>
            </EditFormSettings>

        </MasterTableView>
    </telerik:RadGrid>
</asp:Panel>



