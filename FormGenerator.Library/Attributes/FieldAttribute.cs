using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace FormGenerator.Library.Attributes
{
    public class FieldAttribute : Attribute
    {
        /// <summary>
        /// Pole w którym określa się właściwości wyświetlonych danych
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variableType"></param>
        /// <param name="defaultValue"></param>
        /// <param name="customControl"></param>
        public FieldAttribute(string name, VariableType variableType, string defaultValue = "")
        {
            Name = name;
            VariableType = variableType;
            DefaultValue = defaultValue;
        }

        public FieldAttribute(string name, Control customControl)
        {
            Name = name;
            CustomControl = customControl;
            VariableType = VariableType.MultiControl;
        }
        public string Name { get; }
        public Control CustomControl { get; }
        public VariableType VariableType { get; }
        public string DefaultValue { get; }
    }

    public enum VariableType
    {
        Unknown,
        String,
        Int,
        Bool,
        DropDownMenu,
        Nip,
        MultiControl
    }
}