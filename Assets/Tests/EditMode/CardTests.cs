using System.Collections.Generic;
using NUnit.Framework;
using Runtime.Domain;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests.EditMode
{
    public class CardTests
    {
        [Test]
        public void WhenCompareTraits_ReturnCorrectHappiness()
        {
            var traitComparer = new TraitComparer(
                new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>
                {
                    { (Trait.TraitType.Good, Trait.TraitType.Good), TraitComparer.TraitComparerResult.Positive },
                    { (Trait.TraitType.Good, Trait.TraitType.Sad), TraitComparer.TraitComparerResult.Positive },
                    { (Trait.TraitType.Good, Trait.TraitType.Evil), TraitComparer.TraitComparerResult.Negative }
                });
            var goodTrait = new Trait(Trait.TraitType.Good, traitComparer);
            var sadTrait = new Trait(Trait.TraitType.Sad, traitComparer);
            var evilTrait = new Trait(Trait.TraitType.Evil, traitComparer);
            var sut1 = new Card(new List<Trait>
            {
                goodTrait
            });
            var sut2 = new Card(new List<Trait>
            {
                goodTrait,
                sadTrait,
                evilTrait
            });

            var result = sut1.CompareTraits(sut2);
            
            Assert.AreEqual(2, result);
        }
    }
}