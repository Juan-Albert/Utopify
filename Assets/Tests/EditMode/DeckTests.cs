using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Runtime.Domain;

namespace Tests.EditMode
{
    public class DeckTests
    {
        [Test]
        public void WhenCardAddedToDeck_ItIsIn()
        {
            var card = new Card(new List<Trait>{new ("Good")});
            var sut = new Deck(new List<Card>());
            
            sut.AddCard(card);
            
            sut.Cards.Contains(card).Should().BeTrue();
        }

        [Test]
        public void WhenDrawCardFromDeck_ItIsNotIn()
        {
            var card = new Card(new List<Trait>{new ("Good")});
            var sut = new Deck(new List<Card>{card});
            
            sut.DrawCard();
            
            sut.Cards.Contains(card).Should().BeFalse();
        }
    }
}