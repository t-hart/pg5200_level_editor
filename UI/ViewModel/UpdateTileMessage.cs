using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Messaging;

namespace UI.ViewModel
{
    public class UpdateTileMessage : MessageBase
    {
        public CroppedBitmap NewTile { get; set; }

        public UpdateTileMessage(CroppedBitmap newTile)
        {
            NewTile = newTile;
        }

    }
}