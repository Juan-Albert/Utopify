using NUnit.Framework;
using FluentAssertions;

namespace Tests.EditMode
{
    public class TraitTests
    {
        [Test]
        public void Relationships()
        {
            var friend = new Trait();
            var sut = new Trait(friend);
            
            sut.RelationWith(friend).Should().Be(Relationship.Friend);
        } 
    }

    public struct Trait
    {
        Trait[] friends;

        public Trait(Trait friend)
        {
            friends = new[] {friend};
        }

        public Relationship RelationWith(Trait friend)
        {
            return Relationship.Friend;
        }
    }

    public enum Relationship { Friend}
}