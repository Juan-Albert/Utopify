using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class TraitComparer
    {
        public enum Connection
        {
            Positive,
            Negative,
            Neutral
        }

        private readonly Dictionary<(Trait.Name, Trait.Name), Connection> _comparisons;
            
        public TraitComparer(Dictionary<(Trait.Name, Trait.Name), Connection> comparisons)
        {
            _comparisons = comparisons;
        }

        public Connection Compare(Trait.Name firstTrait, Trait.Name secondTrait)
        {
            Assert.IsTrue(_comparisons.ContainsKey((firstTrait, secondTrait)) ||
                          _comparisons.ContainsKey((secondTrait, firstTrait)));
            return _comparisons.ContainsKey((firstTrait, secondTrait))
                ? _comparisons[(firstTrait, secondTrait)]
                : _comparisons[(secondTrait, firstTrait)];
        }
    }
}