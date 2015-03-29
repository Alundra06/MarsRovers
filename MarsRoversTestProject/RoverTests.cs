using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRovers
{
    [TestClass()]
    public class RoverTests
    {

        //Initializations
        Rover GetRoverInstance = new Rover();

        // test Methods
        [TestMethod()]
        public void ChangeDirectionTest()
        {
            //arrange
            char expected = 'L';
           

            //Act
            GetRoverInstance.ChangeDirection('l');
            char actual = GetRoverInstance.Direction;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
