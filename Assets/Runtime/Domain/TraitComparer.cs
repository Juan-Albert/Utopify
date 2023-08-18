using System.Collections.Generic;

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

        private Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparerResult> _comparisons;
            
        public TraitComparer()
        {
            _comparisons = new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparerResult>
            {
                { (Trait.TraitType.Good, Trait.TraitType.Good), TraitComparerResult.Positive },
                { (Trait.TraitType.Good, Trait.TraitType.Evil), TraitComparerResult.Negative },
                { (Trait.TraitType.Good, Trait.TraitType.Happy), TraitComparerResult.Neutral },
                { (Trait.TraitType.Good, Trait.TraitType.Sad), TraitComparerResult.Neutral },
                { (Trait.TraitType.Evil, Trait.TraitType.Evil), TraitComparerResult.Positive },
                { (Trait.TraitType.Evil, Trait.TraitType.Happy), TraitComparerResult.Negative },
                { (Trait.TraitType.Evil, Trait.TraitType.Sad), TraitComparerResult.Negative },
                { (Trait.TraitType.Happy, Trait.TraitType.Happy), TraitComparerResult.Positive },
                { (Trait.TraitType.Happy, Trait.TraitType.Sad), TraitComparerResult.Negative },
                { (Trait.TraitType.Sad, Trait.TraitType.Sad), TraitComparerResult.Positive }
            };
        }

        public TraitComparerResult Compare(Trait.TraitType firstTrait, Trait.TraitType secondTrait)
        {
            return _comparisons.ContainsKey((firstTrait, secondTrait))
                ? _comparisons[(firstTrait, secondTrait)]
                : _comparisons[(secondTrait, firstTrait)];
        }
    }
}