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

            sut.AffinityWith(friend).Should().Be(Affinity.Friend);
        }

        [Test]
        public void EnemyRelationships()
        {
            var enemy = new Trait("enemy", Array.Empty<string>(), Array.Empty<string>());
            var sut = new Trait("some", Array.Empty<string>(), new[] { "enemy" });

            sut.AffinityWith(enemy).Should().Be(Affinity.Enemy);
        }

        [Test]
        public void NeutralRelationships()
        {
            var neutral = new Trait("whatever", Array.Empty<string>(), Array.Empty<string>());
            var sut = new Trait("some", Enumerable.Empty<string>(), Enumerable.Empty<string>());

            sut.AffinityWith(neutral).Should().Be(Affinity.Neutral);
        }
    }
}

/* POR DÓNDE VAMOS A SEGUIR EL SIGUIENTE DÍA.
 1. Noción en tablero de qué casillas están disponibles para poner cartas.
    1.1 Siempre las del mapa inicial que no estén ocupadas, DONE
    1.2 más los vecinos de las ocupadas. Sin repetir obviamente dos veces la misma casillas. 
 2. Noción de si una conexión entre dos casillas es positiva, negativa o neutral. 
 3. Vista pa poner cartas. Y que salgan las conexiones. 
    3.1 Clicable tile
        3.1.1 La vista hace cosas rara con el on mouse down --> Lo ignoramos.
    3.2 vista para la carta
        3.2.1 Vista base de una carta
        3.2.2 Visualizar los trait de una carta (podemos probar a hacerlo con colores para no tener que pintar sprites) <--
    3.3 vista para la conexion
        3.3.1 Vista base para una conexion
        3.3.2 Visualizar el estado de la conexion <--
 4. Felicidad global.
 5. Mano. Si no hacemos mano al principio, al clicar una casilla se pone una carta cualquiera o lo que sea (Mano Fake). <--
 
 //// Refactors
 1. Encapsular las tuplas de posiciones
 2. Hacer un builder para los test de board
 3. Extraer a otra suite los test de neighbouring
 4. Unificar la separación de los tiles del tablero en la vista 
 
 */
