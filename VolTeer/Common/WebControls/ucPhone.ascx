<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhone.ascx.cs" Inherits="VolTeer.Common.WebControls.ucPhone" %>
<asp:Panel ID="pnlSinglePhone" runat="server">
    <asp:Table ID="tblMainTable" runat="server" Height="16px">
        <asp:TableRow>
            <asp:TableCell ID="TableCell1" runat="server" Width="40%">
                <asp:Table ID="tblViewPrimPhone" runat="server" CellSpacing="0" CellPadding="1" Width="100%"
                    Style="border-collapse: collapse;">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblPhone1" runat="server"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="rowPhone2">
                        <asp:TableCell>
                            <asp:Label ID="lblPhone2" runat="server"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ID="rowPhone3">
                            <asp:Label ID="lblPhone3" runat="server"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Panel>
<asp:Panel ID="pnlPhoneGrid" runat="server">
    <telerik:RadGrid ID="rGridPhone"
        runat="server"
        OnNeedDataSource="rGridPhone_NeedDataSource"
        OnItemDataBound="rGridPhone_ItemDataBound"
        OnUpdateCommand="rGridPhone_UpdateCommand"
        OnInsertCommand="rGridPhone_InsertCommand"
        OnDeleteCommand="rGridPhone_DeleteCommand"
        AutoGenerateColumns="False"
        BorderWidth="1px"
        AllowFilteringByColumn="True"
        AllowSorting="True"
        Skin="Vista"
        AllowMultiRowEdit="True"
        AllowMultiRowSelection="True">
        <GroupingSettings CaseSensitive="False" />
        <MasterTableView DataKeyNames="PhoneID"
            CommandItemDisplay="Bottom"
            EditMode="EditForms"
            EnableHeaderContextAggregatesMenu="True"
            EnableHeaderContextFilterMenu="True"
            EnableHeaderContextMenu="True">
            <Columns>
                <telerik:GridEditCommandColumn HeaderText="Action" ButtonType="ImageButton">
                </telerik:GridEditCommandColumn>
                <telerik:GridCheckBoxColumn DataField="ActiveFlg" HeaderText="Active" DataType="System.Boolean" FilterControlAltText="Filter column1 column" UniqueName="ActiveFlg">
                </telerik:GridCheckBoxColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="PrimaryFlg" DataField="PrimaryFlg" UniqueName="PrimaryFlg">
                    <ItemTemplate>
                        <asp:CheckBox ID="PrimaryFlg" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.PrimaryFlg") %>'></asp:CheckBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn DataField="PhoneNbr" FilterControlAltText="Filter TemplateColumn column" HeaderText="PhoneNbr" UniqueName="PhoneNbr">
                    <ItemTemplate>
                        <asp:Label ID="PhoneNbr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PhoneNbr") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Are you sure you want to delete this?" ButtonType="ImageButton" />
            </Columns>
            <EditFormSettings EditFormType="Template">
                <EditColumn UniqueName="EditCommandColumn1" ButtonType="PushButton" FilterControlAltText="Filter EditCommandColumn1 column">
                </EditColumn>
                <FormTemplate>
                    <asp:Table ID="tblEnterPhone0" runat="server" CellSpacing="2" CellPadding="1" Width="100%"
                        Style="border-collapse: collapse;">
                        <asp:TableRow>
                            <asp:TableCell Width="10%">
                                <asp:Label ID="lblActive" runat="server" Text="Active">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:CheckBox ID="chkActive" runat="server" ></asp:CheckBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Width="10%">
                                <asp:Label ID="lblPrimary" runat="server" Text="PrimaryFlg">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:CheckBox ID="chkPrimaryFlg" runat="server" ></asp:CheckBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Width="10%">
                                <asp:Label ID="lblPhone" runat="server" Text="Phone">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="rTBPhone" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PhoneNbr") %>'>
                                </telerik:RadTextBox>
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





