﻿using System;
using System.Web.UI;
using DynamicTest.Models;
using FormGenerator;
using FormGenerator.FormSections;

namespace DynamicTest.Tests
{
    public partial class FluentGenerator : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dynamicPH.Controls.Add(new FormGenerator<User>()
                .AddSection(new FieldsSection<User>())
                .AddSection(new ButtonsSection<User>())
                .CreateForm()
                .FillWithData(new User() {FirstName = "Ralph", LastName = "Johnson", Role = Role.Administrator, IsMale = true}));
        }
    }
}