<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/Site.Master" CodeBehind="GroupSearch.aspx.cs" Inherits="VolTeer.SampleControls.GroupSearch" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <telerik:RadCodeBlock ID="CodeBlock1" runat="server">
        <script type="text/javascript">
            //<![CDATA[
            function AddNewEntry() {
                var autoCompleteBox = $find("<%= rACGroups.ClientID %>");
            var entry = new Telerik.Web.UI.AutoCompleteBoxEntry();
            entry.set_text(inputText);
            autoCompleteBox.get_entries().add(entry);

        }

        function RemoveEntry() {
            var autoCompleteBox = $find("<%= rACGroups.ClientID %>");
            var firstEntry = autoCompleteBox.get_entries().getEntry(0);
            if (firstEntry) {
                autoCompleteBox.get_entries().remove(firstEntry);
            }
        }

        function ClearAllEntries() {
            var autoCompleteBox = $find("<%= rACGroups.ClientID %>");
            autoCompleteBox.get_entries().clear();
        }

        //]]>
        </script>



    </telerik:RadCodeBlock>

        <asp:Panel ID="pnlAutoComplete" Visible="true" runat="server">
            <label for="RadAutoCompleteBox1">Groups:</label>
            <telerik:RadAutoCompleteBox ID="rACGroups"
                runat="server"
                Width="674px"
                Skin='<%$ AppSettings:Telerik.Skin %>' 
                DropDownWidth="400"
                DropDownHeight="150"
                AllowCustomEntry="true"
                EmptyMessage="Enter Search Terms"
                Height="35px">
            </telerik:RadAutoCompleteBox>
            <br />
            <input type="button" name="Text2" value="Clear All Entries" onclick="ClearAllEntries()" />
            <br />
            <telerik:RadButton ID="rBTNProcess" runat="server" Text="Process" OnClick="rBTNProcess_Click">
            </telerik:RadButton>
        </asp:Panel>

    <asp:Panel ID="pnlSearchResults" runat="server" Visible="true" Width="90%">

         <telerik:RadGrid ID="rGridSearch"
        runat="server"
       
        OnItemDataBound="rGridSearch_ItemDataBound"
        Width ="100%"
        AutoGenerateColumns="False"
        AllowFilteringByColumn="False"
        AllowSorting="True"
        Skin='<%$ AppSettings:Telerik.Skin %>'
        CellSpacing="0"
        GridLines="None" 
        OnPreRender="rGridSearch_PreRender"
        AllowMultiRowEdit="True"
        AllowMultiRowSelection="True">
        <GroupingSettings CaseSensitive="False" />
        <MasterTableView DataKeyNames="GroupID"
            CommandItemDisplay="Bottom"
            EditMode="EditForms"
            EnableHeaderContextAggregatesMenu="True"
            EnableHeaderContextFilterMenu="True"
            EnableHeaderContextMenu="True">
   
            <Columns>
 
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column">
                    <ItemTemplate>
                        <telerik:RadButton ID="rbtSelect" runat="server" Width="15%" Text="Select" OnClick="rbtSelect_Click" AutoPostBack="true" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.GroupID") %>'></telerik:RadButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>


                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Group ID" DataField="GroupID" UniqueName="GroupID">
                    <ItemTemplate>
                        <asp:Label ID="lblGroupID" runat="server" Width="5%"  Text='<%# DataBinder.Eval(Container, "DataItem.GroupID") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

            

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Group Name" DataField="GroupName" UniqueName="GroupName">
                    <ItemTemplate>
                        <asp:Label ID="lblGroupName" runat="server" Width="20%"  Text='<%# DataBinder.Eval(Container, "DataItem.GroupName") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Short Description" DataField="ShortDesc" UniqueName="ShortDesc">
                    <ItemTemplate>
                        <asp:Label ID="lblShortDesc" runat="server" Width="50%"  Text='<%# DataBinder.Eval(Container, "DataItem.ShortDesc") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Count Terms" DataField="countTerms" UniqueName="countTerms">
                    <ItemTemplate>
                        <asp:Label ID="lblCountTerms" runat="server" Width="20%"  Text='<%# DataBinder.Eval(Container, "DataItem.countTerms") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>



                
                
            </Columns>
            <EditFormSettings EditFormType="Template">
                
               
            </EditFormSettings>

        </MasterTableView>
    </telerik:RadGrid>
    </asp:Panel>

   


</asp:Content>
