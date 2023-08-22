using System;
using System.Collections;
using System.Collections.Generic;

namespace Runtime.Domain
{
    public class Card
    {
        private List<Trait> Traits { get; }

        public Card(List<Trait> traits)
        {
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