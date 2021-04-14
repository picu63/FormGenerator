using System;
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
    public class FormGenerator : FormGenerator<object> 
    {
        private readonly Type _type;

        public FormGenerator(Type type)
        {
            _type = type;
        }

        public override FormGenerator<object> AddSection(FormSection<object> section)
        {
            CheckType(section.GenericType);
            return base.AddSection(section);
        }

        public override FormGenerator<object> FillWithData(object @object)
        {
            CheckType(@object.GetType());
            return base.FillWithData(@object);
        }

        public override object GetData()
        {
            var @obj = base.GetData();
            CheckType(@obj.GetType());
            return @obj;
        }

        private void CheckType(Type type)
        {
            if (type != _type)
            {
                //throw new ArgumentException($"Invalid argument type");
            }
        }
    }
    public class FormGenerator<T> : Control
    {
        public ControlCollection CreatedSections => this.Controls;
        public FormGenerator()
        {
            Sections = new List<FormSection<T>>();
        }

        protected readonly List<FormSection<T>> Sections;

        /// <summary>
        /// Adds custom sections to <see cref="FormGenerator{T}"/>.
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public virtual FormGenerator<T> AddSection(FormSection<T> section)
        {
            Sections.Add(section);
            return this;
        }

        /// <summary>
        /// Creates a form control with all subcontrols.
        /// </summary>
        /// <returns></returns>
        public virtual FormGenerator<T> CreateForm()
        {
            foreach (var section in Sections)
            {
                section.CreateForm();
                this.CreatedSections.Add(section);
            }
            return this;
        }

        /// <summary>
        /// Fills form with data from given object
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public virtual FormGenerator<T> FillWithData(T @object)
        {
            foreach (var section in Sections)
            {
                section.FillControls(@object);
            }

            return this;
        }

        public virtual T GetData()
        {
            var controlsGetter = new ControlsGetter<T>(new ControlGetter());
            T @object = default;
            foreach (var section in CreatedSections.Cast<FormSection<T>>())
            {
                @object = controlsGetter.Get(section.ControlsAdded);
            }

            return @object;
        }
    }
}