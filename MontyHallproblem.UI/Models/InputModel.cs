using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontyHallproblem.Models
{
    public class InputModel
    {
        [Required(ErrorMessage = "Required !!!")]
        [Range(0,10000000)]
        public int NumberOfSimulations { get; set; }
        public string IsStay { get; set; }
    }
}