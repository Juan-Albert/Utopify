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
    }
}