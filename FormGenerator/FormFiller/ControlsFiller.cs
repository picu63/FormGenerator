using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormGenerator.FormFiller
{
    public class ControlsFiller<T> : IFieldFiller
    {
        private readonly T _object;

        public ControlsFiller(T @object)
        {
            _object = @object;
        }

        public void Fill(IEnumerable<Control> controls)
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
        public void Fill(Control control, object value)
        {
            var controlFiller = new ControlFiller();
            var controlSelector = new ControlSelector();
            if (control is TextBox textBox)
            {
                controlFiller.FillTextBox(textBox, value.ToString());
            }
            else if (control is CheckBox checkBox)
            {
                controlFiller.FillCheckBox(checkBox, bool.Parse(value.ToString()));
            }
            else if (control is DropDownList dropDownList)
            {
                if (value is ICollection<object> collection)
                {
                    controlFiller.FillDropDownList(dropDownList, new Dictionary<string, string>());
                }
                else if(value is Enum @enum)
                {
                    controlSelector.SelectDropDownList(dropDownList, (int)value);
                }
            }
        }
    }

    public interface IFieldFiller
    {
        void Fill(IEnumerable<Control> controls);
        void Fill(Control controls, object value);
    }
}