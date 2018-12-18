
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace UI.Tile
{
    public class TileProvider : ITileProvider
    {
        private const int TileWidth = 16;

        private readonly Dictionary<TileType, CroppedBitmap> _tileDict = new Dictionary<TileType, CroppedBitmap>
        {
            { TileType.Void, null},
            { TileType.Grass, GetTile(3,7)},
            { TileType.Flowers, GetTile(3,5)},
            { TileType.Water, GetTile(2,1)},
            { TileType.Soil, GetTile(3,13)},
        };

        private static readonly BitmapSource BitmapSource =
            CreateBitmapSource(new Uri(@"pack://application:,,,/Assets/tileset.png"));

        private static CroppedBitmap GetTile(int x, int y) => new CroppedBitmap(BitmapSource, new Int32Rect(x * TileWidth, y * TileWidth, TileWidth, TileWidth));

        private static BitmapSource CreateBitmapSource(Uri path)
        {
            var image = new BitmapImage();
            using (var stream = Application.GetResourceStream(path)?.Stream)
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.UriSource = path;
                image.EndInit();
                image.Freeze();
            }

            return image;
        }

        private TileProvider()
        {
        }

        private static TileProvider _instance;
        public static TileProvider Instance => _instance ?? (_instance = new TileProvider());

        public CroppedBitmap Get(TileType type)
        {
            if (_tileDict.TryGetValue(type, out var tile))
            {
                return tile;
            }

            throw new InvalidEnumArgumentException(@"This tile type has not been assigned yet.");
        }
    }
}
