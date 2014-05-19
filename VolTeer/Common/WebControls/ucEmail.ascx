<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEmail.ascx.cs" Inherits="VolTeer.Common.WebControls.ucEmail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Panel ID="pnlEmailGrid" runat="server" Width="90%">

    <telerik:RadGrid ID="rGridEmail"
        runat="server"
        OnNeedDataSource="rGridEmail_NeedDataSource"
        OnItemDataBound="rGridEmail_ItemDataBound"
        OnUpdateCommand="rGridEmail_UpdateCommand"
        OnInsertCommand="rGridEmail_InsertCommand"
        OnDeleteCommand="rGridEmail_DeleteCommand"
        AutoGenerateColumns="False"
        BorderWidth="1px"
        AllowFilteringByColumn="True"
        AllowSorting="True"
        Skin='<%$ AppSettings:Telerik.Skin %>'
        CellSpacing="0"
        GridLines="None"
        AllowMultiRowEdit="True"
        AllowMultiRowSelection="True">
        <GroupingSettings CaseSensitive="False" />
        <MasterTableView DataKeyNames="EmailID"
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

<%--                 <telerik:GridCheckBoxColumn DataField="PrimaryFlg" HeaderText="PrimaryFlg" DataType="System.Boolean" FilterControlAltText="Filter column2 column" UniqueName="PrimaryFlg">
                </telerik:GridCheckBoxColumn>--%>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="PrimaryFlg" DataField="PrimaryFlg" UniqueName="PrimaryFlg">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkPrimaryFlg" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.PrimaryFlg") %>'></asp:CheckBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="EmailAddr" DataField="EmailAddr" UniqueName="EmailAddr">
                    <ItemTemplate>
                        <asp:Label ID="EmailAddr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EmailAddr") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
               

                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Are you sure you want to delete this?" ButtonType="ImageButton" />

            </Columns>

            <EditFormSettings EditFormType="Template">
                <EditColumn UniqueName="EditCommandColumn1" ButtonType="PushButton" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>
                <FormTemplate>
                    <asp:Table ID="tblEnterEmail" runat="server" CellSpacing="2" CellPadding="1" Width="100%"
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
                                <asp:Label ID="lblEmail" runat="server" Text="Email">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="rTBEmail" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EmailAddr") %>'>
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

