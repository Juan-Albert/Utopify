using System.Collections.Generic;

namespace Runtime.Domain
{
    public static class Neighbouring
    {
        public static IEnumerable<Coordinate> Neighbours(this Coordinate coordinate)
        {
            yield return new Coordinate(coordinate.Row + 1, coordinate.Column);
            yield return new Coordinate(coordinate.Row - 1, coordinate.Column);
            yield return new Coordinate(coordinate.Row, coordinate.Column + 1);
            yield return new Coordinate(coordinate.Row, coordinate.Column - 1);
        }
    }
}