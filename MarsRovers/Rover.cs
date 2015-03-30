using System;
using System.Collections.Generic;

namespace MarsRovers
{
    public class Rover : IRover
    {

        private ILogic LogicClass;
        public bool IsOutofBound{ get; set; } // To hold the value of the rover: True = the rover is out of bound , false = Not out of bounds
        public int XPosition  { get; set; } // The current X position of our rover
        public int YPosition { get; set; } // The current Y position of our Rover
        public int XPositionofPlateau { get; set; } // The upper-right X position of the pleateau
        public int YPositionofPlateau { get; set; } // The upper-right Y position of the pleateau
        public List<char> ListOfNasaInstructions { get; set; } // A valid list of instructions sent from NASA 
        public char Direction { get; set; } // The direction of our Rover N, S, W or E
        public void ChangePosition(int XPosition, int YPosition) //Change the position of our Rover giving an X,Y position
        {
            this.XPosition = XPosition;
            this.YPosition = YPosition;
        
        }

        public void ChangeDirection(char Direction) //Change the direction of our Rover 
        {
            this.Direction = Char.ToUpper(Direction);
        }

        public Rover()//The constructor
        {
           //Initializations 
           ListOfNasaInstructions = new List<char>();
           LogicClass = new Logic();  //I could Implement IoC if I have more time
           IsOutofBound = false;  //By default , the rover is NOT out of bound
        }
        public void ProcessNASAInstructions() //process the NASA instructions
        {
            //Loop trough the list of instructions char
            int i=0;
                while (i<ListOfNasaInstructions.Count && !IsOutofBound)
            {
                switch (ListOfNasaInstructions[i])
                {
                    case 'L':
                        { 
                       ChangeDirection( LogicClass.ChangeDirection(Direction, 'L'));
                       break;
                        }

                    case 'R':
                        {
                            ChangeDirection(LogicClass.ChangeDirection(Direction, 'R'));
                            break;
                        }

                    case 'M':
                        {
                            if(LogicClass.IsRoverInstructionOutofBound(XPosition,YPosition,Direction,XPositionofPlateau,YPositionofPlateau))
                            {
                                IsOutofBound = true;
                                break;
                            }
                            else
                            {
                                List<int> NewXY = LogicClass.ChangePosition(XPosition, YPosition, Direction);
                                ChangePosition(NewXY[0], NewXY[1]);
                                break;
                            }
                            

                        }

                }
                i++;

            }
        }

        public bool IsValidIRoverInitialPosition(int XofRover,int YofRover) // Check if the initial position of the rover is not out of bound
        {
            if (XofRover >XPositionofPlateau || YofRover > YPositionofPlateau)
                return false;
            else
                return true;
        }
        public void LandRoverOnPlateau(char direction, int XofRover, int YofRover)
        {
           Direction = char.ToUpper(direction);
           XPosition = XofRover;
           YPosition = YofRover;
        } // Change the X, Y and direction of a rover

        public  void SendInstructionstoRover(string ListofInstructions)
        {
            for (int i = 0; i < ListofInstructions.Length; i++)
            {

                ListOfNasaInstructions.Add(char.ToUpper(ListofInstructions[i]));
            }

        }

    }
        
}
