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

        public static void SetValidations(object obj, Control ctrl)
        {
            if (ctrl == null) return;
            Type objType = ctrl.GetType();

            if (ctrl is TextBox)
            {
                ((TextBox)ctrl).Text = "test";
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
                nameValidator.ErrorMessage = (((RadTextBox)ctrl).ID.ToString());
                nameValidator.Display = ValidatorDisplay.Static;
                nameValidator.Text = " ";
                //nameValidator.ValidationGroup = "Group1";
                //nameValidator.CssClass = "Validator";

                //Control ContainerControl = ((RadTextBox)ctrl).NamingContainer;
                //ContainerControl.Controls.Add(nameValidator);

                //((Page)obj).Validators.Add(nameValidator);

                ((HtmlForm)obj).Controls.Add(nameValidator);

            }
            else if (ctrl is Label)
            {
                //   ((Label)ctrl).Text = "textlabel";
            }

            for (int i = 0; i < ctrl.Controls.Count - 1; i++)
            {
                SetValidations(obj, ctrl.Controls[i]);
            }



        }

    }
}