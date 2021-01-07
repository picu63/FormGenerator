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
        [Field("UserFirstName","First name", VariableType.String, "Imie")]
        public string FirstName { get; set; }
        [Field("UserLastName", "Last name", VariableType.String, "Nazwisko")]
        public string LastName { get; set; }
        [Field("UserType", "Typ użytkownika", VariableType.DropDownMenu)]
        [Required]
        public Rola Rola { get; set; }
        [Field("IsMale?","Meżczyzna?", VariableType.Bool)]
        public bool IsMale { get; set; }
        [Field("PhoneNumber","Numer", VariableType.Nip)]
        public int Number { get; set; }

        public string Testowy { get; set; }
    }

    public enum Rola
    {
        [EnumField("Super administrator")]
        Administrator,
        [EnumField("Kierownik oddziału")]
        Kierownik,
        [EnumField("Klient oddziału")]
        Klient
    }
}