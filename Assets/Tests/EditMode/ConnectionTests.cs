using FluentAssertions;
using NUnit.Framework;
using Runtime.Domain;

namespace Tests.EditMode
{
    public class ConnectionTests
    {
        [Test]
        public void InvertedConnections_AreEqual()
        {
            var from = new Coordinate(0, 0);
            var to = new Coordinate(1, 0);
            var sut1 = new Connection(from, to);
            var sut2 = new Connection(to, from);
            
            sut1.Should().Be(sut2);
        }
    }
}