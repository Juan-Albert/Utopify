using System.Collections.Generic;
using NUnit.Framework;
using Runtime.Domain;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests.EditMode
{
    public class HandTests
    {
        [Test]
        public void WhenHandPlayCardAndIsEmpty_DrawCard()
        {
            Card card = new Card(new List<Trait>
            {
                new (Trait.TraitType.Good, 
                    new TraitComparer(
                        new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>()))
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
                new (Trait.TraitType.Good, 
                    new TraitComparer(
                        new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>()))
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