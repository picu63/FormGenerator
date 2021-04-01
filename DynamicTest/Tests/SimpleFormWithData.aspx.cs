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
            var modelGenerator = new TableSection<User>();
            modelGenerator.CreateForm();
            modelGenerator.FillControls(new User("Piotr", "Nowak", Rola.Kierownik, true, 30));
            dynamicPlaceHolder.Controls.Add(modelGenerator);
        }
    }
}