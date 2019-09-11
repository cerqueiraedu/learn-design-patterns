using System;

namespace SuggestTracks
{
    public interface IMoodTemperature
    {
        bool IsWithinMoodTemperature(decimal currentTemperature);
    }

    public class RangedTemperature : IMoodTemperature
    {
        public decimal MinimumTemperature { get; protected set; }    
        public decimal MaximumTemperature { get; protected set; }    

        public RangeMoodTemperature(decimal minimumTemperature, decimal maximumTemperature)
        {
            MinimumTemperature = minimumTemperature;
            MaximumTemperature = maximumTemperature;
        }

        public bool IsWithinMoodTemperature(decimal currentTemperature)
        {
            return (currentTemperature >= minimumTemperature) && (currentTemperature <= MaximumTemperature);
        }
    }
    public class BelowThresholdTemperature : IMoodTemperature
    {
        public decimal ThresholdTemperature { get; protected set; }      

        public BelowMoodTemperature(decimal thresholdTemperature)
        {
            ThresholdTemperature = thresholdTemperature;
        }

        public bool IsWithinMoodTemperature(decimal currentTemperature)
        {
            return currentTemperature < ThresholdTemperature;
        }
    }

    public class AboveThresholdTemperature : IMoodTemperature
    {
        public decimal ThresholdTemperature { get; protected set; }    

        public AboveMoodTemperature(decimal thresholdTemperature)
        {
            ThresholdTemperature = thresholdTemperature;
        }

        public bool IsWithinMoodTemperature(decimal currentTemperature)
        {
            return currentTemperature > ThresholdTemperature;
        }
    }

    public abstract class MusicTrackSelection
    {
        protected IMoodTemperature MoodTemperature;
        protected IFetchTracksService TrackSelector;

        protected MusicTrackSelection(IMoodTemperature moodTemperature, IFetchTracksService trackSelector)
        {
            MoodTemperature = moodTemperature;
            TrackSelector = trackSelector;
        }

        public abstract IEnumerable<Track> GetTracks();

        public bool IsWithinMoodTemperature(decimal currentTemperature)
        {
            return moodTemperature.IsWithinMoodTemperature();
        }
    }

    

    public class PartyMusicTrackSelection : MusicTrackSelection
    {
        public PartyMusicTrackSelection(IFetchTracks trackSelector) : base(new AboveThresholdTemperature(30), trackSelector)
        {
        }
        
        public IEnumerable<Track> GetTracks()
        {
            trackSelector.Fetch("party");
        }
    }

    public class PopMusicTrackSelection : MusicTrackSelection
    {
        public PopMusicTrackSelection(IFetchTracks trackSelector) : base(new RangedTemperature(15, 30), trackSelector)
        {
        }
        
        public IEnumerable<Track> GetTracks()
        {
            trackSelector.Fetch("pop");
        }
    }

    public class RockMusicTrackSelection : MusicTrackSelection
    {
        public RockMusicTrackSelection(IFetchTracks trackSelector) : base(new RangedTemperature(10, 14), trackSelector)
        {
        }
        
        public IEnumerable<Track> GetTracks()
        {
            trackSelector.Fetch("rock");
        }
    }

    public class ClassicalMusicTrackSelection : MusicTrackSelection
    {
        public ClassicalMusicTrackSelection(IFetchTracks trackSelector) : base(new BelowThresholdTemperatureTemperature(14), trackSelector)
        {
        }
        
        public IEnumerable<Track> GetTracks()
        {
            trackSelector.Fetch("mood");
        }
    }
}
