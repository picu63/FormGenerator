using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace FormGenerator.Attributes
{
    /// <summary>
    /// Main attribute for basics data
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NormalFieldAttribute : FieldAttribute
    {
        public VariableType VariableType { get; }
        public string DefaultValue { get; }

        /// <summary>
        /// Field with single value.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="name">Field name.</param>
        /// <param name="variableType">Variable type.</param>
        /// <param name="defaultValue">Default value if no value is set.</param>
        public NormalFieldAttribute(string id, string name, VariableType variableType = VariableType.Unknown, string defaultValue = "") : base(id, name)
        {
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
        PhoneNumber,
        Nip,
    }
}