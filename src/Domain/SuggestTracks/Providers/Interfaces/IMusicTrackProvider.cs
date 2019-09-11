using SuggestTracks.Models;

namespace SuggestTracks.Providers.Interfaces
{
    public interface IMusicTrackProvider
    {
        IEnumerable<MusicTrack> Fetch(string mood);
    }
}