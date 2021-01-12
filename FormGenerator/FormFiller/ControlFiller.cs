using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace FormGenerator.FormFiller
{
    public class ControlFiller : IControlFiller
    {
        public void FillTextBox(TextBox textBox, string text)
        {
            throw new System.NotImplementedException();
        }

        public void FillCheckBox(CheckBox checkBox, bool isChecked)
        {
            throw new System.NotImplementedException();
        }

        public void FillDropDownList(DropDownList dropDownList, IEnumerable<KeyValuePair<int, string>> indexValuePairs)
        {
            var sortedPairs = indexValuePairs.OrderBy(p => p.Key);
        }

        public void FillRadioButtons(RadioButtonList radioButtonList, int selectedIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}