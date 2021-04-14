using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicTest.Models;
using FormGenerator.FormSections;
using FormGenerator = FormGenerator.FormGenerator;

namespace DynamicTest.Tests
{
    public partial class NonGenericTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            global::FormGenerator.FormGenerator formGenerator = new global::FormGenerator.FormGenerator(typeof(User));
            formGenerator.AddSection(new FieldsSection<object>());
            formGenerator.CreateForm();
            dynamicPlaceHolder.Controls.Add(formGenerator);
        }
    }
}