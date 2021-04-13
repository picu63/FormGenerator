using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormGenerator.Attributes;
using FormGenerator.FormGetter;
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

        /// <summary>
        /// Adds custom sections to <see cref="FormGenerator{T}"/>.
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public FormGenerator<T> AddSection(FormSection<T> section)
        {
            _sections.Add(section);
            return this;
        }

        /// <summary>
        /// Creates a form control with all subcontrols.
        /// </summary>
        /// <returns></returns>
        public FormGenerator<T> CreateForm()
        {
            foreach (var section in _sections)
            {
                section.CreateForm();
                this.Sections.Add(section);
            }
            return this;
        }

        /// <summary>
        /// Fills form with data from given object
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public FormGenerator<T> FillWithData(T @object)
        {
            foreach (var section in _sections)
            {
                section.FillControls(@object);
            }

            return this;
        }

        public T GetData()
        {
            var controlsGetter = new ControlsGetter<T>(new ControlGetter());
            T @object = default;
            foreach (var section in Sections.Cast<FormSection<T>>())
            {
                @object = controlsGetter.Get(section.ControlsAdded);
            }

            return @object;
        }
    }
}