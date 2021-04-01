using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebFormsHelper
{
    public static class ListHelper
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

        public static void Fill(ListControl ddl, object[] objects)
        {
            foreach (var o in objects)
            {
                ddl.Items.Add(o.ToString());
            }
        }
    }
}