using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class TraitComparer
    {
        public enum Result
        {
            Positive,
            Negative,
            Neutral
        }

        private readonly Dictionary<(Trait.Name, Trait.Name), Result> _comparisons;
            
        public TraitComparer(Dictionary<(Trait.Name, Trait.Name), Result> comparisons)
        {
            _comparisons = comparisons;
        }

        public Result Compare(Trait.Name firstTrait, Trait.Name secondTrait)
        {
            Assert.IsTrue(_comparisons.ContainsKey((firstTrait, secondTrait)) ||
                          _comparisons.ContainsKey((secondTrait, firstTrait)));
            return _comparisons.ContainsKey((firstTrait, secondTrait))
                ? _comparisons[(firstTrait, secondTrait)]
                : _comparisons[(secondTrait, firstTrait)];
        }
    }
}