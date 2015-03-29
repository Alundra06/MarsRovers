using System;
using System.Collections.Generic;
namespace MarsRovers
{
    public interface IRover
    {
        void ChangeDirection(char Direction);
        void ChangePosition(int XPosition, int YPosition);
        char Direction { get; set; }
        int XPosition { get; set; }
        int YPosition { get; set; }
        int XPositionofPlateau { get; set; }
        int YPositionofPlateau { get; set; }
        List<char> ListOfNasaInstructions { get; set; }
        void ProcessNASAInstructions();
        bool IsOutofBound { get; set; }
    }
}
