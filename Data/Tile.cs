using JetBrains.Annotations;
using Optional;

namespace Data
{
    // attempt at making algebraic data types in C#.
    // based on this post: https://softwareengineering.stackexchange.com/questions/159804/how-do-you-encode-algebraic-data-types-in-a-c-or-java-like-language
    // to be coupled with pattern matching
    public abstract class Tile : ITile
    {
        public IPoint Position { get; set; }
        public int Height { get; set; }

        private Tile() { }


        public abstract class Impassable : Tile, IImpassable
        {
            private Impassable() { }
        }

        public abstract class Walkable : Tile, IWalkable
        {
            public TileEntryStatus North { get; set; }
            public TileEntryStatus South { get; set; }
            public TileEntryStatus East { get; set; }
            public TileEntryStatus West { get; set; }
            public IOptional<IUnit> Unit { get; set; }

            public MovementCost MovementCost { get; }

            protected Walkable(MovementCost movementCost)
            {
                MovementCost = movementCost;
            }
        }

        public sealed class Ground : Walkable
        {
            public Ground() : base(MovementCost.One) { }
        }

        public sealed class Peak : Walkable
        {
            public Peak() : base(MovementCost.Three) { }
        }

        public sealed class Water : Walkable
        {
            public Water() : base(MovementCost.RequiresFlight) { }
        }
    }
}
