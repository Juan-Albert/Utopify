using System;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using Runtime.Domain;
using static Runtime.Domain.NewTrait;
using static Runtime.Domain.NewTrait.Relation;
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
            var evilTrait = new NewTrait("Evil", new []{"Evil"}, new []{"Good"});
            var neutralTrait = new NewTrait("Neutral", new string[]{}, new string[]{}); 

            using var _ = new AssertionScope();
            goodTrait.CompareTo(goodTrait).Should().Be(Friend);
            goodTrait.CompareTo(evilTrait).Should().Be(Enemy);
            goodTrait.CompareTo(neutralTrait).Should().Be(Relation.Neutral);
        }
    }
}