using System;
using System.Web.UI;
using DynamicTest.Models;
using FormGenerator;
using FormGenerator.FormBuilder;

namespace DynamicTest.Tests
{
    public partial class FluentGenerator : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           dynamicPH.Controls.Add(new FormGenerator<User>()
                .AddSection(new TableSection<User>())
                .AddSection(new ButtonsSection<User>())
                .CreateForms()
                .FillWithData(new User("Pietrek", "Zylka", Rola.Klient, true, 39)));
        }
    }
}