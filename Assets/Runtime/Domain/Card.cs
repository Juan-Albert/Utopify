using System;
using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public class Board
    {
        readonly Dictionary<(int, int), Card> tiles = new();

        Board(Dictionary<(int,int), Card> tiles)
        {
            this.tiles = tiles;
        }
        
        public static Board Empty => new(new());

        public Board PutAt((int, int) where, Card card)
        {
            var result = tiles.Concat(new[] { new KeyValuePair<(int, int), Card>(where, card) });
            return new Board(result.ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
        }

        public bool ExistsAt((int, int) coordinate)
        {
            return tiles.ContainsKey(coordinate);
        }
    }

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