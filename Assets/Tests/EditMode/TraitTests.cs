using FluentAssertions;
using NUnit.Framework;
using Runtime.Domain;
using static Runtime.Domain.NewTrait;
using static Runtime.Domain.Trait.Name;
using static Runtime.Domain.TraitComparer.Connection;

namespace Tests.EditMode
{
    public class TraitTests
    {
        [Test]
        public void GoodTrait_HasNegativeRelation_WithEvilTrait()
        {
            var firstTrait = new Trait(Good, new TraitComparer(
                new()
                {
                    { (Good, Evil), Negative }
                }));

            var secondTrait = new Trait(Evil, new TraitComparer(
                new()
                {
                    { (Good, Evil), Negative }
                }));

            firstTrait.Compare(secondTrait).Should().Be(Negative);
        }

        [Test]
        public void NeutralRelation()
        {
            var firstTrait = new Trait(Good, new TraitComparer(
                new()
                {
                    { (Good, Evil), TraitComparer.Connection.Neutral }
                }));

            var secondTrait = new Trait(Evil, new TraitComparer(
                new()
                {
                    { (Good, Evil), TraitComparer.Connection.Neutral }
                }));

            firstTrait.Compare(secondTrait).Should().Be(TraitComparer.Connection.Neutral);
        }

        [Test]
        public void PositiveRelation()
        {
            var firstTrait = new Trait(Good, new TraitComparer(
                new()
                {
                    { (Good, Evil), Positive }
                }));

            var secondTrait = new Trait(Evil, new TraitComparer(
                new()
                {
                    { (Good, Evil), Positive }
                }));

            firstTrait.Compare(secondTrait).Should().Be(Positive);
        }
    }

    public class NewTraitTests
    {
        [Test]
        public void Relationship()
        {
            var goodTrait = new NewTrait("Good", new []{"Good"}, new []{"Evil"});
            
            goodTrait.CompareTo(goodTrait).Should().Be(Relation.Friend);
            goodTrait.CompareTo(new("Evil")).Should().Be(Relation.Enemy);
            goodTrait.CompareTo(new("Neutral")).Should().Be(Relation.Neutral);
        }
        
        [Test]
        public void Relationship_IsNotNeccesarily_Commutative()
        {
            var specialTrait = new NewTrait("1", new []{"2"}, new string[]{});
            var notCommutativeTrait = new NewTrait("2");

            specialTrait.CompareTo(notCommutativeTrait).Should().NotBe(notCommutativeTrait.CompareTo(specialTrait));
        }
    }
}