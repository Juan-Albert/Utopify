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
            return traits.Sum(t => WithJHGyhyh(t, other.traits));
        }

        static int WithJHGyhyh(Trait myTrait, IEnumerable<Trait> others)
        {
            return others.Select(other => KHGSAJHDFG(myTrait, other)).Sum();
        }

        static int KHGSAJHDFG(Trait myTrait, Trait otherTrait)
        {
            return myTrait.RelationWith(otherTrait) switch
            {
                Trait.Relationship.Friend => 1,
                Trait.Relationship.Enemy => -1,
                Trait.Relationship.Neutral => 0,
                _ => throw new NotSupportedException()
            };
        }
    }
}