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
        public string PageListLocation { get; }
        public string PlaceHolderId { get; }

        /// <summary>
        /// Adds identifier 
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="name">Field name.</param>
        /// <param name="controlDataType">Type of Control to print values.</param>
        /// <param name="values">Default values - if not set to </param>
        public DataFieldAttribute(string id, string name, ControlDataType controlDataType, string[] values) : base(id, name)
        {
            ControlDataType = controlDataType;
            Values = values;
        }

        /// <summary>
        /// Adds identifier and name of data structure with 
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="name">Field name.</param>
        /// <param name="controlDataType">Type of Control to print values.</param>
        /// <param name="values">Default values - if not set to </param>
        public DataFieldAttribute(string id, string name, string pageListLocation, string placeHolderId) : base(id, name)
        {
            PageListLocation = pageListLocation;
            PlaceHolderId = placeHolderId;
        }
    }

    
    public enum ControlDataType
    {
        ListBox,
        DropDownList,
        PageWithList
    }
}