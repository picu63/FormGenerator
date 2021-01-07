using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
        [NormalField("UserFirstName","First name", VariableType.String, "Imie")]
        public string FirstName { get; set; }
        [NormalField("UserLastName", "Last name", VariableType.String, "Nazwisko")]
        public string LastName { get; set; }
        [Required]
        [DataField("rolaEnum","Rola", ControlDataType.DropDownList)]
        public Rola Rola { get; set; }
        [NormalField("IsMale?","Meżczyzna?", VariableType.Bool)]
        public bool IsMale { get; set; }
        [NormalField("PhoneNumber","Numer", VariableType.Nip)]
        public int Number { get; set; }

        public string Testowy { get; set; }
    }

    public enum Rola
    {
        [EnumField("enumAdministrator","Super administrator")]
        Administrator,
        [EnumField("enumKierownik","Kierownik oddziału")]
        Kierownik,
        [EnumField("enumKlient","Klient oddziału")]
        Klient
    }
}