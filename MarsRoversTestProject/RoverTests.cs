using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRovers;
using System.Collections.Generic;

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

       [TestMethod()]
        public void ChangePositionTest()
        {
            //arrange
            int expectedX = 4;
            int expectedY = 6;


            //Act
            GetRoverInstance.ChangePosition(4, 6);
            int actualX = GetRoverInstance.XPosition;
            int actualY = GetRoverInstance.YPosition;

            //Assert
            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);
        }


       [TestMethod()]
       public void IsValidIRoverInitialPositionTest()
       {
           //arrange
           bool expected = true;

           //Act
           GetRoverInstance.XPositionofPlateau = 5;
           GetRoverInstance.YPositionofPlateau = 5;

           bool actual = GetRoverInstance.IsValidIRoverInitialPosition(4,3);
           //Assert
           Assert.AreEqual(expected, actual);
       }



       [TestMethod()]
       public void IsNotValidRoverInitialPositionTest()
       {
           //arrange
           bool expected = false;

           //Act
           GetRoverInstance.XPositionofPlateau = 5;
           GetRoverInstance.YPositionofPlateau = 5;

           bool actual = GetRoverInstance.IsValidIRoverInitialPosition(6, 3);
           //Assert
           Assert.AreEqual(expected, actual);
       }


       [TestMethod()]
       public void LandRoverOnPlateauTest()
       {
           //arrange
           GetRoverInstance.Direction = 'L';
           GetRoverInstance.XPosition = 6;
           GetRoverInstance.YPosition = 8;
           
           char expectedDirection = 'N';
           int ExpectedX = 5;
           int ExpectedY = 5;


           //Act
          
           GetRoverInstance.LandRoverOnPlateau('n', 5, 5);
           char actualDirection = GetRoverInstance.Direction;
           int actualX = GetRoverInstance.XPosition;
           int actualY = GetRoverInstance.YPosition;

           //Assert
           Assert.AreEqual(expectedDirection, actualDirection);
           Assert.AreEqual(ExpectedX, actualX);
           Assert.AreEqual(ExpectedY, actualY);
       }

       [TestMethod()]
       public void SendInstructionstoRoverTest()
       {
           //arrange
           List<char> expected = new List<char>();
           expected.Add('M');
           expected.Add('L');
           expected.Add('R');
           expected.Add('M');
           expected.Add('R');

           //Act
           GetRoverInstance.SendInstructionstoRover("MLRMR");
           List<char> actual = GetRoverInstance.ListOfNasaInstructions;

           //Assert
           Assert.AreEqual(expected.ToString(), actual.ToString());
       }
    }
}
