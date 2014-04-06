<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="SampleAddress.aspx.cs" Inherits="VolTeer.SampleControls.SampleAddress" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadGrid ID="rGridAddress"
        OnDeleteCommand="rGridAddress_DeleteCommand"
        OnInsertCommand="rGridAddress_InsertCommand"
        OnUpdateCommand="rGridAddress_UpdateCommand"
        OnItemDataBound="rGridAddress_ItemDataBound"
        OnNeedDataSource="rGridAddress_NeedDataSource"
        runat="server" 
        AutoGenerateColumns="False" 
        CellSpacing="0" 
        GridLines="None" 
        AllowFilteringByColumn="True" 
        AllowMultiRowEdit="True" 
        AllowMultiRowSelection="True" 
        AllowSorting="True" 
        Skin="Office2010Silver">
        <GroupingSettings CaseSensitive="False" />
        <MasterTableView DataKeyNames="AddrID" CommandItemDisplay="Top" EnableHeaderContextAggregatesMenu="True" EnableHeaderContextFilterMenu="True" EnableHeaderContextMenu="True">
            <Columns>
                <telerik:GridEditCommandColumn HeaderText="Action" ButtonType="ImageButton">
                </telerik:GridEditCommandColumn>
                <telerik:GridBoundColumn DataField="AddrID" FilterControlAltText="Filter column column" Visible="false" ReadOnly="True" UniqueName="AddrID" HeaderText="AddrID">
                </telerik:GridBoundColumn>

                <telerik:GridTemplateColumn DataField="ActiveFlg" FilterControlAltText="Filter TemplateColumn column" UniqueName="ActiveFlg" HeaderText="Active">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkActive" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.ActiveFlg") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="chkActiveUpd" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.ActiveFlg") %>' />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:CheckBox ID="chkActiveIns" runat="server" Checked="true" />
                    </InsertItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="AddrLine1" FilterControlAltText="Filter TemplateColumn1 column" SortAscImageUrl="AddrLine1" UniqueName="AddrLine1" HeaderText="Address Line 1">
                    <ItemTemplate>
                        <asp:Label ID="lblAddrLine1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadTextBox ID="rTXTAddrLine1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine1") %>'>
                        </telerik:RadTextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="AddrLine2" FilterControlAltText="Filter TemplateColumn2 column" UniqueName="AddrLine2" HeaderText="Address Line 2">
                    <ItemTemplate>
                        <asp:Label ID="lblAddrLine2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadTextBox ID="rTXTAddrLine2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine2") %>'>
                        </telerik:RadTextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="AddrLine3" FilterControlAltText="Filter TemplateColumn3 column" UniqueName="AddrLine3" HeaderText="Address Line 3">
                    <ItemTemplate>
                        <asp:Label ID="lblAddrLine3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine3") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadTextBox ID="rTXTAddrLine3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine3") %>'>
                        </telerik:RadTextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="City" FilterControlAltText="Filter TemplateColumn3 column" UniqueName="City" HeaderText="City">
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.City") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadTextBox ID="rTXTCity" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.City") %>'>
                        </telerik:RadTextBox>

                        <asp:RequiredFieldValidator ID="ValCity" ControlToValidate="rTXTCity" runat="server" ErrorMessage="City is required"></asp:RequiredFieldValidator>

                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="St" FilterControlAltText="Filter TemplateColumn3 column" UniqueName="St" HeaderText="State">
                    <ItemTemplate>
                        <asp:Label ID="lblSt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.St") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadDropDownList ID="rDDState" runat="server" DropDownHeight="100px">
                        </telerik:RadDropDownList>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="Zip" FilterControlAltText="Filter TemplateColumn3 column" UniqueName="Zip" HeaderText="Zip">
                    <ItemTemplate>
                        <asp:Label ID="lblZip" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Zip") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadMaskedTextBox ID="rMTZip" Text='<%# DataBinder.Eval(Container, "DataItem.Zip") %>' runat="server" DisplayMask="#####" LabelWidth="64px" Mask="#####" Width="160px"></telerik:RadMaskedTextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="Zip4" FilterControlAltText="Filter TemplateColumn3 column" UniqueName="Zip4" HeaderText="Zip4">
                    <ItemTemplate>
                        <asp:Label ID="lblZip4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Zip4") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadMaskedTextBox ID="rMTZip4" Text='<%# DataBinder.Eval(Container, "DataItem.Zip4") %>' runat="server" DisplayMask="####" LabelWidth="64px" Mask="####" Width="160px"></telerik:RadMaskedTextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ConfirmText="Are you sure you want to delete this?" ButtonType="ImageButton" />

            </Columns>
            <EditFormSettings>
                <EditColumn UniqueName="EditCommandColumn1" ButtonType="ImageButton" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
