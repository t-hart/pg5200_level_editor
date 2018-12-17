using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using GalaSoft.MvvmLight;

namespace UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public uint MapWidth => 12 * TileWidth;
        public uint MapHeight => MapWidth;
        public uint TileWidth => 40;
        public uint TileHeight => TileWidth;

        public IEnumerable<Point> Points => Tiles.Keys.Select(p => new Point
            {X = p.x * TileWidth, Y = p.y * TileHeight, TileWidth = TileWidth, TileHeight = TileHeight});

        public Dictionary<(uint x, uint y), string> Tiles { get; }

        public MainViewModel()
        {
            Tiles = Enumerable.Range(0, 12).SelectMany(x => Enumerable.Range(0, 12).Select(y => ((uint)x, (uint)y))).ToDictionary(x => x, x => x.ToString());
        }

        public struct Point
        {
            public uint X { get; set; }
            public uint Y { get; set; }
            public uint TileWidth { get; set; }
            public uint TileHeight { get; set; }
        }
    }
}