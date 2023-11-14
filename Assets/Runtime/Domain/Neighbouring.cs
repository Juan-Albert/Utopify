using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public static class Neighbouring
    {
        public static bool AreNeighbours(this (int, int) coordinate, (int, int) other)
        {
            return coordinate.NeighboursOf().Contains(other);
        }
        
        public static IEnumerable<(int, int)> NeighboursOf(this (int, int)  coordinate)
        {
            var (x, y) = coordinate;
            yield return (x - 1, y);
            yield return (x + 1, y);
            yield return (x, y - 1);
            yield return (x, y + 1);
        }    
        
        public static IEnumerable<(int, int)> ExcludeNeighbours(this IEnumerable<(int, int)> coordinates)
        {
            var result = coordinates.ToList();
            
            foreach (var coordinate in coordinates)
            {
                if (!result.Contains(coordinate)) continue;
                
                result = result.Except(coordinate.NeighboursOf()).ToList();
            }

            return result;
        }
    }
}