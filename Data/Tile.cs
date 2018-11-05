using JetBrains.Annotations;

namespace Data
{
    public abstract class Tile : ITile
    {
        public IPoint Position {get; set;}
        public int Height {get; set;}
        public TileEntryStatus Norh {get; set;}
        public TileEntryStatus South {get; set;}
        public TileEntryStatus East {get; set;}
        public TileEntryStatus West {get; set;}

        private Tile(){}


        public abstract class Impassable : Tile {
            private Impassable(){}
        }

        public abstract class Walkable : Tile {
            private Walkable(){}
            [CanBeNull] public IUnit Unit { get; set; }
            public MovementCost MovementCost { get; }
        }

        public sealed class Ground : Walkable {
            public new MovementCost MovementCost = MovementCost.One;
        }

        public sealed class Peak : Walkable {
            public new MovementCost MovementCost = MovementCost.Three;
        }

        public sealed class Water : Walkable {
            public new MovementCost MovementCost = MovementCost.RequiresFlight;
        }
    }
}
