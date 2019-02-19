using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sondergaardholm.Models
{
    public class Wish
    {
        [Key] public int Id { get; set; }

        [Required] public string Description { get; set; } 
        [Required] public string Link { get; set; }
        [Required] public string Owner { get; set; }
    }
}