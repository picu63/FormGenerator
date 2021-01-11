using System;

namespace FormGeneratorFluent.Attributes
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
