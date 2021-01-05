using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace FormGenerator.Attributes
{
    public class FieldAttribute : Attribute
    {
        /// <summary>
        /// Pole w którym określa się właściwości wyświetlonych danych
        /// </summary>
        /// <param name="name">Nazwa pola.</param>
        /// <param name="variableType">Typ zmiennej.</param>
        /// <param name="defaultValue"></param>
        /// <param name="customControl"></param>
        public FieldAttribute(string id, string name, VariableType variableType = VariableType.Unknown, string defaultValue = "")
        {
            Name = name;
            VariableType = variableType;
            DefaultValue = defaultValue;
            if (id.Any(char.IsWhiteSpace))
                throw new Exception("Id cannot contains white spaces");
            Id = id;
        }
        
        public FieldAttribute(string id, string name, Control customControl)
        {
            Name = name;
            CustomControl = customControl;
            VariableType = VariableType.CustomControl;
            if (id.Any(char.IsWhiteSpace))
                throw new Exception("Id cannot contains white spaces");
            Id = id;
        }

        public string Id { get; }
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
        CustomControl
    }
}