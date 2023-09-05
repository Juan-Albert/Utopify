using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Runtime.Domain;

namespace Tests.EditMode
{
    public class MilestoneTests
    {
        [Test]
        public void WhenMilestoneCompleted_CardsAddedToDeck()
        {
            var deck = new Deck(new List<Card>());
            var sut = new Milestone(1, deck, new List<Card> 
            {
                new (new List<Trait>{new ("Good")}),
                new (new List<Trait>{new ("Evil")})
            });
            
            sut.Complete();

            deck.Cards.Count.Should().Be(2);
        }
    }
}