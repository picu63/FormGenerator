using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace WebFormsHelper
{
    public static class ControlChildrenHelper
    {
        public static IEnumerable<Control> GetAllChildren(this Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllChildren(ctrl, type))
                .Concat(controls)
                .Where(c => c.GetType() == type);
        }
        public static IEnumerable<Control> GetAllChildren(this Control control)
        {
            var controls = control.Controls.Cast<Control>().ToList();

            return controls.Count == 0 ? new List<Control>() {control} : controls.SelectMany(GetAllChildren)
                .Concat(controls);
        }
    }
}