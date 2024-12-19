using CommunityToolkit.Mvvm.ComponentModel;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.Stop
{
    internal partial class BattleStop_Wrapper : ObservableObject
    {
        [ObservableProperty] public ushort id;
        [ObservableProperty] public bool flagStop;
        [ObservableProperty] public bool flagDamageReaction;
        [ObservableProperty] public bool flagStar;

        public BattleStop_Wrapper(StopFile.Entry entry)
        {
            id = entry.Id;
            flagStop = entry.FlagStop;
            flagDamageReaction = entry.FlagDamageReaction;
            flagStar = entry.FlagStar;
        }

        public StopFile.Entry ToEntry()
        {
            return new StopFile.Entry
            {
                Id = id,
                FlagStop = flagStop,
                FlagDamageReaction = flagDamageReaction,
                FlagStar = flagStar
            };
        }
    }
}
