using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using FormGenerator.Attributes;

namespace FormGenerator
{
    public class FormGenerator<T> : Control
    {
        public List<FormSection<T>> Sections { get; } = new List<FormSection<T>>();
        public FormGenerator<T> AddSection(FormSection<T> section)
        {
            Sections.Add(section);
            return this;
        }

        public FormGenerator<T> FillWithData(T @object)
        {
            var properties = @object.GetType().GetProperties()
                .Where(p => p.GetCustomAttribute<FieldAttribute>() != null).ToList();
            foreach (var propertyInfo in properties)
            {
                
            }

            return this;
        }

        public FormGenerator<T> CreateForm()
        {
            List<Control> controlsToAdd = new List<Control>();
            foreach (var section in Sections)
            {
                section.CreateForm();
                controlsToAdd.AddRange(section.Controls.Cast<Control>());
            }

            foreach (var control in controlsToAdd)
            {
                this.Controls.Add(control);
            }

            return this;
        }
    }
}