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
                new()
                {
                    { (Trait.Name.Good, Trait.Name.Good), TraitComparer.Result.Positive },
                    { (Trait.Name.Good, Trait.Name.Sad), TraitComparer.Result.Positive },
                    { (Trait.Name.Good, Trait.Name.Evil), TraitComparer.Result.Negative }
                });
            var goodTrait = new Trait(Trait.Name.Good, traitComparer);
            var sadTrait = new Trait(Trait.Name.Sad, traitComparer);
            var evilTrait = new Trait(Trait.Name.Evil, traitComparer);
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