using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicTest.Models;
using FormGenerator.FormSections;

namespace DynamicTest.Tests
{
    public partial class ValidationsFormForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var modelGenerator = new FieldsSection<Vehicle>();
            //modelGenerator.CreateForm();
            //dynamicPlaceHolder.Controls.Add(modelGenerator);
            dynamicPlaceHolder.Controls.Add(new FormView(){ItemType = "string"});
        }
    }
}