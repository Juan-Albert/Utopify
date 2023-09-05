﻿using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Runtime.Domain;

namespace Tests.EditMode
{
    public class CardTests
    {
        [Test]
        public void WhenCompareTraits_ReturnCorrectHappiness()
        {
            var goodTrait = new Trait("Good", new []{"Good", "Sad"}, new []{"Evil"});
            var sadTrait = new Trait("Sad");
            var evilTrait = new Trait("Evil");
            var sut1 = new Card(new List<Trait>{goodTrait});
            var sut2 = new Card(new List<Trait>
            {
                goodTrait,
                sadTrait,
                evilTrait
            });

            var result = sut1.CompareTraits(sut2);

            result.Should().Be(1);
        }
    }
}