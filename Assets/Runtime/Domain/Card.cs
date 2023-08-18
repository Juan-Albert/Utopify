using System.Collections.Generic;

namespace Runtime.Domain
{
    public class Card
    {
        private readonly List<Trait> _traits;

        public Card(List<Trait> traits)
        {
            _traits = traits;
        }
    }
}