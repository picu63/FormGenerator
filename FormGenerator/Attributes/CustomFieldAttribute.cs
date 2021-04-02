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
        public Control Control { get; }

        /// <summary>
        /// Custom field - allowing to add custom control next to field.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="name">Field name.</param>
        /// <param name="controlType">Type of control to add. Usually custom control - subclass of control.</param>
        /// <param name="parameters">Parameters to contructor of given control 
        /// - workaround to create instance of class (attributes cannot have objects in parameters)</param>
        public CustomFieldAttribute(string id, string name, Type controlType, params object[] parameters) : base(id, name)
        {
            if (!controlType.IsSubclassOf(typeof(Control)))
            {
                throw new ArgumentException("Given type of class is not sublass of \"Control\" class", nameof(controlType));
            }

            Control = (Control) Activator.CreateInstance(controlType, parameters);
        }
    }
}