using System;
using System.Linq;
using System.Web.UI;
using Telerik.Web.UI;
using Telerik.Web.UI.Skins;
using VolTeer.BusinessLogicLayer.VT;

namespace VolTeer.Org
{
    public partial class ManageOrg : System.Web.UI.Page
    {
        private sp_Group_BLL BLL = new sp_Group_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = BLL.ListGroups(1);

        }

        protected void RadGrid1_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!(e.Item is GridEditFormInsertItem))
                {
                    GridEditableItem item = e.Item as GridEditableItem;
                    GridEditManager manager = item.EditManager;
                    GridTextBoxColumnEditor editor = manager.GetColumnEditor("GroupID") as GridTextBoxColumnEditor;
                    editor.TextBoxControl.Enabled = false;
                }
            }


        }
        protected void RadGrid1_ItemInserted(object source, GridInsertedEventArgs e)
        {
            if (e.Exception != null)
            {

                e.ExceptionHandled = true;
                SetMessage("Customer cannot be inserted. Reason: " + e.Exception.Message);

            }
            else
            {
                SetMessage("New customer is inserted!");
            }
        }
        private void DisplayMessage(string text)
        {
            RadGrid1.Controls.Add(new LiteralControl(string.Format("<span style='color:red'>{0}</span>", text)));
        }

        private void SetMessage(string message)
        {
            gridMessage = message;
        }

        private string gridMessage = null;

        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gridMessage))
            {
                DisplayMessage(gridMessage);
            }
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            foreach (GridItem Item in RadGrid1.Items)
            {


            }


        }



    }
}