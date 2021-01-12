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
            _sections = new List<FormSection<T>>();
        }

        private readonly List<FormSection<T>> _sections;
        private readonly  List<FormSection<T>> _sectionsCreated = new List<FormSection<T>>();

        public FormGenerator<T> AddSection(FormSection<T> section)
        {
            _sections.Add(section);
            return this;
        }


        public FormGenerator<T> CreateForms()
        {
            List<Control> controlsToAdd = new List<Control>();
            foreach (var section in _sections)
            {
                section.CreateForm();
                this.Controls.Add(section);
            }
            return this;
        }


        public FormGenerator<T> FillWithData(T @object)
        {
            foreach (var section in _sections)
            {
                section.FillControls(@object);
            }

            return this;
        }
    }
}