<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSkillSearch.ascx.cs" Inherits="VolTeer.Common.WebControls.ucSkillSearch" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="pnlSkills" runat="server">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:RadioButton ID="rbAutoComplete" GroupName="MainForm" Checked="true" OnCheckedChanged="rbAutoComplete_CheckedChanged" AutoPostBack="true"  Text="Auto Complete" runat="server" />

                <asp:RadioButton ID="rbTreeControl" GroupName="MainForm" OnCheckedChanged="rbTreeControl_CheckedChanged" AutoPostBack="true"  Text="Tree" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Panel ID="pnlAutoComplete" Visible="false" runat="server">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
            <label for="RadAutoCompleteBox1">Skills:</label>
            <telerik:RadAutoCompleteBox ID="rACSkills"
                runat="server"
                Width="674px"
                DropDownWidth="400"
                DropDownHeight="150"
                AllowCustomEntry="true"
                EmptyMessage="Enter Skills"
                Height="35px">
            </telerik:RadAutoCompleteBox>
            <br />
            <input type="button" name="Text2" value="Clear All Entries" onclick="ClearAllEntries()" />
            <br />
            <telerik:RadButton ID="rBTNProcess" runat="server" Text="Process" OnClick="rBTNProcess_Click">
            </telerik:RadButton>
        </telerik:RadAjaxPanel>
    </asp:Panel>

    <asp:Panel ID="pnlTree" Visible="false" runat="server">
        <telerik:RadTreeList ID="rTLSkills" runat="server" OnNeedDataSource="rTLSkills_NeedDataSource"
    ParentDataKeyNames="MstrSkillID" DataKeyNames="SkillID" Width="566px" 
    AutoGenerateColumns="False" AllowSorting="True">
    <Columns>

        <telerik:TreeListTemplateColumn HeaderText="Has Skill">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="chkHasSkill" AutoPostBack="true" Width="200px" />
            </ItemTemplate>
        </telerik:TreeListTemplateColumn>

        <telerik:TreeListBoundColumn DataField="SkillID" UniqueName="SkillID" HeaderText="Skill ID" Visible="false" >
        </telerik:TreeListBoundColumn>

        <telerik:TreeListTemplateColumn DataField="SkillName" UniqueName="SkillName"
            HeaderText="Skill">
            <ItemTemplate>
                <%# Eval("SkillName")%>
            </ItemTemplate>
            <HeaderStyle Width="400px"></HeaderStyle>
        </telerik:TreeListTemplateColumn>


        <telerik:TreeListBoundColumn DataField="MstrSkillID" UniqueName="MstrSkillID" HeaderText="Master Category ID" Visible="false">
        </telerik:TreeListBoundColumn>

    </Columns>
</telerik:RadTreeList>
            <br />
            <input type="button" name="Text2" value="Clear All Entries" onclick="ClearAllTreeEntries()" />
            <br />
            <telerik:RadButton ID="RadButton1" runat="server" Text="Process" OnClick="rBTNProcessTree_Click">
            </telerik:RadButton>

    </asp:Panel>



</asp:Panel>

<telerik:RadCodeBlock ID="CodeBlock1" runat="server">
    <script type="text/javascript">
        //<![CDATA[
        function AddNewEntry() {
            var autoCompleteBox = $find("<%= rACSkills.ClientID %>");
            var entry = new Telerik.Web.UI.AutoCompleteBoxEntry();
            entry.set_text(inputText);
            autoCompleteBox.get_entries().add(entry);

        }

        function RemoveEntry() {
            var autoCompleteBox = $find("<%= rACSkills.ClientID %>");
            var firstEntry = autoCompleteBox.get_entries().getEntry(0);
            if (firstEntry) {
                autoCompleteBox.get_entries().remove(firstEntry);
            }
        }

        function ClearAllEntries() {
            var autoCompleteBox = $find("<%= rACSkills.ClientID %>");
            autoCompleteBox.get_entries().clear();
        }

        function ClearAllTreeEntries() {
            var radTreeList = $find("<%= rTLSkills.ClientID %>");
            radTreeList.get_entries().clear();
        }

        //]]>
    </script>
</telerik:RadCodeBlock>
