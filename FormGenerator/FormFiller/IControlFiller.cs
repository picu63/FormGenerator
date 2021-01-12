using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace FormGenerator.FormFiller
{
    public interface IControlFiller
    {
        void FillTextBox(TextBox textBox, string text);
        void FillCheckBox(CheckBox checkBox, bool isChecked);
        void FillDropDownList(DropDownList dropDownList, IEnumerable<KeyValuePair<int, string>> indexValuePairs);
        void FillRadioButtons(RadioButtonList radioButtonList, int selectedIndex);
    }
}