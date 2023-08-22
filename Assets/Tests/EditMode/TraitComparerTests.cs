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
            Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult> traitComparisons =
                new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>()
                {
                    { (Trait.TraitType.Good, Trait.TraitType.Good), TraitComparer.TraitComparerResult.Positive }
                };
            var sut = new TraitComparer(traitComparisons);

            var result = sut.Compare(Trait.TraitType.Good, Trait.TraitType.Good);
        
            Assert.AreEqual(result, TraitComparer.TraitComparerResult.Positive);
        }

        [Test]
        public void WhenTraitOrderIsInverted_ReturnSameResult()
        {
            Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult> traitComparisons =
                new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>()
                {
                    { (Trait.TraitType.Good, Trait.TraitType.Evil), TraitComparer.TraitComparerResult.Negative }
                };
            var sut = new TraitComparer(traitComparisons);

            var result = sut.Compare(Trait.TraitType.Good, Trait.TraitType.Evil);
            var invertedResult = sut.Compare(Trait.TraitType.Evil, Trait.TraitType.Good);
        
            Assert.AreEqual(result, invertedResult);
        }
    }
}
