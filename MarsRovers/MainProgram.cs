using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRovers
{
    class MainProgram
    {
        //Global variables
        private static int RoverInitialXPosition;
        private static int RoverInitialYPosition;
        private static char RoverInitialDirection;
        private static string RoverInitialInstructions;

        private static List<IRover> rover = new List<IRover>();


        
        static void Main()
        {

            Console.WriteLine("Welcome to Mars Rovers program"); // Welcome message

            int TempNumber; // To hold a temporary Int number used to verify if the user didn't enter bad entries
            string TempEntry=string.Empty;

            //Get the  total number of rovers to deploy 
            Console.WriteLine("Please Enter the total number of rovers to deploy on the plateau:"); // Prompt for total number of rovers

            while (!int.TryParse(TempEntry = Console.ReadLine(), out TempNumber))
            {
                Console.WriteLine("Please Enter a valid numerical value!");
            }
           //  A valid number was entered
            for (int i = 0; i < TempNumber; i++)
            {
                rover.Insert(i, new Rover());//Insert a new rover
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
                    while (!IsValidInputforRoverInitialPosition())
                    {
                        Console.WriteLine("Please enter a avalid  format! ( x y d ) ");
                        Console.WriteLine("Or check if one of the coordinates is out of bound");
                    }
                    // if we reach this code it means the entry was valid
                    LandRoverOnPlateau(rover[i]); //Add rover to the plateau


                    //Set the movements instructions
                    Console.WriteLine("Please Enter series of instructions for rover number: {0}", i+1);
                    while (!IsValidListofInstructions())
                    {
                        Console.WriteLine("Only L, R and M are valid!");
                    
                    }
                    // if we reach this code it means the entry was valid
                    SendInstructionstoRover(rover[i]);
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

                    private static void SendInstructionstoRover(IRover rover)
                    {
                        for (int i = 0; i < RoverInitialInstructions.Length; i++)
                        {
                            
                            rover.ListOfNasaInstructions.Add(char.ToUpper(RoverInitialInstructions[i]));
                        }
           
                    }
                    private static bool IsValidInputforRoverInitialPosition() // to check if the user entered a valid input for the initial position of the rover
                    {
                                  
                                string input = Console.ReadLine();
                                var parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                if (parts.Length < 3 || parts.Length >= 4)
                                {
                                    return false;
                                }
                                else
                                {
                                    int num1, num2;

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
                                                if (!Int32.TryParse(parts[0], out num1) || !Int32.TryParse(parts[1], out num2))
                                                {
                                                    return false;
                                                }
                                                else
                                                {
                                                    if (!IsValidIRoverInitialPosition(num1, num2))
                                                        return false;
                                                    HoldRoverInitialposition(num1, num2, dir);
                                                    return true;
                                                }
                                            default:
                                              return false;    
                                        }
                                    }
                                }
                    }
                    private static void LandRoverOnPlateau(IRover Rover)
                    {
                        
                        Rover.Direction = RoverInitialDirection;
                        Rover.XPosition = RoverInitialXPosition;
                        Rover.YPosition = RoverInitialYPosition;
                    } // Change the X, Y and direction of a rover
                    private static void HoldRoverInitialposition(int xinitialposition, int yinitialposition, char roverinitialdirection)
                    {
                        RoverInitialDirection = roverinitialdirection;
                        RoverInitialXPosition = xinitialposition;
                        RoverInitialYPosition = yinitialposition;
                    } //Temp vars to hold th evalues of the rover direction and position
                    private static bool IsValidIRoverInitialPosition(int num1,int num2) // to check if the initial position of the rover is not out of bound
                        {
                            if (num1 > rover.First().XPositionofPlateau || num2 > rover.First().YPositionofPlateau)
                                return false;
                            else
                                return true;

                        }
                    private static bool IsValidListofInstructions() // to check if the user entered a valid input for the initial position of the rover
                    {

                        string input = Console.ReadLine();
                        bool validInput = input.All(c => "lLrRmM".Contains(c)); //use Linq Enumerable.Contains

                        if (!validInput)
                            return false;
                        else
                        {
                            RoverInitialInstructions = input;
                            return true;
                        }
                      
                        
                    }





      




           
            



        }




       

            
        
        
        
    }

