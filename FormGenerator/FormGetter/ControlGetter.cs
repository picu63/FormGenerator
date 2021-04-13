using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace FormGenerator.FormGetter
{
    class ControlGetter : IControlGetter
    {
        public string GetValueFromTextBox(TextBox textBox)
        {
            return textBox.Text;
        }

        public bool GetValueFromCheckBox(CheckBox checkBox)
        {
            return checkBox.Checked;
        }
    }
}
