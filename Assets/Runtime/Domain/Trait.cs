using System.Linq;

namespace Runtime.Domain
{
    public class Trait 
    {
        public enum TraitType
        {
            Good,
            Evil,
            Happy,
            Sad
        }

        private TraitType _traitType;
        private TraitComparer _traitComparer;
    
        public Trait(TraitType traitType, TraitComparer traitComparer)
        {
            _traitType = traitType;
            _traitComparer = traitComparer;
        }

        public TraitComparer.TraitComparerResult Compare(TraitType otherTraitType)
        {
            return _traitComparer.Compare(_traitType, otherTraitType);
        }
    
    }
}
