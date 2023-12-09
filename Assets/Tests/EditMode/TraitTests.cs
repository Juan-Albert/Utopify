using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using Runtime.Domain;
using static Runtime.Domain.Trait;

namespace Tests.EditMode
{
    public class TraitTests
    {
        [Test]
        public void FriendRelationships()
        {
            var friend = new Trait("friend", Array.Empty<string>(), Array.Empty<string>());
            var sut = new Trait("some", new[] { "friend" }, Array.Empty<string>());

            sut.RelationWith(friend).Should().Be(Relationship.Friend);
        }

        [Test]
        public void EnemyRelationships()
        {
            var enemy = new Trait("enemy", Array.Empty<string>(), Array.Empty<string>());
            var sut = new Trait("some", Array.Empty<string>(), new[] { "enemy" });

            sut.RelationWith(enemy).Should().Be(Relationship.Enemy);
        }

        [Test]
        public void NeutralRelationships()
        {
            var neutral = new Trait("whatever", Array.Empty<string>(), Array.Empty<string>());
            var sut = new Trait("some", Enumerable.Empty<string>(), Enumerable.Empty<string>());

            sut.RelationWith(neutral).Should().Be(Relationship.Neutral);
        }
    }
}

/* POR DÓNDE VAMOS A SEGUIR EL SIGUIENTE DÍA.
 1. Noción en tablero de qué casillas están disponibles para poner cartas.
    1.1 Siempre las del mapa inicial que no estén ocupadas, DONE
    1.2 más los vecinos de las ocupadas. Sin repetir obviamente dos veces la misma casillas. 
 2. Noción de si una conexión entre dos casillas es positiva, negativa o neutral. 
 3. Vista pa poner cartas. Y que salgan las conexiones. <-
 4. Felicidad global.
 5. Mano. Si no hacemos mano al principio, al clicar una casilla se pone una carta cualquiera o lo que sa.
 */
