namespace UI.Tile
{
    public interface ITileProvider
    {
        ITile Get(TileType type);
    }
}
