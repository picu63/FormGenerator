using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Attributes
{
    /// <summary>
    /// Attribute for each of enum value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValueFieldAttribute : FieldAttribute
    {
        public EnumValueFieldAttribute(string id, string name) : base(id, name)
        {
        }
    }
}
