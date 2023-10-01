using System;
using Runtime.Domain;

namespace Tests.EditMode
{
    public static class TestFixture
    {
        static public Trait EnemyOfSome => new Trait("enemy", Array.Empty<string>(), Array.Empty<string>());
        static public Trait Enemy2OfSome => new Trait("enemy2", Array.Empty<string>(), Array.Empty<string>());
        
        static public Trait FriendOfSome => new Trait("friend", Array.Empty<string>(), Array.Empty<string>());
        static public Trait Friend2OfSome => new Trait("friend2", Array.Empty<string>(), Array.Empty<string>());
        
        static public Trait NeutralOfSome => new Trait("neutral", Array.Empty<string>(), Array.Empty<string>());
        static public Trait Neutral2OfSome => new Trait("neutral2", Array.Empty<string>(), Array.Empty<string>());
        
        static public Trait Some => new Trait("some", new[] { "friend", "friend2" }, new[] { "enemy", "enemy2" });
    }
}