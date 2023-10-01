using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public static class Neighbouring
    {
        public static bool IsNeighbourOf(this (int, int) coordinate, (int, int) other)
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
    }
}