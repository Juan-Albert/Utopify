using System;
using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public record Card
    {
        readonly Trait[] traits;

        public Card(IEnumerable<Trait> traits)
        {
            if(traits.Count() != traits.Distinct().Count())
                throw new NotSupportedException();
            if(traits is null || !traits.Any())
                throw new NotSupportedException();

            this.traits = traits.ToArray();
        }

        public int PreviewHappinessWith(Card other)
        {
            return traits.Sum(t => other.traits.Sum(o => t.RelationWith(o).ToPreviewHappiness()));
        }
    }
}