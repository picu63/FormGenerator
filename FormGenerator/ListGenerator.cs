using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormGenerator
{
    public class ListGenerator<T>: Page
    {
        public IEnumerable<T> Objects { get; }
        public ListGenerator() { }
        public ListGenerator(IEnumerable<T> objects)
        {
            Objects = objects;
            Page_Load();
        }

        protected void Page_Load()
        {
            foreach (var o in Objects)
            {
                var control = new Label();
                control.Text = o.ToString();
            }
        }
    }
}
