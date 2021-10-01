using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MontyHallproblem.Test
{
    [TestClass]
    public class MontyHallProblemProcessTest
    {
        private readonly MontyProcessorService _montyProcessorService;
        public MontyHallProblemProcessTest()
        {
            this._montyProcessorService = new MontyProcessorService();
        }

        [TestMethod]
        [TestCase(1000)]
        [TestCase(100000)]
        [TestCase(1000000)]
        public void Processor_StayingSameDoor_WinIsGreaterThanLoss(int numberOfIterations)
        {
            bool stay = true;
            var result = this._montyProcessorService.Processor(numberOfIterations, stay);

            Assert.IsTrue(result.NumberOfWins > result.NumberOfLosses);
        }

        [TestMethod]
        [TestCase(7)]
        [TestCase(1000)]
        [TestCase(100000)]
        [TestCase(10000000)]
        public void Processor_StayingSameDoor_LossIsGreaterThanWin(int numberOfIterations)
        {
            bool stay = true;

            var result = this._montyProcessorService.Processor(numberOfIterations, stay);

            Assert.IsTrue(result.NumberOfLosses > result.NumberOfWins);
        }

        [TestMethod]
        public void Processor_StayingSameDoor_LossIsEqualToWin()
        {
            int numberOfIterations = 100000;
            bool stay = true;

            var result = this._montyProcessorService.Processor(numberOfIterations, stay);

            Assert.Equals(result.NumberOfLosses, result.NumberOfWins);
        }

        [TestMethod]
        [TestCase(1000)]
        [TestCase(100000)]
        [TestCase(1000000)]
        public void Processor_ChangingDoor_WinIsGreaterThanLoss(int numberOfIterations)
        {
            bool stay = false;
            var result = this._montyProcessorService.Processor(numberOfIterations, stay);

            Assert.IsTrue(result.NumberOfWins > result.NumberOfLosses);
        }

        [TestMethod]
        public void Processor_ChangingDoor_LossIsGreaterThanWin()
        {
            int numberOfIterations = 100000;
            bool stay = false;

            var result = this._montyProcessorService.Processor(numberOfIterations, stay);

            Assert.IsTrue(result.NumberOfLosses > result.NumberOfWins);
        }
    }
}
