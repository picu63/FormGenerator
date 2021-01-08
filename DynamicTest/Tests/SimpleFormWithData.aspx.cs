using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicTest.Models;
using FormGenerator;

namespace DynamicTest.Tests
{
    public partial class Test02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var modelGenerator = new ModelGenerator<User>(new User("Piotr", "Olearczyk", Rola.Administrator, true, 123124235));
            modelGenerator.CreateForm();
            dynamicPlaceHolder.Controls.Add(modelGenerator);
        }
    }
}