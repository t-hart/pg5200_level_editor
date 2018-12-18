
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UI.Tile
{
    public class TileProvider : ITileProvider
    {
        private const int TileWidth = 16;
        private const uint Height = 14;
        private const uint Width = 9;

        private static readonly Image[] Tiles = new Image[Height * Width];

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
            
            //var path = new Uri(@"pack://application:,,,/Assets/tileset.png").ToString();
            const string path = "Assets/tileset.png";
            var image = Image.FromFile(path);

            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    var index = x * Width + y;
                    Tiles[index] = new Bitmap(TileWidth, TileWidth);
                    var graphics = Graphics.FromImage(Tiles[index]);
                    graphics.DrawImage(image, new Rectangle(0, 0, TileWidth, TileWidth), new Rectangle(x * TileWidth, y * TileWidth, TileWidth, TileWidth), GraphicsUnit.Pixel);
                    graphics.Dispose();
                }
            }

            var bmp = CreateBitmapSource(new Uri(@"pack://application:,,,/Assets/tileset.png"));
            var tile = GetTile(0, 0);
            Console.WriteLine("");

        }

        private static TileProvider _instance;
        public static TileProvider Instance => _instance ?? (_instance = new TileProvider());

        public ITile Get(TileType type)
        {
            throw new System.NotImplementedException();
        }
    }
}
