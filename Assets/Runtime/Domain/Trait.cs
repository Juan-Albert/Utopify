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

        private TraitType Type { get; }

        private readonly TraitComparer _traitComparer;
    
        public Trait(TraitType traitType, TraitComparer traitComparer)
        {
            Type = traitType;
            _traitComparer = traitComparer;
        }

        public TraitComparer.TraitComparerResult Compare(Trait otherTrait)
        {
            return _traitComparer.Compare(Type, otherTrait.Type);
        }
    
    }
}
