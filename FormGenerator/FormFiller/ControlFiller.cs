using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web.UI.WebControls;

namespace FormGenerator.FormFiller
{
    public class ControlFiller : IControlFiller
    {
        public void FillTextBox(TextBox textBox, string text)
        {
            textBox.Text = text;
        }

        public void FillCheckBox(CheckBox checkBox, bool isChecked)
        {
            checkBox.Checked = isChecked;
        }

        public void FillDropDownList(DropDownList dropDownList, Dictionary<string, string> indexValuePairs)
        {
            indexValuePairs
                .OrderBy(p => p.Key).ToList()
                .ForEach((pair => dropDownList.Items.Add(new ListItem(pair.Key, pair.Value))));
        }

        public void FillRadioButtons(RadioButtonList radioButtonList, int selectedIndex)
        {
            throw new NotImplementedException();
        }

        public void FillListBox(ListBox listBox, List<string> listViewItems)
        {
            throw new NotImplementedException();
        }
    }
}