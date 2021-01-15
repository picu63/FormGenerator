using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using FormGenerator.Attributes;
using WebFormsHelper;

namespace FormGenerator.FormSections
{
    public abstract class FormSection<T> : Control
    {
        protected IEnumerable<Control> ControlsAdded=>this.GetAllChildren()
                .Where(c => FieldsAttributes.Select(f => f.Id).Contains(c.ID));

        protected HeaderAttribute HeaderAttribute
        {
            get
            {
                var headerAttribute = typeof(T)
                    .GetCustomAttribute<HeaderAttribute>();
                if (headerAttribute is null)
                {
                    throw new ArgumentNullException(nameof(headerAttribute), $"Class {typeof(T).FullName} for building dynamically have to has {nameof(HeaderAttribute)}");
                }

                return headerAttribute;
            }
        }

        protected IEnumerable<FieldAttribute> FieldsAttributes => typeof(T)
                    .GetProperties()
                    .Select(p => p.GetCustomAttribute<FieldAttribute>())
                    .Where(p => p != null);

        public abstract void CreateForm();

        /// <summary>
        /// Uzupełnia wszystkie dodane kontrolki o podany obiekt.
        /// </summary>
        public abstract void FillControls(T @object);
    }
}
