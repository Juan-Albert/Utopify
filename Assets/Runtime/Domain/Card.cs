using System;
using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public record Card
    {
        public enum Relationship
        {
            Neutral = 0,
            Positive = 1,
            Negative = -1
        }

        readonly Trait[] traits;
        
        public IEnumerable<Trait> Traits => traits;

        Card(IEnumerable<Trait> traits)
        {
            if (traits.Count() != traits.Distinct().Count())
                throw new NotSupportedException();
            if (traits is null || !traits.Any())
                throw new NotSupportedException();

            this.traits = traits.ToArray();
        }

        public static Card WithTraits(params Trait[] traits) => new(traits);

        public int PreviewHappinessWith(Card other)
        {
            return traits.Sum(t => other.traits.Sum(o => t.AffinityWith(o).ToPreviewHappiness()));
        }

        public Relationship PreviewRelationshipWith(Card other)
            => PreviewHappinessWith(other) switch
            {
                > 0 => Relationship.Positive,
                < 0 => Relationship.Negative,
                _ => Relationship.Neutral
            };
    }
}