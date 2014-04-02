using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

namespace VolTeer.App_Code
{

    public class cValidations
    {
        private static int iPlaceHolder = 0;
        private static PlaceHolder plc;

        public static void SetValidations(object obj, Control ctrl)
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
                ((RadTextBox)ctrl).Text = "testrad";
                ((RadTextBox)ctrl).MaxLength = 4;

                RequiredFieldValidator nameValidator = new RequiredFieldValidator();

                nameValidator.ControlToValidate = (((RadTextBox)ctrl).ID.ToString());
                nameValidator.ErrorMessage = "This field is required";
                nameValidator.Display = ValidatorDisplay.Static;
                nameValidator.Text = " ";
                //nameValidator.ValidationGroup = "Group1";
                //nameValidator.CssClass = "Validator";

                //Control ContainerControl = ((RadTextBox)ctrl).NamingContainer;
                //ContainerControl.Controls.Add(nameValidator);

                //((Page)obj).Validators.Add(nameValidator);

                //((HtmlForm)obj).Controls.Add(nameValidator);
                //((PlaceHolder)obj).Controls.Add(nameValidator);


                plc.Controls.Add(nameValidator);
                //if (((HtmlForm)obj).Controls.IndexOf(ctrl) >= 0)
                //{
                //    ((HtmlForm)obj).Controls.AddAt(((HtmlForm)obj).Controls.IndexOf(ctrl), nameValidator);
                //}
            }
            else if (ctrl is Label)
            {
                //   ((Label)ctrl).Text = "textlabel";
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