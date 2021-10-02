using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallproblem.Common
{
    public class ResultDTO
    {
        public int NumberOfSimulations { get; set; }
        public int NumberOfWins { get; set; }
        public bool IsStay { get; set; }
        public int NumberOfLosses { get; set; }

    }
}
