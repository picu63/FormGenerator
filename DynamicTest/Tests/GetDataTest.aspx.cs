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
    public partial class GetDataTest : System.Web.UI.Page
    {
        FormGenerator<User> modelGenerator = new FormGenerator<User>();
        protected void Page_Load(object sender, EventArgs e)
        {
            modelGenerator.AddSection(new FieldsSection<User>());
            modelGenerator.CreateForm();
            var user = new User("Piotr", "Nowak", Rola.Kierownik, true) { Parents = new List<string>() { "janina", "zbyszek" } };
            modelGenerator.FillWithData(user);
            dynamicPlaceHolder.Controls.Add(modelGenerator);
            var obj = modelGenerator.GetData();
        }

        protected void saveButton_OnClick(object sender, EventArgs e)
        {
            var obj = modelGenerator.GetData();
        }
    }
}