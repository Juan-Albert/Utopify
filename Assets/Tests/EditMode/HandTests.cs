using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Runtime.Domain;

namespace Tests.EditMode
{
    public class HandTests
    {
        [Test]
        public void WhenHandStartEmpty_DrawFullHand()
        {
            var card = new Card(new List<Trait>{new ("Good")});
            var deck = new Deck(new List<Card>{card});
            var sut = new Hand(1, deck, new List<Card>());
            
            sut.Cards.Count.Should().Be(1);
        }
        
        [Test]
        public void WhenHandPlayCardAndIsEmpty_DrawFullHand()
        {
            var card = new Card(new List<Trait>{new ("Good")});
            var deck = new Deck(new List<Card>{card});
            var sut = new Hand(1, deck, new List<Card>{card});

            sut.PlayCard(card);
            
            sut.Cards.Count.Should().Be(1);
        }

        [Test]
        public void WhenDeckIsEmpty_DoNotDrawCard()
        {
            var card = new Card(new List<Trait>{new ("Good")});
            var deck = new Deck(new List<Card>());
            var sut = new Hand(1, deck, new List<Card>{card});

            sut.PlayCard(card);
            
            sut.Cards.Count.Should().Be(0);
        }
    }
}