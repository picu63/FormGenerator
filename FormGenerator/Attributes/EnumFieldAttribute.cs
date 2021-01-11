using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Attributes
{
    public class EnumFieldAttribute : FieldAttribute
    {
        public EnumFieldAttribute(string id, string name) : base(id, name)
        {
        }
    }
}
