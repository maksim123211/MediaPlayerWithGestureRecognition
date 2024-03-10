using MediaPlayerWithGestureRecognition.Areas.Player.ViewModels;

namespace MediaPlayerWithGestureRecognition
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void RewindBackwardsClicked(object sender, EventArgs e)
        {
            PlayerViewModel.RewindBackwards();
        }

        private void RewindForwardClicked(object sender, EventArgs e)
        {
            PlayerViewModel.RewindForward();
        }

        private void VolumeUpClicked(object sender, EventArgs e)
        {
            PlayerViewModel.IncreaseVolume();
        }

        private void VolumeDownClicked(object sender, EventArgs e)
        {
            PlayerViewModel.DecreaseVolume();
        }
    }
}
