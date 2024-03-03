using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerWithGestureRecognition.Areas.Player.Models
{
    public sealed class PlayList : IEnumerable<Track>
    {
        private readonly List<Track> _tracks;

        public PlayList(IEnumerable<Track> tracks) 
        {
            _tracks = (tracks ?? throw new ArgumentNullException(nameof(tracks))).ToList();
        }

        public PlayList() : this(tracks:Array.Empty<Track>())
        {

        }

        public int Count => _tracks.Count;

        public Track this[int index] => _tracks[index];

        public void Add(Track track) 
        {
            _tracks.Add(track);
        }

        public void Remove(Track track)
        {
            _tracks.Remove(track);
        }

        public IEnumerator<Track> GetEnumerator() 
        {
            return _tracks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
