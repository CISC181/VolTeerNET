<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAddress.ascx.cs" Inherits="VolTeer.Common.WebControls.ucAddress" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadGrid ID="rGridAddress" runat="server" AutoGenerateColumns="False" BorderWidth="1px">
    <MasterTableView CommandItemDisplay="Top">
        <Columns>
            <telerik:GridBoundColumn DataField="AddrID" Display="False" FilterControlAltText="Filter column column" ReadOnly="True" UniqueName="column">
            </telerik:GridBoundColumn>
            <telerik:GridCheckBoxColumn DataField="ActiveFlg" HeaderText="Active" DataType="System.Boolean" FilterControlAltText="Filter column1 column" UniqueName="column1">
            </telerik:GridCheckBoxColumn>
            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Address 1" DataField="AddrLine1" UniqueName="AddrLine1">
                <ItemTemplate>
                    <asp:Label ID="lblAddressLine1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine1") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="rTBAddressLine1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine1") %>'>
                    </asp:Label>

                </EditItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Address 2" DataField="AddrLine2" UniqueName="AddrLine2">
                <ItemTemplate>
                    <asp:Label ID="lblAddressLine2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine2") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="rTBAddressLine2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine2") %>'>
                    </asp:Label>

                </EditItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Address 3" DataField="AddrLine3" UniqueName="AddrLine3">
                <ItemTemplate>
                    <asp:Label ID="lblAddressLine3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine3") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="rTBAddressLine3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AddrLine3") %>'>
                    </asp:Label>

                </EditItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="City" DataField="City" UniqueName="City">
                <ItemTemplate>
                    <asp:Label ID="lblCity" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.City") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="rTBCity" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.City") %>'>
                    </asp:Label>

                </EditItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="State" DataField="ST" UniqueName="ST">
                <ItemTemplate>
                    <asp:Label ID="lblST" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ST") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="rTBST" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.St") %>'>
                    </asp:Label>

                </EditItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="ZIP" DataField="ZIP" UniqueName="ZIP">
                <ItemTemplate>
                    <asp:Label ID="lblZIP" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ZIP") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="rTBZIP" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ZIP") %>'>
                    </asp:Label>

                </EditItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="ZIP4" DataField="ZIP4" UniqueName="ZIP4">
                <ItemTemplate>
                    <asp:Label ID="lblZIP4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ZIP4") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="rTBZIP4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ZIP4") %>'>
                    </asp:Label>

                </EditItemTemplate>
            </telerik:GridTemplateColumn>

        </Columns>
    </MasterTableView>
</telerik:RadGrid>
