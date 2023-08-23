using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class TraitComparer
    {
        public enum TraitComparerResult
        {
            Positive,
            Negative,
            Neutral
        }

        private readonly Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparerResult> _comparisons;
            
        public TraitComparer(Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparerResult> comparisons)
        {
            _comparisons = comparisons;
        }

        public TraitComparerResult Compare(Trait.TraitType firstTrait, Trait.TraitType secondTrait)
        {
            Assert.IsTrue(_comparisons.ContainsKey((firstTrait, secondTrait)) ||
                          _comparisons.ContainsKey((secondTrait, firstTrait)));
            return _comparisons.ContainsKey((firstTrait, secondTrait))
                ? _comparisons[(firstTrait, secondTrait)]
                : _comparisons[(secondTrait, firstTrait)];
        }
    }
}