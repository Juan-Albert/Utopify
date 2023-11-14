using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public class Board
    {
        readonly IReadOnlyDictionary<(int, int), Card> tiles;

        Board(IReadOnlyDictionary<(int, int), Card> tiles) => this.tiles = tiles;

        public static Board Empty => new(new Dictionary<(int, int), Card>());
        public int Happiness => tiles.Keys.ExcludeNeighbours().Sum(HappinessOf);

        public Board PlaceAt((int, int) where, Card card)
        {
            if (ExistsAt(where))
                throw new System.NotSupportedException();

            var result = tiles.Concat(new[] { new KeyValuePair<(int, int), Card>(where, card) });
            return new Board(result.ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
        }

        public bool ExistsAt((int, int) coordinate)
        {
            return tiles.ContainsKey(coordinate);
        }

        public int HappinessBetween((int, int) one, (int, int) other)
        {
            if (!ExistsAt(one) || !ExistsAt(other))
                throw new System.NotSupportedException("Ambos Tiles tienen que tener cartas");
            if (!one.AreNeighbours(other))
                throw new System.NotSupportedException("Ambas Tiles tienen que ser vecinas");

            return tiles[one].PreviewHappinessWith(tiles[other]);
        }

        public int HappinessOf((int, int) origin)
            => origin.NeighboursOf()
                .Where(ExistsAt)
                .Sum(tile => HappinessBetween(origin, tile));

        public IEnumerable<(int, int)> ExcludeNeighbours() => tiles.Keys.ExcludeNeighbours();
    }
}