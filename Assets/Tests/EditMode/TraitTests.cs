using FluentAssertions;
using NUnit.Framework;
using Runtime.Domain;
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
                    { (Good, Evil), Neutral }
                }));

            var secondTrait = new Trait(Evil, new TraitComparer(
                new()
                {
                    { (Good, Evil), Neutral }
                }));

            firstTrait.Compare(secondTrait).Should().Be(Neutral);
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
}