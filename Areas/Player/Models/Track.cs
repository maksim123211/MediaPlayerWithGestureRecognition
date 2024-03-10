using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MediaPlayerWithGestureRecognition.Areas.Player.Models
{
    public sealed class Track
    {
        private readonly IWavePlayer _audioFilePlayer;
        private readonly AudioFileReader _audioFile;

        public Track(string filePath)
        {
            _audioFile = new AudioFileReader(filePath);
            _audioFilePlayer = new WaveOutEvent();
            _audioFilePlayer.Init(_audioFile);
        }

        ~Track()
        {
            _audioFilePlayer.Stop();
            _audioFile.Dispose();
            _audioFilePlayer.Dispose();
        }

        public TimeSpan Duration => _audioFile.TotalTime;

        public TimeSpan CurrentTime => _audioFile.TotalTime;

        public float CurrentVolume => _audioFile.Volume;

        public void Play()
        {
            _audioFilePlayer.Play();
        }

        public void Pause()
        {
            _audioFilePlayer.Pause();
        }

        public void Rewind(TimeSpan time)
        {
            if (time.Ticks < 0 || time > Duration)
            {
                throw new ArgumentOutOfRangeException(nameof(time));
            }

            _audioFile.CurrentTime = time;
        }

        public void SetVolume(float volume)
        {
            const float minVolume = 0f;
            const float maxVolume = 1f;
            _audioFilePlayer.Volume = Math.Clamp(volume, minVolume, maxVolume);
        }
    }

    public sealed class TrackPath
    {
        public readonly string FilePath;
        public readonly string FileName;
        public readonly string FileExtensions;

        public readonly string FullPath;

        public TrackPath(string fullPath)
        {
            Regex regex = new Regex(Pattern);

            if (!regex.IsMatch(fullPath))
            {
                _value = value;
            }
        }
    }
}