using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class Card
    {
        public List<Trait> Traits { get; }

        public Card(List<Trait> traits)
        {
            Assert.IsTrue(traits.Count > 0);
            Traits = traits;
        }

        public int CompareTraits(Card otherCard)
        {
            var happiness = 0;
            foreach (var myTrait in Traits)
            {
                foreach (var otherTrait in otherCard.Traits)
                {
                    var comparison = myTrait.Compare(otherTrait);

                    switch (comparison)
                    {
                        case TraitComparer.TraitComparerResult.Positive:
                            happiness += 2;
                            break;
                        case TraitComparer.TraitComparerResult.Negative:
                            happiness -= 2;
                            break;
                    }
                }
            }

            return happiness;
        }
    }
}