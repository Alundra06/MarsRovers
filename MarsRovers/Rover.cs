using System;
using System.Collections.Generic;

namespace MarsRovers
{
    public class Rover : IRover
    {

        private ILogic LogicClass;
        public bool IsOutofBound{ get; set; }
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
           ListOfNasaInstructions = new List<char>();
           LogicClass = new Logic();
           IsOutofBound = false;
        }
        public void ProcessNASAInstructions()
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

        



    }
        
}
