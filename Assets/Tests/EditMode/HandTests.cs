﻿using System.Collections.Generic;
using NUnit.Framework;
using Runtime.Domain;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests.EditMode
{
    public class HandTests
    {
        [Test]
        public void WhenHandStartEmpty_DrawFullHand()
        {
            Card card = new Card(new List<Trait>
            {
                new (Trait.Name.Good, 
                    new TraitComparer(
                        new Dictionary<(Trait.Name, Trait.Name), TraitComparer.Result>()))
            });
            var deck = new Deck(new List<Card>
            {
                card
            });
            var sut = new Hand(1, deck, new List<Card>());
            
            Assert.AreEqual(1, sut.Cards.Count);
        }
        
        [Test]
        public void WhenHandPlayCardAndIsEmpty_DrawFullHand()
        {
            Card card = new Card(new List<Trait>
            {
                new (Trait.Name.Good, 
                    new TraitComparer(
                        new Dictionary<(Trait.Name, Trait.Name), TraitComparer.Result>()))
            });
            var deck = new Deck(new List<Card>
            {
                card
            });
            var sut = new Hand(1, deck, new List<Card>
            {
                card
            });

            sut.PlayCard(card);
            
            Assert.AreEqual(1, sut.Cards.Count);
        }

        [Test]
        public void WhenDeckIsEmpty_DoNotDrawCard()
        {
            Card card = new Card(new List<Trait>
            {
                new (Trait.Name.Good, 
                    new TraitComparer(
                        new Dictionary<(Trait.Name, Trait.Name), TraitComparer.Result>()))
            });
            var deck = new Deck(new List<Card>());
            var sut = new Hand(1, deck, new List<Card>
            {
                card
            });

            sut.PlayCard(card);
            
            Assert.AreEqual(0, sut.Cards.Count);
        }
    }
}