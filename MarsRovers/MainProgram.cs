using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRovers
{
    class MainProgram
    {
        //Temp Global variables
        private static int RoverInitialXPosition;
        private static int RoverInitialYPosition;
        private static char RoverInitialDirection;
        private static string RoverInitialInstructions;

        private static List<IRover> rover = new List<IRover>();


        
        static void Main()
        {

            Console.WriteLine("Welcome to Mars Rovers program"); // Welcome message

            int TempNumber; // To hold a temporary Int number used to verify if the user didn't enter an unaccepted character
            string TempEntry=string.Empty; //To hold Temp entries by users

            //Get the  total number of rovers to deploy 
            Console.WriteLine("Please Enter the total number of rovers to deploy on the plateau:"); // Prompt for total number of rovers

            //Verify if it's a number or not
            while (!int.TryParse(TempEntry = Console.ReadLine(), out TempNumber))
            {
                Console.WriteLine("Please Enter a valid numerical value!");
            }

           // if we reach this it means a valid number was entered
            for (int i = 0; i < TempNumber; i++)
            {
                rover.Insert(i, new Rover());//Initialize all rovers
            }

            //Get the  X upper-right coordinate of the plateau:
            Console.WriteLine("Please Enter the X upper-right coordinate of the plateau:"); // Prompt for X dimension on the plateau

            while (!int.TryParse(TempEntry = Console.ReadLine(), out TempNumber))
            { 
                Console.WriteLine("Please Enter a valid numerical value!");
            }

            // A valid entry if it reaches this code
            foreach (IRover r in rover) // Loop through List and update the X Of the plateau
            {
                r.XPositionofPlateau = TempNumber;
            }


            //Get the  Y upper-right coordinate of the plateau:
            Console.WriteLine("Please Enter the Y upper-right coordinate of the plateau:"); // Prompt for X dimension on the plateau

            while (!int.TryParse(TempEntry = Console.ReadLine(), out TempNumber))
            {
                Console.WriteLine("Please Enter a valid numerical value!");
            }

            // A valid entry if it reaches this code
            foreach (IRover r in rover) // Loop through List and update the Y Of the plateau
            {
                r.YPositionofPlateau = TempNumber;
            }


            //The input information for all rovers.

            for (int i = 0; i < rover.Count ; i++)
                {
                    //Set the  initial position of the rover
                    Console.WriteLine("Please Enter the initial position of rover number: {0}",i+1); // 
                //Loop until th euser entered the valid format    
                while (!IsValidInputforRoverInitialPosition( Console.ReadLine()))
                    {
                        Console.WriteLine("Please enter a avalid  format! ( x y d ) ");
                        Console.WriteLine("Or check if one of the coordinates is out of bound");
                    }
                    // if we reach this code it means the entry was valid
                     rover[i].LandRoverOnPlateau(RoverInitialDirection, RoverInitialXPosition, RoverInitialYPosition);
            
                


                    //Set the movements instructions
                    Console.WriteLine("Please Enter series of instructions for rover number: {0}", i+1);
                    while (!IsValidListofInstructions( Console.ReadLine()))
                    {
                        Console.WriteLine("Only L l R r M m are valid!");

                    }
                    // if we reach this code it means the entry was valid
                    rover[i].SendInstructionstoRover(RoverInitialInstructions);

                }

            //process all the data and print results:

            for (int i = 0; i < rover.Count; i++)
            {
                rover[i].ProcessNASAInstructions();
                if(rover[i].IsOutofBound)
                {
                    Console.WriteLine("The rover number: {0} is out of bound", i + 1); 

                }
                else 
                {
                    
                    Console.WriteLine("The new poistion for rover number: {0} is  {1} {2} {3}", i + 1, rover[i].XPosition, rover[i].YPosition, rover[i].Direction); 
 
                }
            }
            Console.Read();

            }//End of main()
        
        private static bool IsValidInputforRoverInitialPosition(string input) // to check if the user entered a valid input for the initial position of the rover
        {                  
                   
                    var parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 3 || parts.Length >= 4)
                    {
                        return false;
                    }
                    else
                    {
                        int XofRover, YofRover;

                        string dirInput = parts[2];

                        if (dirInput.Length != 1)
                        {
                            return false;
                        }
                        else
                        {
                            char dir = Char.ToUpper(dirInput[0]);
                            switch (dir)
                            {
                                case 'N':
                                case 'S':
                                case 'E':
                                case 'W':
                                    if (!Int32.TryParse(parts[0], out XofRover) || !Int32.TryParse(parts[1], out YofRover))
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        if (!rover.FirstOrDefault().IsValidIRoverInitialPosition(XofRover,YofRover))
                                            return false;
                                        HoldRoverInitialposition(XofRover, YofRover, dir);
                                        return true;
                                    }
                                default:
                                    return false;    
                            }
                        }
                    }
        }
        private static void HoldRoverInitialposition(int XInitialPosition, int YInitialPosition, char InitialDirection)
        {
            RoverInitialDirection = InitialDirection;
            RoverInitialXPosition = XInitialPosition;
            RoverInitialYPosition = YInitialPosition;
        } //Temp vars to hold th evalues of the rover direction and position
        private static bool IsValidListofInstructions(string input) // to check if the user entered a valid input for the initial position of the rover
        {

           
            bool validInput = input.All(c => "lLrRmM".Contains(c)); //use Linq Enumerable.Contains

            if (!validInput)
                return false;
            else
            {
                RoverInitialInstructions = input; //Hold the value of initial instructions
                return true;
            }
                      
                        
        }

        }

  
    }

