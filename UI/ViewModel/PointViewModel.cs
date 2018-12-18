using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace UI.ViewModel
{
    public class PointViewModel : ViewModelBase
    {
        public uint X { get; }
        public uint Y { get; }
        public uint TileWidth { get; set; }
        public uint TileHeight { get; set; }
        public SolidColorBrush Background { get; set; }
        public RelayCommand MouseEnterCommand { get; }
        public RelayCommand MouseDownCommand { get; }

        private CroppedBitmap _currentTile;
        public CroppedBitmap Tile { get; set; }

        public PointViewModel(uint x, uint y, uint tileWidth, uint tileHeight, SolidColorBrush background, CroppedBitmap currentTile)
        {
            MessengerInstance.Register<UpdateTileMessage>(this, msg => _currentTile = msg.NewTile);

            X = x;
            Y = y;
            _currentTile = currentTile;
            Tile = null;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Background = background;
            MouseDownCommand = new RelayCommand(DrawTile);
            MouseEnterCommand = new RelayCommand(() =>
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    DrawTile();
                }
            });

            void DrawTile()
            {
                Tile = _currentTile;
                RaisePropertyChanged("");
            }
        }

    }
}