using System.Windows.Media.Imaging;

namespace UI.Tile
{
    public interface ITileProvider
    {
        CroppedBitmap Get(TileType type);
    }
}
