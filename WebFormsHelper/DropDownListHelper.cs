using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebFormsHelper
{
    public static class DropDownListHelper
    {
        public static DropDownList DropDownListFromEnum<T>() where T : Enum
        {
            var ddl = new DropDownList();
            var enumFields = typeof(T).GetFields();
            foreach (var enumField in enumFields.Skip(1))
            {
                var ddlItem = new ListItem {Value = enumField.Name};
                ddl.Items.Add(ddlItem);
            }
            return ddl;
        }
    }
}