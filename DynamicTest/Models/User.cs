using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicTest.CustomControls;
using FormGenerator.Attributes;

namespace DynamicTest.Models
{
    [Header("Edit User")]
    public class User
    {
        [NormalField("UserFirstName","First name", VariableType.String) ]
        public string FirstName { get; set; }
        [NormalField("UserLastName", "Last name",VariableType.String)]
        public string LastName { get; set; }

        [EnumField("userRola", "Role", ControlDataType.DropDownList, (int)Models.Role.Manager)]
        public Role Role { get; set; }
        [DataField("userParents", "Parents", ControlDataType.ListBox, new[] { "Value1", "Value2" })]
        public List<string> Parents { get; set; } = new List<string>() { "Janina Kosogłów", "Antonii Kosogłów" };
        [NormalField("IsMale?","Is Male?", VariableType.Bool)]
        public bool IsMale { get; set; }
        //TODO textbox for integer values
        [NormalField("NipNumber", "Numer NIP", VariableType.Nip)]
        public int NipNumber { get; set; }
        [DataField("provilance", "Województwo", ControlDataType.DropDownList, new[] { "śląskie", "małopolskie", "opolskie", "mazowieckie" })]
        public List<string> Provilance { get; set; }
        [CustomField("customId", "Custom control", typeof(MyButton), "Custom control")]
        public object TestObject { get; set; }
        public string NotVisibleField { get; set; }
    }

    public enum Role
    {
        [EnumValueField("enumAdministrator","Super administrator")]
        Administrator = 0,
        [EnumValueField("enumManager", "Branch Manager")]
        Manager = 1,
        [EnumValueField("enumClient", "Branch Client")]
        Client = 2,
    }
}