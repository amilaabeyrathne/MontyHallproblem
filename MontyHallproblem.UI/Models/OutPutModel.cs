using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontyHallproblem.Models
{
    public class OutPutModel
    {
        public int NumberOfSimulations { get; set; }
        public int NumberOfWins { get; set; }
        public string StayResult { get; set; }
        public int NumberOfLosses { get; set; }
    }
}