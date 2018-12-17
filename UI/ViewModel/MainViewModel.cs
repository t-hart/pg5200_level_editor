using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.CommandWpf;
using RelayCommand = GalaSoft.MvvmLight.Command.RelayCommand;

namespace UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public static uint NumTilesX => 20;
        public static uint NumTilesY => NumTilesX;
        public uint MapWidth => NumTilesX * TileWidth;
        public uint MapHeight => NumTilesY * TileHeight;
        public static uint TileWidth => 60;
        public static uint TileHeight => TileWidth;

        public IEnumerable<Point> Points => Tiles.Values;

        private Dictionary<(uint x, uint y), Point> Tiles { get; } = Enumerable.Range(0, (int)NumTilesX).SelectMany(x => Enumerable.Range(0, (int)NumTilesY).Select(y => ((uint)x, (uint)y))).ToDictionary(
            p => p,
            p => new Point(p.Item1 * TileWidth, p.Item2 * TileHeight, TileWidth, TileHeight, Brushes.AliceBlue)
            );


        public MainViewModel()
        {
        }

        public class Point : ViewModelBase
        {
            public uint X { get; set; }
            public uint Y { get; set; }
            public uint TileWidth { get; set; }
            public uint TileHeight { get; set; }
            public SolidColorBrush Background { get; set; }
            public RelayCommand MouseEnterCommand { get; }
            public RelayCommand MouseDownCommand { get; }

            public Point(uint x, uint y, uint tileWidth, uint tileHeight, SolidColorBrush background)
            {
                X = x;
                Y = y;
                TileWidth = tileWidth;
                TileHeight = tileHeight;
                Background = background;
                MouseDownCommand = new RelayCommand(ChangeBackground);
                MouseEnterCommand = new RelayCommand(() =>
                {
                    if (Mouse.LeftButton == MouseButtonState.Pressed)
                    {
                        ChangeBackground();
                    }
                });

                void ChangeBackground()
                {
                    Background = Brushes.Black;
                    RaisePropertyChanged("");
                }
            }

        }
    }
}