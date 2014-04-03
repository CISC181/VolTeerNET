using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using VolTeer.DomainModels.DescribeDB;

using System.Collections.Generic;
using System.Web.SessionState;
using VolTeer.DomainModels.DescribeDB;


using System.Reflection;

namespace VolTeer.App_Code
{

    public class cValidations
    {
        HashSet<TableColumnDM> ListTableColumns;

        private int iPlaceHolder = 0;
        private PlaceHolder plc;

        public cValidations()
        {
            this.TableColumns = (List<TableColumnDM>)HttpContext.Current.Application["ListTableColumns"];
            this.CheckConstraints = (List<CheckConstraintsDM>)HttpContext.Current.Application["ListCheckConstraints"];
        }

        public virtual List<TableColumnDM> TableColumns { get; set; }
        public virtual List<CheckConstraintsDM> CheckConstraints { get; set; }


        public void SetValidations(object obj, Control ctrl)
        {
            if (ctrl == null) return;
            Type objType = ctrl.GetType();

            if (ctrl is PlaceHolder)
            {
                iPlaceHolder = Convert.ToInt32((((HtmlForm)obj).Controls.IndexOf(ctrl)));
                plc = (PlaceHolder)ctrl;
            }

            if (ctrl is TextBox)
            {
                ((TextBox)ctrl).Text = "test";
                ((TextBox)ctrl).MaxLength = 10;

            }
            else if (ctrl is LiteralControl)
            {

            }
            else if (ctrl is Label)
            {

            }
            else if (ctrl is RadDropDownList)
            {

            }

            else if (ctrl is RadTextBox)
            {
                string ctrlID = ((RadTextBox)ctrl).ID;
                string ctrlParentName = ((RadTextBox)ctrl).Parent.ID.ToString();

                TableColumnDM TableColumnRecord = FilterTableColumn(this.TableColumns, ctrlParentName, ctrlID);
                if (TableColumnRecord != null)
                {
                    ((RadTextBox)ctrl).MaxLength = Convert.ToInt32(TableColumnRecord.character_maximum_length);
                    if (((TableColumnRecord.is_nullable).ToUpper()) == "NO")
                    {
                        RequiredFieldValidator nameValidator = new RequiredFieldValidator();
                        nameValidator.ControlToValidate = (((RadTextBox)ctrl).ID.ToString());
                        nameValidator.ErrorMessage = "This field is required";
                        nameValidator.Display = ValidatorDisplay.Dynamic;
                        nameValidator.Text = " ";
                        plc.Controls.Add(nameValidator);
                    }
                }

                ////////////////PropertyInfo[] objPropertiesArray = objType.GetProperties();                
                ////////////////foreach (PropertyInfo objProperty in objPropertiesArray)
                ////////////////{
                ////////////////    //string str = objProperty.Name.ToString();
                ////////////////    //string propertyValue = objProperty.GetValue(obj, null).ToString();

                ////////////////    if (objProperty.Name.ToString().ToUpper() == "CssClass".ToUpper())
                ////////////////    {                      
                ////////////////        //objProperty.SetValue(obj, Convert.ChangeType(css, objProperty.PropertyType), null);

                ////////////////        objProperty.SetValue(null, css, null);
                ////////////////    }
                ////////////////}

            }

            if (ctrl.HasControls())
            {
                //foreach (Control childControl in ctrl.Controls)
                //{
                //    SetValidations(obj, childControl);
                //}

                for (int i = ctrl.Controls.Count - 1; i > 0; i--)
                {
                    SetValidations(obj, ctrl.Controls[i]);
                }

            }

        }

        private TableColumnDM FilterTableColumn(List<TableColumnDM> tableColumns, string ContainerName, string ControlName)
        {

            TableColumnDM filtereditem = tableColumns.Where(j => j.control_name == ControlName).Where(j => j.container_name == ContainerName).SingleOrDefault();

            return filtereditem;
        }

        private void ResetAllControlsBackColor(Control control)
        {
            if (control.HasControls())
            {
                // Recursively call this method for each child control. 
                foreach (Control childControl in control.Controls)
                {
                    ResetAllControlsBackColor(childControl);
                }
            }
        }

    }
}