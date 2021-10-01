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
            int wins = 0;

            ResultDTO resultDTO = new ResultDTO();

            Random gen = new Random();

            for (int plays = 0; plays < numberOfSimulations; plays++)
            {
                int[] doors = { 0, 0, 0 };//0 => goat, 1 => car

                var winner = gen.Next(3);
                doors[winner] = 1; //put a winner in a random door

                int choice = gen.Next(3); //pick a door randomly
                int shownDoor; //the shown door
                do
                {
                    shownDoor = gen.Next(3);
                }
                while (doors[shownDoor] == 1 || shownDoor == choice); //don't show the winner or the choice

                if (isStay)
                {
                    wins += doors[choice]; // won by staying
                }
                else 
                {
                    //the switched (last remaining) door is (3 - choice - shown), because 0+1+2=3
                    wins += doors[3 - choice - shownDoor];
                }
            }

            resultDTO.numberOfSimulations = numberOfSimulations;
            resultDTO.NumberOfWins = wins;
            resultDTO.IsStay = isStay;
            resultDTO.NumberOfLosses = numberOfSimulations - wins;

            return resultDTO;
        }
    }
}
