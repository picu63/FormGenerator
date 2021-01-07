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
        public Control CustomControl { get; set; }
        public CustomFieldAttribute(string id, string name, Control customControl) : base(id, name)
        {
            CustomControl = customControl;
        }
    }
}
