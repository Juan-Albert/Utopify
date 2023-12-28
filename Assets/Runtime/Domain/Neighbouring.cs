using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public static class Neighbouring
    {
        public static bool AreNeighbours(this (int, int) coordinate, (int, int) other)
        {
            return coordinate.Neighbours().Contains(other);
        }
        
        public static IEnumerable<(int, int)> Neighbours(this (int, int)  coordinate)
        {
            var (x, y) = coordinate;
            yield return (x - 1, y);
            yield return (x + 1, y);
            yield return (x, y - 1);
            yield return (x, y + 1);
        }    
        
        public static IEnumerable<(int, int)> WithoutNeighbours(this IEnumerable<(int, int)> coordinates)
        {
            var result = coordinates.ToList();
            
            foreach (var coordinate in coordinates)
            {
                if (!result.Contains(coordinate)) continue;
                
                result = result.Except(coordinate.Neighbours()).ToList();
            }

            return result;
        }
        
        public static IEnumerable<((int x, int y),(int x, int y))> Connections(this IEnumerable<(int, int)> tiles)
        {
            var result = new List<((int x, int y),(int x, int y))>();

            foreach (var tile in tiles)
            {
                foreach (var neighbour in tile.Neighbours())
                {
                    if(!tiles.Contains(neighbour)) continue;
                    if (result.Contains((neighbour, tile))) continue;

                    result.Add((tile, neighbour));
                }
            }
            
            return result;
        }
    }
}