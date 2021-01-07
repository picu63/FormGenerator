using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicTest.Models;
using FormGenerator;

namespace DynamicTest
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormGenerator.FormGenerator modelGenerator = new ModelGenerator<User>(new User()
                {
                    FirstName = "Piotr",
                    LastName = "Olearczyk",
                    Rola = Rola.Administrator,
                    IsMale = true
                });
            modelGenerator.CreateForm();
            this.dynamicPlaceHolder.Controls.Add(modelGenerator);
        }
    }
}