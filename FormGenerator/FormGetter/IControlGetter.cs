using System.Web.UI.WebControls;

namespace FormGenerator.FormGetter
{
    internal interface IControlGetter
    {
        string GetValueFromTextBox(TextBox textBox);
        bool GetValueFromCheckBox(CheckBox checkBox);
    }
}