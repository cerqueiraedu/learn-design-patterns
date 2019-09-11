
using SuggestTracks.Providers.Interfaces;

namespace SuggestTracks.Providers
{
    public class SpotifyMusicTrackProvider : IMusicTrackProvider
    {
        public IEnumerable<MusicTrack> Fetch(string mood)
        {
            return new List<MusicTrack>();
        }
    }
}