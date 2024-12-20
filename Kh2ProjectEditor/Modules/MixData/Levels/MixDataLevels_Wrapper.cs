using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using KhLib.Kh2.Mixdata;

namespace Kh2ProjectEditor.Modules.MixData.Levels
{
    internal partial class MixDataLevels_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Title))] public ushort titleId;
        [ObservableProperty] public ushort statId;
        [ObservableProperty] public short enable;
        [ObservableProperty] public int exp;
        public string Title => Message_Service.Instance.GetSysText(TitleId);
        public string Stat => Message_Service.Instance.GetSysText(StatId);

        public MixDataLevels_Wrapper(LevelsFile.Entry entry)
        {
            titleId = entry.TitleId;
            statId = entry.StatId;
            enable = entry.Enable;
            exp = entry.Exp;
        }

        public LevelsFile.Entry ToEntry()
        {
            return new LevelsFile.Entry
            {
                TitleId = titleId,
                StatId = statId,
                Enable = enable,
                Exp = exp
            };
        }
    }
}
