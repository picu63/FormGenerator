﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Attributes
{
    public class EnumFieldAttribute : FieldAttribute
    {
        /// <summary>
        /// Adds identifier and custom name (e.g. with spaces) to enum constant.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="name">Field name.</param>
        public EnumFieldAttribute(string id, string name) : base(id, name)
        {
        }
    }
}
