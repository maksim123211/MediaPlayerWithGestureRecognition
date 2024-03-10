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
        public readonly Title Title;

        public readonly Path ImagePath;

        public readonly TrackTime TotalTime;

        private TrackTime _currentTime;

        public Track(Title title, Path imagePath, TrackTime totalTime, TrackTime currentTime = default)
        {

            Title = title;
            ImagePath = imagePath;
            TotalTime = totalTime;
            _currentTime = currentTime;
        }

        public TrackTime CurrentTime => _currentTime;

        public void RewindTo(float timeToRewind)
        {
            if (timeToRewind < 0 || timeToRewind > TotalTime)
            {
                throw new ArgumentOutOfRangeException(nameof(timeToRewind));
            }

            _currentTime = timeToRewind;
        }
    }

    public readonly struct Title
    {
        private const int MinLength = 5;

        private readonly string _value;

        public Title(string value)
        {
            ArgumentOutOfRangeException.ThrowIfNullOrWhiteSpace(nameof(value));
            ArgumentOutOfRangeException.ThrowIfLessThan(value.Length, MinLength);
            _value = value;
        }

        public static implicit operator Title(string value)
        {
            return new Title(value);
        }

        public static implicit operator string(Title title) 
        {
            return title._value;
        }
    }

    public struct Path
    {
        private const string Pattern = "^(?:[a-zA-Z]:)?(\\[^\\?%*:|<>\"]+)+$";

        private readonly string _value;

        public Path(string value)
        {
            Regex regex = new Regex(Pattern);

            if (regex.IsMatch(value))
            {
                _value = value;
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
        
        public static implicit operator Path(string value)
        {
            return new Path(value);
        }

        public static implicit operator string(Path image)
        {
            return image._value;
        }
    }

    public struct TrackTime
    {
        private readonly float _value;

        public TrackTime(float value)
        {
            if (value > 0)
            {
                _value = value;
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static implicit operator TrackTime(float value)
        {
            return new TrackTime(value);
        }

        public static implicit operator float(TrackTime time)
        {
            return time._value;
        }
    }
}
