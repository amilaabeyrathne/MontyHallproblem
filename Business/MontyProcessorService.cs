using MontyHallproblem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MontyProcessorService : IMontyProcessorService
    {
         /// <summary>
         /// run the main process of get the win count for given number of simulations
         /// </summary>
         /// <param name="numberOfSimulations"></param>
         /// <param name="isStay"></param>
         /// <returns></returns>
        public ResultDTO Processor(int numberOfSimulations, bool isStay)
        {
            int numberOfWins = 0;

            ResultDTO resultDTO = new ResultDTO();

            Random randomGen = new Random();

            for (int simulation = 0; simulation < numberOfSimulations; simulation++)
            {
                int[] doorsArray = { 0, 0, 0 };//0 => goat, 1 => car

                var winnerDoor = randomGen.Next(3);
                doorsArray[winnerDoor] = 1; // winner to a random door

                int pickedDoor = randomGen.Next(3); //pick a door randomly
                int openedFoor; // opend door
                do
                {
                    openedFoor = randomGen.Next(3);
                }
                while (doorsArray[openedFoor] == 1 || openedFoor == pickedDoor); //don't open the winner door or the choosen door

                if (isStay)
                {
                    numberOfWins += doorsArray[pickedDoor]; // won => staying
                }
                else 
                {
                    numberOfWins += doorsArray[3 - pickedDoor - openedFoor];// pick the remaining door
                }
            }

            resultDTO.NumberOfSimulations = numberOfSimulations;
            resultDTO.NumberOfWins = numberOfWins;
            resultDTO.IsStay = isStay;
            resultDTO.NumberOfLosses = numberOfSimulations - numberOfWins;

            return resultDTO;
        }
    }
}
