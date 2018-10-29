public enum MovementCost {
    One = 1,
    Two,
    Three,
    RequiresFlight = -1
}

public enum TileState {
    Occupied,
    Free
}

public enum TileEntryStatus {
    Closed = 0,
    Open
}

public interface IPoint {
    int X;
    int Y;
}

public enum Faction {
    None = -1,
    Player,
    EnemyA,
    EnemyB,
}

public abstract class Unit {
    public uint Movement {get;}
    public Faction Faction {get; set;}
    public bool IgnoresTerrain {get;}
    private Unit(){}

    public sealed class Mercenary : Unit {
        public uint Movement => 6;
        public bool IgnoresTerrain => false;
    }

    public sealed class Knight : Unit {
        public uint Movement => 4;
        public bool IgnoresTerrain => false;
    }

    public sealed class Paladin : Unit {
        public uint Movement => 8;
        public bool IgnoresTerrain => false;
    }

    public sealed class PegasusKnight : Unit {
        public uint Movement => 8;
        public bool IgnoresTerrain => true;
    }
}

public abstract class Tile {
    public IPoint Position {get; set;}
    public int Height {get; set;}
    public TileEntryStatus North {get; set;}

    public TileEntryStatus South {get; set;}
    public TileEntryStatus East {get; set;}
    public TileEntryStatus West {get; set;}

    private Tile(){}

    public abstract class Impassable : Tile {
        private Impassable(){}
    }

    public sealed class Wall : Impassable {}

    public abstract class Walkable : Tile {
        private Walkable(){}
        [CanBeNull] public Unit Unit {get; set;}
        public MovementCost MovementCost {get;}
    }

    public sealed class Ground : Walkable {
        public MovementCost MovementCost = One;
    }

    public sealed class Peak : Walkable {
        public MovementCost MovementCost = Three;
    }

    public sealed class Water : Walkable {
        public MovementCost MovementCost = RequiresFlight;
    }
}

public interface ILevel {
    Dictionary<IPoint, Tile> Map;
}
