using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.BusinessLogicLayer.VT.Vol;
using System.Web.Security;
using System.Web.ApplicationServices;
using Telerik.Web.UI;


using System.Collections;


namespace VolTeer.Common.WebControls
{

    public partial class ucEditSkill : System.Web.UI.UserControl
    {
        private sp_Skill_BLL BLL = new sp_Skill_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            rTLSkills.ExpandToLevel(2);
        }

        protected void rTLSkills_NeedDataSource(object sender, Telerik.Web.UI.TreeListNeedDataSourceEventArgs e)
        {
            rTLSkills.DataSource = BLL.ListSkills();

        }

        protected void rTLSkills_ItemCommand(object sender, TreeListCommandEventArgs e)
        {
            //if (e.CommandName == "Update")
            //{

            //    if (e.Item is TreeListEditFormItem)
            //    {

            //        TreeListEditFormItem editForm = e.Item as TreeListEditFormItem;

            //        var rTBSkill = (editForm.FindControl("rTBSkillName") as RadTextBox).Text.ToString();
            //        var SkillID = DataBinder.Eval(editForm.DataItem, "SkillID").ToString();



            //    }
            //}

            if (e.CommandName == "Delete")
            {
                if (e.Item is TreeListDataItem)
                {
                    TreeListDataItem item = e.Item as TreeListDataItem;
                    var SkillID = DataBinder.Eval(item.DataItem, "SkillID").ToString();
                }

            }

            if (e.CommandName == "PerformInsert")
            {

                Hashtable insertValues = new Hashtable();
                TreeListEditableItem editedItem = e.Item as TreeListEditableItem;
                e.Item.OwnerTreeList.ExtractValuesFromItem(insertValues, editedItem, true);




                if (e.Item is TreeListDataInsertItem )
                {
                    TreeListDataInsertItem insertForm = e.Item as TreeListDataInsertItem;
                    var SkillID = DataBinder.Eval(insertForm.DataItem, "MstrSkillID").ToString();
                    var rTBSkill = (insertForm.FindControl("rTBSkillNameIns") as RadTextBox).Text.ToString();


                }
            }

            if (e.CommandName == "CustomItemsDropped")
            {
                TreeListDataItem item = e.Item as TreeListDataItem;
                string ParentSkillID = e.CommandArgument.ToString();


                rTLSkills.Rebind();

            }
        }

        protected void rTLSkills_UpdateCommand(object sender, TreeListCommandEventArgs e)
        {
            TreeListEditableItem editItem = (TreeListEditableItem)e.Item;
            Hashtable values = new Hashtable();
            editItem.ExtractValues(values);

            if (values["SkillName"] == null)
            {
                e.Canceled = true;
            }



        }

    }
}