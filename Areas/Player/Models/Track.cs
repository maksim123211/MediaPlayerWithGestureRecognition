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

        public readonly Image ImagePath;

        public readonly TotalTime TotalTime;

        private CurrentTime _currentTime;

        public Track(Title title, Image imagePath, TotalTime totalTime, CurrentTime currentTime)
        {

            Title = title;
            ImagePath = imagePath;
            TotalTime = totalTime;
            _currentTime = currentTime;
        }

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

    public struct Image
    {
        private const string Pattern = "^(?:[a-zA-Z]:)?(\\[^\\?%*:|<>\"]+)+$";

        private readonly string _value;

        public Image(string value)
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
        
        public static implicit operator Image(string value)
        {
            return new Image(value);
        }

        public static implicit operator string(Image image)
        {
            return image._value;
        }
    }

    public struct TotalTime
    {
        private readonly float _value;

        public TotalTime(float value)
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

        public static implicit operator TotalTime(float value)
        {
            return new TotalTime(value);
        }

        public static implicit operator float(TotalTime time)
        {
            return time._value;
        }
    }

    public struct CurrentTime
    {
        private readonly float _value;

        public CurrentTime(float value)
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

        public static implicit operator CurrentTime(float value)
        {
            return new CurrentTime(value);
        }

        public static implicit operator float(CurrentTime time)
        {
            return time._value;
        }
    }
}
