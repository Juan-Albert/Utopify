using FluentAssertions;
using NUnit.Framework;
using Runtime.Domain;
using static Runtime.Domain.Trait;

namespace Tests.EditMode
{
    public class NewTraitTests
    {
        [Test]
        public void Relationship()
        {
            var goodTrait = new Trait("Good", new []{"Good"}, new []{"Evil"});
            
            goodTrait.CompareTo(goodTrait).Should().Be(Relation.Friend);
            goodTrait.CompareTo(new("Evil")).Should().Be(Relation.Enemy);
            goodTrait.CompareTo(new("Neutral")).Should().Be(Relation.Neutral);
        }
        
        [Test]
        public void Relationship_IsNotNecessarily_Commutative()
        {
            var specialTrait = new Trait("1", new []{"2"}, new string[]{});
            var notCommutativeTrait = new Trait("2");

            specialTrait.CompareTo(notCommutativeTrait).Should().NotBe(notCommutativeTrait.CompareTo(specialTrait));
        }
    }
}