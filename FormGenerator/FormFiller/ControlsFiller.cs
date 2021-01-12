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
                var value = FieldHelper.GetValue(_object, control.ID);
                var controlFiller = new ControlFiller();
                if (control is TextBox textBox)
                {
                    controlFiller.FillTextBox(textBox, value.ToString());
                }
            }
        }

        public void Fill(Control controls)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IFieldFiller
    {
        void Fill(IEnumerable<Control> controls);
        void Fill(Control controls);
    }
}