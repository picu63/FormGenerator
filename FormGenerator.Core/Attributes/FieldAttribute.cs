using System;
using System.Collections.Generic;
using System.Text;

namespace FormGenerator.Core.Attributes
{
    public class FieldAttribute : Attribute
    {
        public string FieldName { get; }
        public VariableType VariableType { get; }
        public string DefaultValue { get; }

        public FieldAttribute(string fieldName, VariableType variableType, string defaultValue = "")
        {
            FieldName = fieldName;
            VariableType = variableType;
            DefaultValue = defaultValue;
        }
    }

    public enum VariableType
    {
        Unknown,
        String,
        Int,
        Bool,
        DropDownMenu,
        Nip
    }
}
