using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Attributes
{
    public abstract class FieldAttribute : Attribute
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Name of field.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Soecifies the data field.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="name">Field name.</param>
        public FieldAttribute(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
