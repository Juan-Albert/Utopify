﻿using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public class Board
    {
        readonly IReadOnlyDictionary<(int, int), Card> tilesWithCard;

        Board(IReadOnlyDictionary<(int, int), Card> tilesWithCard) => this.tilesWithCard = tilesWithCard;

        public static Board Empty => new(new Dictionary<(int, int), Card>());
        public int Happiness => IsolatedCards.Sum(HappinessOf);
        IEnumerable<(int, int)> IsolatedCards => OccupiedTiles.ExcludeNeighbours();
        private IEnumerable<(int, int)> OccupiedTiles => tilesWithCard.Keys;
        public IEnumerable<(int, int)> AvailableTiles => BuildBoard().Except(OccupiedTiles).Concat(NeighboursOfTiles).Distinct();
        public IEnumerable<(int, int)> NeighboursOfTiles => tilesWithCard.SelectMany(x => x.Key.NeighboursOf());

        public static IEnumerable<(int, int)> BuildBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    yield return (i, j);
                }
            }
        }

        public Board PlaceAt((int, int) where, Card card)
        {
            if (ExistsAt(where))
                throw new System.NotSupportedException();

            var result = tilesWithCard.Concat(new[] { new KeyValuePair<(int, int), Card>(where, card) });
            return new Board(result.ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
        }

        public bool ExistsAt((int, int) coordinate)
        {
            return tilesWithCard.ContainsKey(coordinate);
        }

        public int HappinessBetween((int, int) one, (int, int) other)
        {
            if (!ExistsAt(one) || !ExistsAt(other))
                throw new System.NotSupportedException("Ambos Tiles tienen que tener cartas");
            if (!one.AreNeighbours(other))
                throw new System.NotSupportedException("Ambas Tiles tienen que ser vecinas");

            return tilesWithCard[one].PreviewHappinessWith(tilesWithCard[other]);
        }

        public int HappinessOf((int, int) origin)
            => origin.NeighboursOf()
                .Where(ExistsAt)
                .Sum(tile => HappinessBetween(origin, tile));
    }
}