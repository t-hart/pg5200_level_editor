using JetBrains.Annotations;

namespace Data
{
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
            [CanBeNull] public IUnit Unit { get; set; }

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
