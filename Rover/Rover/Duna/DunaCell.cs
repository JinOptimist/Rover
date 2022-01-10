using System.Collections.Generic;

namespace Rover
{
    public class DunaCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Altitude { get; set; }
        public int ChargeToMoveHere { get; set; } = -1;
        public List<DunaCell> PathToHere { get; set; } = new List<DunaCell>();

        public override string ToString()
        {
            return $"[{Y},{X}:{Altitude}]";
        }
    }
}