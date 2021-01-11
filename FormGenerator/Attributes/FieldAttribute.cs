using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Attributes
{
    public abstract class FieldAttribute : Attribute
    {
        public string Id { get; }
        public string Name { get; }

        public FieldAttribute(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
