<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSkillsManage.ascx.cs" Inherits="VolTeer.Common.WebControls.ucSkillsManage" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadScriptBlock runat="Server" ID="RadScriptBlock1">
    <script type="text/javascript">
        /* <![CDATA[ */

        function onNodeDragging(sender, args) {
            var target = args.get_htmlElement();

            if (!target) return;

            if (target.tagName == "INPUT") {
                target.style.cursor = "hand";
            }

            var grid = isMouseOverGrid(target)
            if (grid) {
                grid.style.cursor = "hand";
            }
        }

        function dropOnHtmlElement(args) {
            if (droppedOnInput(args))
                return;

            if (droppedOnGrid(args))
                return;
        }

        function droppedOnGrid(args) {
            var target = args.get_htmlElement();

            while (target) {
                if (target.id == gridId) {
                    args.set_htmlElement(target);
                    return;
                }

                target = target.parentNode;
            }
            args.set_cancel(true);
        }

        function droppedOnInput(args) {
            var target = args.get_htmlElement();
            if (target.tagName == "INPUT") {
                target.style.cursor = "default";
                target.value = args.get_sourceNode().get_text();
                args.set_cancel(true);
                return true;
            }
        }

        function dropOnTree(args) {
            var text = "";

            if (args.get_sourceNodes().length) {
                var i;
                for (i = 0; i < args.get_sourceNodes().length; i++) {
                    var node = args.get_sourceNodes()[i];
                    text = text + ', ' + node.get_text();
                }
            }
        }

        function clientSideEdit(sender, args) {
            var destinationNode = args.get_destNode();

            if (destinationNode) {
                var firstTreeView = $find('<%= rTreeViewSkills.ClientID %>');
                var secondTreeView = $find('<%= rLBUnslottedSkills.ClientID %>');

                firstTreeView.trackChanges();
                secondTreeView.trackChanges();
                var sourceNodes = args.get_sourceNodes();
                var dropPosition = args.get_dropPosition();

                //Needed to preserve the order of the dragged items
                if (dropPosition == "below") {
                    for (var i = sourceNodes.length - 1; i >= 0; i--) {
                        var sourceNode = sourceNodes[i];
                        sourceNode.get_parent().get_nodes().remove(sourceNode);

                        insertAfter(destinationNode, sourceNode);
                    }
                }
                else {
                    for (var j = 0; j < sourceNodes.length; j++) {
                        sourceNode = sourceNodes[j];
                        sourceNode.get_parent().get_nodes().remove(sourceNode);

                        if (dropPosition == "over")
                            destinationNode.get_nodes().add(sourceNode);
                        if (dropPosition == "above")
                            insertBefore(destinationNode, sourceNode);
                    }
                }
                destinationNode.set_expanded(true);
                firstTreeView.commitChanges();
                secondTreeView.commitChanges();
            }
        }

        function insertBefore(destinationNode, sourceNode) {
            var destinationParent = destinationNode.get_parent();
            var index = destinationParent.get_nodes().indexOf(destinationNode);
            destinationParent.get_nodes().insert(index, sourceNode);
        }

        function insertAfter(destinationNode, sourceNode) {
            var destinationParent = destinationNode.get_parent();
            var index = destinationParent.get_nodes().indexOf(destinationNode);
            destinationParent.get_nodes().insert(index + 1, sourceNode);
        }

        function onNodeDropping(sender, args) {
            var dest = args.get_destNode();
            if (dest) {
                var clientSide = document.getElementById('<%= ChbClientSide.ClientID %>').checked;

                if (clientSide) {
                    clientSideEdit(sender, args);
                    args.set_cancel(true);
                    return;
                }

                dropOnTree(args);
            }
            else {
                dropOnHtmlElement(args);
            }
        }
        /* ]]> */
    </script>
</telerik:RadScriptBlock>

<telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="Panel1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="Panel1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1">
</telerik:RadAjaxLoadingPanel>
<asp:Panel runat="server" ID="Panel1">

    <asp:CheckBox ID="ChbClientSide" runat="server" Checked="false" Visible="false" Text="Client-side drag &amp;amp; drop"></asp:CheckBox>

    <asp:Table runat="server" ID="tblSkills">
        <asp:TableRow Width="90%">
            <asp:TableCell VerticalAlign="Top">
                <div style="width: 400px; float: left; height:400px; max-height:400px;">
                    <span class="label">Master Skill List</span>
                    <telerik:RadTreeView ID="rTreeViewSkills" BorderWidth="1px"
                        runat="server"
                        EnableDragAndDrop="True"
                        OnNodeDrop="rTreeViewSkills_HandleDrop"
                        OnClientNodeDropping="onNodeDropping"
                        OnClientNodeDragging="onNodeDragging"
                        MultipleSelect="true"
                        EnableDragAndDropBetweenNodes="true">
                    </telerik:RadTreeView>
                </div>
            </asp:TableCell>

            <asp:TableCell>
                <div style="width: 400px; float: left; height:400px; max-height:400px;">
                    <telerik:RadListBox ID="rLBUnslottedSkills" 
                        EnableDragAndDrop="true"  AutoPostBackOnReorder="true"
                        runat="server" Height="240px"
                        DataKeyField="MstrSkillID" 
                        DataTextField="SkillName" 
                        DataValueField="SkillID"></telerik:RadListBox>
                </div>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>



</asp:Panel>
