using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormGenerator
{
    static class ControlsHelper
    {
        public static IEnumerable<Control> GetAllChildren(Control control, Type type)
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
