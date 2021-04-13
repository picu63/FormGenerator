using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DynamicTest.CustomControls;
using FormGenerator.Attributes;

namespace DynamicTest.Models
{
    [Header("Użytkownik")]
    public class User
    {
        public User() { }
        public User(string firstName, string lastName, Rola rola, bool isMale, int number)
        {
            FirstName = firstName;
            LastName = lastName;
            Rola = rola;
            IsMale = isMale;
            Number = number;
        }
        [NormalField("UserFirstName","First name", VariableType.String) ]
        public string FirstName { get; set; }
        [NormalField("UserLastName", "Last name",VariableType.String)]
        public string LastName { get; set; }

        [EnumField("userRola", "Rola", ControlDataType.DropDownList, (int)Models.Rola.Kierownik)]
        public Rola Rola { get; set; }
        [DataField("userParents", "Parents", ControlDataType.ListBox, new[] { "Value1", "Value2" })]
        public List<string> Parents { get; set; } = new List<string>(){"Janina Kosogłów", "Antonii Kosogłów"};
        [NormalField("IsMale?","Meżczyzna?", VariableType.Bool)]
        public bool IsMale { get; set; }
        [NormalField("PhoneNumber","Numer", VariableType.Nip)]
        public int Number { get; set; }
        [DataField("provilance", "Województwo", ControlDataType.DropDownList, new []{"śląskie", "małopolskie", "opolskie", "mazowieckie"})]
        public List<string> Provilance { get; set; }
        [CustomField("customId", "Custom control", typeof(MyButton), "Custom control")]
        public object TestObject { get; set; }
        public string NotVisibleField { get; set; }
    }

    public enum Rola
    {
        [EnumValueField("enumAdministrator","Super administrator")]
        Administrator = 0,
        [EnumValueField("enumKierownik","Kierownik oddziału")]
        Kierownik = 1,
        [EnumValueField("enumKlient","Klient oddziału")]
        Klient = 2,
    }
}