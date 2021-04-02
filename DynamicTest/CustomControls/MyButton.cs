using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DynamicTest.CustomControls
{
    public class MyButton : Button
    {
        public MyButton(string text)
        {
            base.Text = text;
        }
    }
}