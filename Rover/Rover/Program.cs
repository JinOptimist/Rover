using System;

namespace Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            //var map = new int[3, 3] {
            //    {0,1,2},
            //    {1,2,1},
            //    {5,3,3}
            //};

            var map = new int[,] {
                {0,0,0,3},
                {3,3,0,3},
                {0,0,0,3},
                {0,3,3,3},
                {0,0,0,0}
            };

            Rover.Duna.Rover.CalculateRoverPath(map);
        }
    }
}
