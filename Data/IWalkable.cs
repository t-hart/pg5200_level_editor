namespace Data
{
    public interface IWalkable : ITile
    {
        TileEntryStatus North { get; set; }
        TileEntryStatus South { get; set; }
        TileEntryStatus East { get; set; }
        TileEntryStatus West { get; set; }
        MovementCost MovementCost { get; }
    }
}