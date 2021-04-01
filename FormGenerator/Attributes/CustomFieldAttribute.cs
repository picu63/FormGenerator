using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace FormGenerator.Attributes
{
    public class CustomFieldAttribute : FieldAttribute
    {
        public Control Control { get; set; }
        public CustomFieldAttribute(string id, string name, Type controlType) : base(id, name)
        {
            if (!controlType.IsSubclassOf(typeof(Control)))
            {
                throw new ArgumentException("Given type not derrived control");
            }

            Control = (Control) Activator.CreateInstance(controlType);
        }
    }
}
