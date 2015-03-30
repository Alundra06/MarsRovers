
using System.Collections.Generic;
using System.Linq;


namespace MarsRovers
{
    public class Logic : ILogic
    {

       
        public char ChangeDirection(char InitialDirection, char orientation)
        {
           
            char invalidDirection = 'X';
            switch (orientation)
            {
                case 'L': 
                    {
                        switch (InitialDirection)
                        {
                            case 'N': return 'W';
                            case 'W': return 'S';
                            case 'S': return 'E';
                            case 'E': return 'N';
                            default:  return invalidDirection;
                           
                        }
                       
                    }

                case 'R':
                    {
                        switch (InitialDirection)
                        {
                            case 'N': return 'E';
                            case 'E': return 'S';
                            case 'S': return 'W';
                            case 'W': return 'N';
                            default: return invalidDirection;
                          
                        }
                       
                    }
                default:
                    return invalidDirection;

            }



        } //Change the direction of the rover based on the initial position

        public List<int> ChangePosition(int InitialX, int InitialY, char orientation)
        {

            
            switch (orientation)
            {
                case 'N':
                    {
                        InitialY++;
                        break;
                    }
                case 'W':
                    {
                        InitialX--;
                        break;
                    }
                case 'S':
                    {
                        InitialY--;
                        break;
                    }
                case 'E':
                    {
                        InitialX++;
                        break;
                    }

            }

            List<int> NewPosition = new List<int>(2);
            NewPosition.Insert(0, InitialX);
            NewPosition.Insert(1, InitialY);
            return NewPosition;

            

        }//Change the position of th erover (x,y) and return the new position

        public bool IsRoverInstructionOutofBound (int InitialX, int InitialY, char orientation,int TableauX, int TableauY)
        {

           
            
            switch (orientation)
            {
                case 'N':
                    {
                        if (++InitialY > TableauY) return true;
                        break;
                    }
                case 'W':
                    {
                        if (--InitialX < 0) return true; 
                        break;
                    }
                case 'S':
                    {
                        if (--InitialY < 0) return true; 
                        break;
                    }
                case 'E':
                    {
                        if (++InitialX > TableauX) return true;
                        break;
                    }
              

            }
            return false;
          
        }
        
    }
}
