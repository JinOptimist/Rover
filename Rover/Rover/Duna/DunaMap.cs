using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rover
{
    public class DunaMap
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public List<DunaCell> Cells { get; set; } = new List<DunaCell>();

        public DunaCell this[int y, int x]
        {
            get
            {
                return Cells.SingleOrDefault(c => c.X == x && c.Y == y);
            }
        }
    }
}
