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
        public ControlDataType ControlDataType { get; }
        public int DefaultEnum { get; }

        /// <summary>
        /// Adds identifier and custom name (e.g. with spaces) to enum constant.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="name">Field name.</param>
        /// <param name="controlDataType">Type of control to select data</param>
        /// <param name="defaultEnum"></param>
        public EnumFieldAttribute(string id, string name, ControlDataType controlDataType, int defaultEnum) : base(id, name)
        {
            ControlDataType = controlDataType;
            DefaultEnum = defaultEnum;
        }
    }
}
