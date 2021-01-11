using System;

namespace FormGeneratorFluent.Attributes
{
    public abstract class FieldAttribute: Attribute
    {
        protected string Id { get; }
        protected string Name { get; }

        protected FieldAttribute(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
