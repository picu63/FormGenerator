using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Attributes
{
    public class DataFieldAttribute : FieldAttribute
    {
        public ControlDataType ControlDataType { get; }
        public string[] Values { get; }

        public DataFieldAttribute(string id, string name, ControlDataType controlDataType, string[] values) : base(id, name)
        {
            ControlDataType = controlDataType;
            Values = values;
        }
    }

    
    public enum ControlDataType
    {
        ListBox,
        DropDownList,
        PageWithList
    }
}