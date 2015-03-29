using System;
namespace MarsRovers
{
    interface ILogic
    {
        char ChangeDirection(char InitialDirection, char orientation);
        System.Collections.Generic.List<int> ChangePosition(int InitialX, int InitialY, char orientation);
        bool IsRoverInstructionOutofBound(int InitialX, int InitialY, char orientation, int TableauX, int TableauY);
    }
}
