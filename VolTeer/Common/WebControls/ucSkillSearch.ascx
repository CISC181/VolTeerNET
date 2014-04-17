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
        Show Tree Control
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


        //]]>
    </script>
</telerik:RadCodeBlock>
