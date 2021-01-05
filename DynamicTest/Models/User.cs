using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FormGenerator.Library.Attributes;

namespace DynamicTest.Models
{
    [Header("Użytkownik")]
    public class User
    {
        [Field("First name", VariableType.String, "Imie")]
        public string FirstName { get; set; }
        [Field("Last name", VariableType.String, "Nazwisko")]
        public string LastName { get; set; }
        [Field("Typ użytkownika", VariableType.DropDownMenu)]
        public Rola Type { get; set; }
        [Field("Meżczyzna?", VariableType.Bool)]
        public bool IsMale { get; set; }
        [Field("Numer", VariableType.Nip)]
        public int Number { get; set; }
    }

    public enum Rola
    {
        Administrator,
        Kierownik,
        Klient
    }
}