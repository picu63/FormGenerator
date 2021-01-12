using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicTest.Models;
using FormGenerator;
using FormGenerator.FormBuilder;

namespace DynamicTest.Tests
{
    public partial class Test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var modelGenerator = new TableSection<User>();
            modelGenerator.CreateForm();
            dynamicPlaceHolder.Controls.Add(modelGenerator);
        }
    }
}