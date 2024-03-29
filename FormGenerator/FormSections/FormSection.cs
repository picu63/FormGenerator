﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormGenerator.Attributes;
using WebFormsHelper;

namespace FormGenerator.FormSections
{
    public abstract class FormSection<T> : Control, IFieldGetter
    {
        public Type GenericType => typeof(T);
        /// <summary>
        /// All data/value types controls
        /// </summary>
        public IEnumerable<Control> ControlsAdded=>this.GetAllChildren()
                .Where(c =>
                {
                    var fieldAttributes = FieldsAttributes.ToList();
                    return fieldAttributes.Select(f => f.Id).Contains(c.ID);
                }).Distinct(); // Don't know why gets double controls in output

        protected Control GetControlById(string id) => ControlsAdded.FirstOrDefault(c => c.ID == id);
        public FieldAttribute GetFieldAttributeById(string id) => FieldsAttributes.First(f => f.Id == id);
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
        public virtual void FillControls(T @object) { }

        public PropertyInfo GetPropertyByFieldAttributeId(string id) => typeof(T).GetProperties().First(p =>
        {
            var fieldAttribute = p.GetCustomAttributes<FieldAttribute>().First();
            if (fieldAttribute.Id == id)
            {
                return true;
            }

            return false;
        });
    }

    public interface IFieldGetter
    {
        FieldAttribute GetFieldAttributeById(string id);
        PropertyInfo GetPropertyByFieldAttributeId(string id);
    }
}
