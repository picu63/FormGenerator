using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormGenerator.Attributes;
using FormGenerator.FormSections;

namespace FormGenerator
{
    public class FormGenerator<T> : Control
    {
        public ControlCollection Sections => this.Controls;
        public FormGenerator()
        {
            _sections = new List<FormSection<T>>();
        }

        private readonly List<FormSection<T>> _sections;

        public FormGenerator<T> AddSection(FormSection<T> section)
        {
            _sections.Add(section);
            return this;
        }


        public FormGenerator<T> CreateForm()
        {
            foreach (var section in _sections)
            {
                section.CreateForm();
                this.Sections.Add(section);
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