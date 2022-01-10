using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rover.Duna
{
    public class Rover
    {
        public static void CalculateRoverPath(int[,] map)
        {
            var dunaMap = BuildDunaMap(map);

            var current = dunaMap[0, 0];
            current.ChargeToMoveHere = 0;
            current.PathToHere.Add(current);

            var nearCells = GetNear(dunaMap, current);
            foreach (var nearCell in nearCells)
            {
                FillMapPath(dunaMap, current, nearCell);
            }

            var end = dunaMap[dunaMap.Height - 1, dunaMap.Width - 1];
            Console.WriteLine("path: " + string.Join('>', end.PathToHere.Select(c => $"[{c.Y},{c.X}]")));
            Console.WriteLine("cost: " + end.ChargeToMoveHere);
        }

        private static void FillMapPath(DunaMap dunaMap, DunaCell cellFrom, DunaCell cellTo)
        {
            var newPathCost = cellFrom.ChargeToMoveHere + 1 + Math.Abs(cellFrom.Altitude - cellTo.Altitude);
            if (cellTo.ChargeToMoveHere == -1 || cellTo.ChargeToMoveHere > newPathCost)
            {
                var path = cellFrom.PathToHere.ToList();
                path.Add(cellTo);
                cellTo.PathToHere = path;
                cellTo.ChargeToMoveHere = newPathCost;

                var nearCells = GetNear(dunaMap, cellTo);
                foreach (var nearCell in nearCells)
                {
                    FillMapPath(dunaMap, cellTo, nearCell);
                }
            }
        }

        private static List<DunaCell> GetNear(DunaMap dunaMap, DunaCell current)
        {
            return dunaMap.Cells
                .Where(c => c.X == current.X && Math.Abs(c.Y - current.Y) == 1
                    || Math.Abs(c.X - current.X) == 1 && c.Y == current.Y)
                .ToList();
        }

        private static DunaMap BuildDunaMap(int[,] map)
        {
            var dunaMap = new DunaMap()
            {
                Width = map.GetLength(1),
                Height = map.GetLength(0)
            };

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    var altitude = map[y, x];
                    var cell = new DunaCell()
                    {
                        X = x,
                        Y = y,
                        Altitude = altitude,
                    };

                    dunaMap.Cells.Add(cell);
                }
            }

            return dunaMap;
        }

        private static List<DunaCell> BuildFirstPath(DunaMap map)
        {
            var path = new List<DunaCell>();
            for (int x = 0; x < map.Width; x++)
            {
                path.Add(map[0, x]);
            }
            for (int y = 1; y < map.Height; y++)
            {
                path.Add(map[map.Width - 1, y]);
            }

            return path;
        }
    }

}
