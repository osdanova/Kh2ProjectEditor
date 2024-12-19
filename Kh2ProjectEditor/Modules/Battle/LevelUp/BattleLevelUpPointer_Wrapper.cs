using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.LevelUp
{
    internal partial class BattleLevelUpPointer_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(PlayerName))] public int id;
        [ObservableProperty] public int entrySetId;
        public string PlayerName => DataFetcher.GetCharacterName((ushort)id);

        public BattleLevelUpPointer_Wrapper(LevelUpFile.EntryPointer entry)
        {
            id = entry.Id;
            entrySetId = entry.EntrySetId;
        }

        public LevelUpFile.EntryPointer ToEntry()
        {
            return new LevelUpFile.EntryPointer
            {
                Id = id,
                EntrySetId = entrySetId
            };
        }
    }
}
