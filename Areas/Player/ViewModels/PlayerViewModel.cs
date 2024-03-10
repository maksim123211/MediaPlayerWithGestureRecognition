using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediaPlayerWithGestureRecognition.Areas.Player.Models;

namespace MediaPlayerWithGestureRecognition.Areas.Player.ViewModels
{
    public sealed partial class PlayerViewModel : ObservableObject
    {
        private const float DefaultRewindTime = 5;
        private const float DefaultVolumeChangeStep = 0.1f;

        private readonly PlayList _playlist;

        private readonly Track _currentTrack;

        private readonly TrackPath _currentTrackPath;

        private bool _canRewindBackwards;
        private bool _canRewindForward;
        private bool _canSetPreviousTrack;
        private bool _canSetNextTrack;
        
        public PlayerViewModel(PlayList playlist, Track currentTrack)
        {
            _playlist = playlist;
            _currentTrack = currentTrack;
        }
        
        public string CurrentTrackTitle => _currentTrackPath.FileName;

        public TimeSpan CurrentTrackTime => _currentTrack.CurrentTime;

        //public float Volume
        //{
        //    get => _currentTrack.Volume;
        //    set => _currentTrack.Volume = value;
        //}

        [RelayCommand]
        public void RewindBackwards()
        {
            var timeToRewind = _currentTrack.CurrentTime.Subtract(TimeSpan.FromSeconds(DefaultRewindTime));
            _currentTrack.Rewind(timeToRewind);
        }

        [RelayCommand]
        public void RewindForward()
        {
            var timeToRewind = _currentTrack.CurrentTime.Add(TimeSpan.FromSeconds(DefaultRewindTime));
            _currentTrack.Rewind(timeToRewind);
        }

        [RelayCommand]
        public void IncreaseVolume()
        {
            _currentTrack.SetVolume(_currentTrack.CurrentVolume + DefaultVolumeChangeStep);
        }

        [RelayCommand]
        public void DecreaseVolume()
        {
            _currentTrack.SetVolume(_currentTrack.CurrentVolume - DefaultVolumeChangeStep);
        }

        [RelayCommand]
        public void SetPreviousTrack()
        {

        }

        [RelayCommand]
        public void SetNextTrack()
        {

        }

        [RelayCommand]
        public void ChangeTrackPlayStatus()
        {

        }

        [RelayCommand]
        public void ChangeTrackRepitStatus()
        {

        }

        [RelayCommand]
        public void ChangeTracksOrdering()
        {

        }
    }
}
