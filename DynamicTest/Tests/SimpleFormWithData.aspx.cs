using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicTest.Models;
using FormGenerator;
using FormGenerator.FormSections;

namespace DynamicTest.Tests
{
    public partial class Test02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var modelGenerator = new FieldsSection<User>();
            modelGenerator.CreateForm();
            var user = new User() { FirstName = "Erich", LastName = "Gamma", Role = Role.Administrator, IsMale = true};
            modelGenerator.FillControls(user);
            dynamicPlaceHolder.Controls.Add(modelGenerator);
        }
    }
}