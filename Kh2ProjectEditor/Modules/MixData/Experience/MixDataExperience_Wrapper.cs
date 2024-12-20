using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Mixdata;

namespace Kh2ProjectEditor.Modules.MixData.Experience
{
    internal partial class MixDataExperience_Wrapper : ObservableObject
    {
        //[ObservableProperty][NotifyPropertyChangedFor(nameof(Title))] public ushort titleId;
        [ObservableProperty] public ushort rankC;
        [ObservableProperty] public ushort rankB;
        [ObservableProperty] public ushort rankA;
        [ObservableProperty] public ushort rankS;
        [ObservableProperty] public float expRate;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Progress))] public ushort progressId;
        [ObservableProperty] public ushort func;
        public string Progress => DataFetcher.GetProgressFlagDescription(ProgressId);

        public MixDataExperience_Wrapper(ExperienceFile.Entry entry)
        {
            rankC = entry.RankC;
            rankB = entry.RankB;
            rankA = entry.RankA;
            rankS = entry.RankS;
            expRate = entry.ExpRate;
            progressId = entry.ProgressId;
            func = entry.Func;
        }

        public ExperienceFile.Entry ToEntry()
        {
            return new ExperienceFile.Entry
            {
                RankC = rankC,
                RankB = rankB,
                RankA = rankA,
                RankS = rankS,
                ProgressId = progressId,
                Func = func
            };
        }
    }
}
