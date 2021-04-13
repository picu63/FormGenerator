using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataFieldAttribute : FieldAttribute
    {
        public ControlDataType ControlDataType { get; }
        public string[] Values { get; }
        public string PageListLocation { get; }

        /// <summary>
        /// Adds identifier 
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="name">Field name.</param>
        /// <param name="controlDataType">Type of Control to print values.</param>
        /// <param name="defaultValues">Default values - if property value not set</param>
        public DataFieldAttribute(string id, string name, ControlDataType controlDataType, string[] defaultValues) : base(id, name)
        {
            ControlDataType = controlDataType;
            Values = defaultValues;
        }

        /// <summary>
        /// Adds identifier and name of data structure with aspx file location
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="name">Field name.</param>
        /// <param name="pageListLocation"></param>
        /// <param name="placeHolderId"></param>
        public DataFieldAttribute(string id, string name, string pageListLocation) : base(id, name)
        {
            PageListLocation = pageListLocation;
            throw new NotImplementedException();
        }
    }

    public enum ControlDataType
    {
        ListBox,
        DropDownList,
        PageWithList
    }
}