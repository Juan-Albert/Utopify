using System.Collections.Generic;
using Runtime.Scriptable;

namespace Runtime.Domain
{
    public class Card
    {
        private readonly List<Trait> _traits;

        public Card(CardConfig cardConfig, TraitComparer traitComparer)
        {
            _traits = new List<Trait>();
            foreach (var traitType in cardConfig.traitTypes)
            {
                _traits.Add(new Trait(traitType, traitComparer));
            }
        }
    }
}