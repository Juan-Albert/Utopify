using System.Collections.Generic;
using NUnit.Framework;
using Runtime.Domain;

namespace Tests.EditMode
{
    public class TraitComparerTests
    {
        [Test]
        public void WhenCompareTraits_ReturnCorrectResult()
        {
            Dictionary<(Trait.Name, Trait.Name), TraitComparer.Connection> traitComparisons =
                new Dictionary<(Trait.Name, Trait.Name), TraitComparer.Connection>()
                {
                    { (Trait.Name.Good, Trait.Name.Good), TraitComparer.Connection.Positive }
                };
            var sut = new TraitComparer(traitComparisons);

            var result = sut.Compare(Trait.Name.Good, Trait.Name.Good);
        
            Assert.AreEqual(result, TraitComparer.Connection.Positive);
        }

        [Test]
        public void WhenTraitOrderIsInverted_ReturnSameResult()
        {
            Dictionary<(Trait.Name, Trait.Name), TraitComparer.Connection> traitComparisons =
                new Dictionary<(Trait.Name, Trait.Name), TraitComparer.Connection>()
                {
                    { (Trait.Name.Good, Trait.Name.Evil), TraitComparer.Connection.Negative }
                };
            var sut = new TraitComparer(traitComparisons);

            var result = sut.Compare(Trait.Name.Good, Trait.Name.Evil);
            var invertedResult = sut.Compare(Trait.Name.Evil, Trait.Name.Good);
        
            Assert.AreEqual(result, invertedResult);
        }
    }
}
