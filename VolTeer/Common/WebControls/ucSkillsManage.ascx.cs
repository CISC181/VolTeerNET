using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.Common.WebControls
{
    public partial class ucSkillsManage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        protected void LoadControls()
        {
            sp_Skill_BLL SkillBLL = new sp_Skill_BLL();

            rTreeViewSkills.DataTextField = "SkillName";
            rTreeViewSkills.DataFieldID = "SkillID";
            rTreeViewSkills.DataFieldParentID = "MstrSkillID";

            rTreeViewSkills.DataSource = SkillBLL.ListSkills(false);

            rTreeViewSkills.DataBind();
            rTreeViewSkills.ExpandAllNodes();

            rLBUnslottedSkills.DataSource  = SkillBLL.ListSkills(true);
            rLBUnslottedSkills.DataBind();


        }

        protected void rTreeViewSkills_HandleDrop(object sender, RadTreeNodeDragDropEventArgs e)
        {
            RadTreeNode sourceNode = e.SourceDragNode;
            RadTreeNode destNode = e.DestDragNode;
            RadTreeViewDropPosition dropPosition = e.DropPosition;

            if (destNode != null) //drag&drop is performed between trees
            {
                if (ChbClientSide.Checked) //dropped node will at the same level as a destination node
                {
                    if (sourceNode.TreeView.SelectedNodes.Count <= 1)
                    {
                        PerformDragAndDrop(dropPosition, sourceNode, destNode);
                    }
                    else if (sourceNode.TreeView.SelectedNodes.Count > 1)
                    {
                        if (dropPosition == RadTreeViewDropPosition.Below) //Needed to preserve the order of the dragged items
                        {
                            for (int i = sourceNode.TreeView.SelectedNodes.Count - 1; i >= 0; i--)
                            {
                                PerformDragAndDrop(dropPosition, sourceNode.TreeView.SelectedNodes[i], destNode);
                            }
                        }
                        else
                        {
                            foreach (RadTreeNode node in sourceNode.TreeView.SelectedNodes)
                            {
                                PerformDragAndDrop(dropPosition, node, destNode);
                            }
                        }
                    }
                }
                else //dropped node will be a sibling of the destination node
                {
                    if (sourceNode.TreeView.SelectedNodes.Count <= 1)
                    {
                        if (!sourceNode.IsAncestorOf(destNode))
                        {
                            sourceNode.Owner.Nodes.Remove(sourceNode);
                            destNode.Nodes.Add(sourceNode);
                        }
                    }
                    else if (sourceNode.TreeView.SelectedNodes.Count > 1)
                    {
                        foreach (RadTreeNode node in rTreeViewSkills.SelectedNodes)
                        {
                            if (!node.IsAncestorOf(destNode))
                            {
                                node.Owner.Nodes.Remove(node);
                                destNode.Nodes.Add(node);
                            }
                        }
                    }
                }

                destNode.Expanded = true;
                sourceNode.TreeView.UnselectAllNodes();
            
            }
        }
        private static void PerformDragAndDrop(RadTreeViewDropPosition dropPosition, RadTreeNode sourceNode,
                                                         RadTreeNode destNode)
        {
            if (sourceNode.Equals(destNode) || sourceNode.IsAncestorOf(destNode))
            {
                return;
            }
            sourceNode.Owner.Nodes.Remove(sourceNode);

            switch (dropPosition)
            {
                case RadTreeViewDropPosition.Over:
                    // child
                    if (!sourceNode.IsAncestorOf(destNode))
                    {
                        destNode.Nodes.Add(sourceNode);
                    }
                    break;

                case RadTreeViewDropPosition.Above:
                    // sibling - above                         
                    destNode.InsertBefore(sourceNode);
                    break;

                case RadTreeViewDropPosition.Below:
                    // sibling - below
                    destNode.InsertAfter(sourceNode);
                    break;
            }
        }

        protected void ChbMultipleSelect_CheckedChanged(object sender, EventArgs e)
        {
            rTreeViewSkills.MultipleSelect = !rTreeViewSkills.MultipleSelect;
        }

        protected void ChbBetweenNodes_CheckedChanged(object sender, EventArgs e)
        {
            rTreeViewSkills.EnableDragAndDropBetweenNodes = !rTreeViewSkills.EnableDragAndDropBetweenNodes;
        }


    }
}