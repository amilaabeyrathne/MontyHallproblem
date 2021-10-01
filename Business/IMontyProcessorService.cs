
using MontyHallproblem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IMontyProcessorService
    {
        ResultDTO Processor(int numberOfSimulations, bool isStay);
    }
}
