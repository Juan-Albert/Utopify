﻿using System.Collections.Generic;
using NUnit.Framework;
using Runtime.Domain;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests.EditMode
{
    public class DeckTests
    {
        [Test]
        public void WhenCardAddedToDeck_ItIsIn()
        {
            Card card = new Card(new List<Trait>
            {
                new (Trait.Name.Good, 
                    new TraitComparer(
                        new Dictionary<(Trait.Name, Trait.Name), TraitComparer.Result>()))
            });
            var sut = new Deck(new List<Card>());
            
            sut.AddCard(card);
            
            Assert.IsTrue(sut.Cards.Contains(card));
        }

        [Test]
        public void WhenDrawCardFromDeck_ItIsNotIn()
        {
            Card card = new Card(new List<Trait>
            {
                new (Trait.Name.Good, 
                    new TraitComparer(
                        new Dictionary<(Trait.Name, Trait.Name), TraitComparer.Result>()))
            });
            var sut = new Deck(new List<Card>
            {
                card
            });
            
            sut.DrawCard();
            
            Assert.IsFalse(sut.Cards.Contains(card));
        }
    }
}