using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JetBrains.Annotations;
using UI.Tile;
using Brushes = System.Windows.Media.Brushes;

namespace UI.ViewModel
{
    [UsedImplicitly]
    public class MainViewModel : ViewModelBase
    {
        public const uint NumTilesX = 20;
        public const uint NumTilesY = NumTilesX;
        public const uint TileWidth = 60;
        public const uint TileHeight = TileWidth;

        public uint MapWidth => NumTilesX * TileWidth;
        public uint MapHeight => NumTilesY * TileHeight;

        public IEnumerable<ButtonViewModel> Buttons { get; }

        public IEnumerable<PointViewModel> Points => Tiles.Values;

        private Dictionary<(uint x, uint y), PointViewModel> Tiles { get; }


        public MainViewModel()
        {
            Tiles = Enumerable.Range(0, (int)NumTilesX).SelectMany(x => Enumerable.Range(0, (int)NumTilesY).Select(y => ((uint)x, (uint)y))).ToDictionary(
                        p => p,
                        p => new PointViewModel(p.Item1 * TileWidth, p.Item2 * TileHeight, TileWidth, TileHeight, null)
                        );


            Buttons = new []{
                ("Void", TileType.Void),
                ("Grass", TileType.Grass),
                ("Flowers", TileType.Flowers),
                ("Water", TileType.Water),
                ("Soil", TileType.Soil)
            }.Select(t => new ButtonViewModel(t.Item1, t.Item2));
        }

        public class ButtonViewModel : ViewModelBase
        {

            public string Text { get; set; }
            public RelayCommand<TileType> Command { get; set; }
            public TileType TileType { get; set; }

            public ButtonViewModel(string text, TileType type)
            {
                TileType = type;
                Text = text;
                Command = new RelayCommand<TileType>(t => MessengerInstance.Send(new UpdateTileMessage(TileProvider.Instance.Get(t))));
            }

        }

    }
}