using NUnit.Framework;
using Runtime.Domain;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests.EditMode
{
    public class ConnectionTests
    {
        [Test]
        public void InvertedConnections_AreEqual()
        {
            var fromSquare = new Square(new Coordinate(0, 0));
            var toSquare = new Square(new Coordinate(1, 0));
            var sut1 = new Connection(fromSquare, toSquare);
            var sut2 = new Connection(toSquare, fromSquare);
            
            Assert.AreEqual(sut1, sut2);
        }
    }
}