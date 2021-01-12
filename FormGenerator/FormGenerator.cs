using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormGenerator.Attributes;
using FormGenerator.FormBuilder;

namespace FormGenerator
{
    public class FormGenerator<T> : Control
    {
        public FormGenerator()
        {
            Sections = new List<FormSection<T>>();
        }

        private List<FormSection<T>> Sections { get; }
        public FormGenerator<T> AddSection(FormSection<T> section)
        {
            Sections.Add(section);
            return this;
        }


        public FormGenerator<T> CreateForms()
        {
            List<Control> controlsToAdd = new List<Control>();
            foreach (var section in Sections)
            {
                section.CreateForm();
                controlsToAdd.AddRange(section.Controls.Cast<Control>());
            }
            AddControlsToFormGenerator(controlsToAdd);
            return this;
        }

        private void AddControlsToFormGenerator(IEnumerable<Control> controlsToAdd)
        {
            foreach (var control in controlsToAdd)
            {
                this.Controls.Add(control);
            }
        }


        public FormGenerator<T> FillWithData(T @object)
        {
            foreach (var section in Sections)
            {
                section.FillControls(@object);
            }

            return this;
        }
    }
}