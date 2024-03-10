using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediaPlayerWithGestureRecognition.Areas.Player.Models;
using System;
using System.IO;
using NAudio.Wave;
//using static Android.Provider.MediaStore.Audio;
//using System.Windows.Input;
//using System.Windows.Media.Playlists;

namespace MediaPlayerWithGestureRecognition.Areas.Player.ViewModels
{
    public enum ePlayerStatus
    {
        Playing,
        Paused,
        Stopped
    }

    public sealed partial class PlayerViewModel : ObservableObject
    {
        private const float DefaultRewindTime = 5;

        //private readonly Playlist _playlist;

        private readonly Track _currentTrack;

        private bool _canRewindBackwards;
        private bool _canRewindForward;
        private bool _canSetPreviousTrack;
        private bool _canSetNextTrack;

        private readonly WaveOutEvent _outputDevice;
        private AudioFileReader _audioFileReader;

        ePlayerStatus PlayerStatus;

        //public PlayerViewModel(Playlist playlist, Track currentTrack)
        //{
        //    _playlist = playlist;
        //    _currentTrack = currentTrack;
        //}

        public PlayerViewModel()
        {
            _outputDevice = new WaveOutEvent();
            _outputDevice.PlaybackStopped += OnPlaybackStopped;
        }

        public string CurrentTrackTitle => _currentTrack.Title;

        public float CurrentTrackTime => _currentTrack.CurrentTime;

        //public float Volume
        //{
        //    get => _currentTrack.Volume;
        //    set => _currentTrack.Volume = value;
        //}

        public void OpenFile(string path)
        {
            var isFileValid = File.Exists(path);

            if (isFileValid)
            {
                try
                {
                    _audioFileReader = new AudioFileReader(path);
                    _outputDevice.Init(_audioFileReader);
                    _outputDevice.Play();
                    PlayerStatus = ePlayerStatus.Playing;
                }
                catch (FileNotFoundException)
                {
                }
            }
        }

        public void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            if (_audioFileReader is not null)
            {
                _audioFileReader.Dispose();
            }

            _outputDevice.Dispose();
        }

        [RelayCommand]
        public void RewindBackwards()
        {
            if (_audioFileReader != null && _audioFileReader.CurrentTime >= TimeSpan.FromSeconds(DefaultRewindTime))
            {
                _audioFileReader.CurrentTime = _audioFileReader.CurrentTime.Subtract(TimeSpan.FromSeconds(DefaultRewindTime));
            }
        }

        [RelayCommand]
        public void RewindForward()
        {
            if (_audioFileReader != null && _audioFileReader.CurrentTime <= _audioFileReader.TotalTime)
            {
                _audioFileReader.CurrentTime = _audioFileReader.CurrentTime.Add(TimeSpan.FromSeconds(DefaultRewindTime));
            }
        }

        [RelayCommand]
        public void IncreaseVolume()
        {
            if (_outputDevice.Volume > 0.9f)
            {
                _outputDevice.Volume = 1.0f;
                return;
            }

            _outputDevice.Volume += 0.1f;
        }

        [RelayCommand]
        public void DecreaseVolume()
        {
            if (_outputDevice.Volume < 0.1f)
            {
                _outputDevice.Volume = 0.0f;
                return;
            }

            _outputDevice.Volume -= 0.1f;
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
