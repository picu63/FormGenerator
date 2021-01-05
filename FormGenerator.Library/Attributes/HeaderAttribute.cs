using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Library.Attributes
{
    public class HeaderAttribute : Attribute
    {
        public HeaderAttribute(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
}
