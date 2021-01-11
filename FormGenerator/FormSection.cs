using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormGenerator.Attributes;

namespace FormGenerator
{
    public abstract class FormSection<T> : Control, IFinishedSection
    {
        private IEnumerable<Control> ControlsAdded=>this.GetAllChildren()
                .Where(c => FieldsAttributes.Select(f => f.Id).Contains(c.ID));

        protected IEnumerable<FieldAttribute> FieldsAttributes => typeof(T)
                    .GetProperties()
                    .Select(p => p.GetCustomAttribute<FieldAttribute>())
                    .Where(p => p != null);

        public abstract IFinishedSection CreateForm();
    }
}
