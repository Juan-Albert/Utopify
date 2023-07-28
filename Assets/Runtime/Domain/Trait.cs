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
    
        public Trait(TraitType traitType)
        {
            _traitType = traitType;
        }
    
    }
}
