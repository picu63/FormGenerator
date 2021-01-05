using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormGenerator
{
    public abstract class FormGenerator : UserControl
    {
        public Button SaveButton { get; set; }
        public Button DeleteButton { get; set; }
        public Table FormTable { get; set; }
        public abstract void CreateForm();
    }
}
