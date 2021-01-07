using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Attributes
{
    public class EnumFieldAttribute : Attribute
    {
        public string Name { get; }

        public EnumFieldAttribute(string name)
        {
            Name = name;
        }
    }
}
