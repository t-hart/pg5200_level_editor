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

        public List<Point> Tiles { get; }

        public MainViewModel()
        {
            Tiles = Enumerable.Range(0, 12).SelectMany(x => Enumerable.Range(0, 12).Select(y => new Point { X = (uint)x * TileWidth, Y = (uint)y * TileHeight, TileWidth = TileWidth, TileHeight = TileHeight })).ToList();
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