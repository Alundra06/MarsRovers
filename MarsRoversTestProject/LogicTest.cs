using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRovers
{
    [TestClass()]
    public class LogicTests
    {

        //Initializations for all tests
        Logic LogicClassInstance = new Logic();

        
        
        // test Methods
        [TestMethod()]
        //Test if the new instruction for the rover is  out of the bounds of the tableau
        public void IsRoverInstructionNotOutofBoundtest()
        {
            //arrange
            bool NotOutOfBoundexpected = false;
            bool OutOfBoundexpected = true;
            int InitialX=3;
            int InitialY=3;
            char Orientation = 'N';
            int TableauTopX = 5;
            int TableauTopY = 5;

            //Act
            bool actualNotOutofBound = LogicClassInstance.IsRoverInstructionOutofBound(InitialX, InitialY, Orientation, TableauTopX, TableauTopY);
            bool actualOutofBound = LogicClassInstance.IsRoverInstructionOutofBound(InitialX+2, InitialY, Orientation, TableauTopX, TableauTopY);

            //Assert
            Assert.AreEqual(NotOutOfBoundexpected, actualNotOutofBound); //Not out of bound  (3,3) on (5,5) matrix
            Assert.AreEqual(OutOfBoundexpected, actualOutofBound); //out of bound  (5,3) on (5,5) matrix
        }

        [TestMethod()]

        //Test if the new instruction for the rover is  out of the bounds of the tableau
        public void ChangeDirectionLogicTest()
        {
            //arrange
            char expected1 = 'W';
            char expected2 = 'E';
            char InitialDirection = 'N';
            char Orientation1 = 'L';
            char Orientation2 = 'R';
        

            //Act
            char actual1 = LogicClassInstance.ChangeDirection(InitialDirection, Orientation1);
            char actual2 = LogicClassInstance.ChangeDirection(InitialDirection, Orientation2);

            //Assert
            Assert.AreEqual(expected1, actual1); 
            Assert.AreEqual(expected2, actual2); 
        }


        [TestMethod()]
        //Test if the new instruction for the rover is  out of the bounds of the tableau
        public void ChangePositionLogicTest()
        {
            //arrange
            int expectedX1 = 5;
            int expectedX2 = 4;
            int expectedY1 = 5;
            int expectedY2 = 4;
            int initialX = 4;
            int initialY=5;
            char orientation1 = 'N';
            char orientation2 = 'W';

            //Act
            int actualX1 = LogicClassInstance.ChangePosition(initialX, initialY, orientation1)[0];
            int actualY1 = LogicClassInstance.ChangePosition(initialX, initialY, orientation1)[1];
            int actualX2 = LogicClassInstance.ChangePosition(initialX, initialY, orientation2)[0];
            int actualY2 = LogicClassInstance.ChangePosition(initialX, initialY, orientation2)[1];
           

            //Assert
            Assert.AreEqual(expectedX1, actualX1); 
            Assert.AreEqual(expectedY1, actualY1);
            Assert.AreEqual(expectedX2, actualX2);
            Assert.AreEqual(expectedY2, actualY2); 
        }



    }
}
