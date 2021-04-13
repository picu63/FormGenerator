using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormGenerator.Attributes;
using FormGenerator.FormSections;

namespace FormGenerator.FormGetter
{
    internal class ControlsGetter<T>
    {
        private readonly IControlGetter _controlGetter;

        public ControlsGetter(IControlGetter controlGetter)
        {
            _controlGetter = controlGetter;
        }

        internal T Get(IEnumerable<Control> controls)
        {
            var @object = Activator.CreateInstance<T>();
            foreach (var control in controls)
            {
                var p = GetPropertyByFieldAttributeId(@object.GetType(), control.ID);
                object value;
                switch (control)
                {
                    case TextBox textBox:
                        value = _controlGetter.GetValueFromTextBox(textBox);
                        p.SetValue(@object, value);
                        break;
                    case CheckBox checkBox:
                        value = _controlGetter.GetValueFromCheckBox(checkBox);
                        p.SetValue(@object, value);
                        break;
                }

            }

            return @object;
        }
        public PropertyInfo GetPropertyByFieldAttributeId(Type type, string id) => type.GetProperties().First(p =>
        {
            var fieldAttribute = p.GetCustomAttributes<FieldAttribute>().First();
            if (fieldAttribute.Id == id)
            {
                return true;
            }

            return false;
        });
    }
}
