using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sondergaardholm.Models
{
    public class Fueling
    {
        [Key] public int Id { get; set; }
        [Required] public float Liters { get; set; }
        [Required] public float Kilometers { get; set; }

        public string Date { get; set; }
        public float KilometersPerLiter { get; set; }
    }
}