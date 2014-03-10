using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VolTeer.SampleControls
{
    public partial class InputControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            MaskedTextBoxRequiredFieldValidator.EnableClientScript = CheckBox1.Checked;
            DateInputRangeValidator.EnableClientScript = CheckBox1.Checked;
            PickerRequiredFieldValidator.EnableClientScript = CheckBox1.Checked;
            TextBoxRequiredFieldValidator.EnableClientScript = CheckBox1.Checked;
            NumercTextBoxRequiredFieldValidator.EnableClientScript = CheckBox1.Checked;
            MaskedTextBoxRegularExpressionValidator.EnableClientScript = CheckBox1.Checked;
            NumericTextBoxRangeValidator.EnableClientScript = CheckBox1.Checked;
            Requiredfieldvalidator1.EnableClientScript = CheckBox1.Checked;
            emailValidator.EnableClientScript = CheckBox1.Checked;
        }


        protected void ResetButton_Click(object sender, EventArgs e)
        {
            RadNumericTextBox1.Text = String.Empty;
            RadTextBox1.Text = String.Empty;
            Radtextbox2.Text = String.Empty;
            RadMaskedTextBox1.Text = String.Empty;
            RadDateInput1.Text = String.Empty;
        }
    }
}