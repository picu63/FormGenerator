using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FormGenerator.Attributes;

namespace DynamicTest.Models
{
    [Header("Pojazd")]
    public class Vehicle
    {
        [NormalField("vehicleMake", "Marka", VariableType.String)]
        public string Make { get; set; }

        [MaxLength(10)]
        [NormalField("vehicleModel", "Model", VariableType.String)]
        public string Model { get; set; }
        
        [NormalField("vehicleYear", "Rok produkcji", VariableType.Int)]
        public int Year { get; set; }

        [DataType(DataType.Currency)]
        [NormalField("vehiclePrice", "Cena pojazdu", VariableType.Int)]
        public int Price { get; set; } = 1234;
        public Vehicle()
        {
            Make = Model = "Unknown";
            Year = 0;
        }

        public Vehicle(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public override string ToString()
        {
            return string.Format("Vehicle is {0} and of model {1} and is made in {2}.", Make, Model, Year);
        }
    }
}