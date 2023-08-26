using System;

namespace Runtime.Domain
{
    public readonly partial struct NewTrait
    {
        internal readonly struct Relation
        {
            readonly int value;

            Relation(int value)
            {
                if(value is < -1 or > 1)
                    throw new NotSupportedException("Esto no está en diseño");
                this.value = value;
            }

            public static Relation Friend => new(1);
            public static Relation Neutral => new();
            public static Relation Enemy => new(-1);

            public static implicit operator int(Relation relation) => relation.value;
            public static implicit operator Relation(int value) => new(value);
        }
    }
}