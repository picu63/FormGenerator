using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormGenerator.FormFiller
{
    internal class ControlsFiller<T>
    {
        private readonly T _object;
        private readonly IControlFiller _controlFiller;
        private readonly IControlSelector _controlSelector;

        internal ControlsFiller(T @object, IControlFiller controlFiller, IControlSelector controlSelector)
        {
            _object = @object;
            _controlFiller = controlFiller;
            _controlSelector = controlSelector;
        }

        internal void Fill(IEnumerable<Control> controls)
        {
            foreach (var control in controls)
            {
                var value = FieldAttributeHelper.GetValue(_object, control.ID);
                Fill(control, value);
            }
        }

        /// <summary>
        /// Uzupełnia 
        /// </summary>
        /// <param name="control"></param>
        private void Fill(Control control, object value)
        {
            if (control is TextBox textBox)
            {
                _controlFiller.FillTextBox(textBox, value.ToString());
            }
            else if (control is CheckBox checkBox)
            {
                _controlFiller.FillCheckBox(checkBox, bool.Parse(value.ToString()));
            }
            else if (control is DropDownList dropDownList)
            {
                if (value is ICollection<object> collection)
                {
                    _controlFiller.FillDropDownList(dropDownList, new Dictionary<string, string>());
                }
                else if(value is Enum @enum)
                {
                    _controlSelector.SelectDropDownList(dropDownList, (int)value);
                }
            }
        }
    }
}