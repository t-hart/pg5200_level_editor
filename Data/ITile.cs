namespace Data
{
    public interface ITile
        {
            IPoint Position {get; set;}
            int Height {get; set;}
            TileEntryStatus Norh {get; set;}
            TileEntryStatus South {get; set;}
            TileEntryStatus East {get; set;}
            TileEntryStatus West {get; set;}
        }
}
