using System;

namespace Runtime.Domain
{
    public class Square
    {
        public Coordinate Coordinate { get; }
        
        public Square(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
    }
}