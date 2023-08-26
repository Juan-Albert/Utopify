namespace Runtime.Domain
{
    public class Trait 
    {
        public enum Name
        {
            Good,
            Evil,
            Happy,
            Sad
        }

        public Name Type { get; }

        private readonly TraitComparer _traitComparer;
    
        public Trait(Name name, TraitComparer traitComparer)
        {
            Type = name;
            _traitComparer = traitComparer;
        }

        public TraitComparer.Connection Compare(Trait otherTrait)
        {
            return _traitComparer.Compare(Type, otherTrait.Type);
        }
    
    }
}
