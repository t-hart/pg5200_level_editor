/// <summary>
///
/// </summary>

public enum MovementCost {
    One = 1,
    Two,
    Three,
    RequiresFlight
}

public enum TileEntryStatus {
    Closed = 0,
    Open
}

public interface IPoint {
    int X;
    int Y;
}

public abstract class Tile {
    public IPoint Position {get; set;}
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

/// x0x
/// 0M0
/// x0x
public interface ITile {
    TileEntryStatus North;
    TileEntryStatus South;
    TileEntryStatus East;
    TileEntryStatus West;
}

public enum TileState {
    Occupied,
    Free
}

public enum UnitType {
    Mercenary,
    Knight,
    Paladin,
    PegasusKnight
}

public interface IUnit {
    int Movement;
    bool IgnoresTerrain;
}

public interface IScene {
    Dictionary<IPoint, IUnit> PlayerTeamPositions;
    Dictionary<IPoint, IUnit> EnemyTeamPositions;
    IIterable<IIterable<IPoint>> Tiles;
}

public class Tile {
    public MovementCost {get; readonly set;}

    private Tile(MovementCost mvmt) {MovementCost = mvmt;}

    public static Tile Ground => Tile(MovementCost);
    public static Tile Forest => Tile(Two);
    public static Tile Wall => Tile(Impassable);
    public static Tile Mountain => Tile(Three);
    public static Tile Water => Tile(Impassable);
    public static Tile Chasm => Tile(Impassable);
}

public interface ITile {
    MovementCost MovementCost;
    Terrain Terrain;
    ITile Ground();
    ITile Forest();
    ITile Water();
    ITile Wall();
    ITile Mountain();
    ITile Chasm();
}