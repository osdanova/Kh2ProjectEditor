using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.VoiceTable
{
    internal partial class BattleVoiceTable_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CharacterName))] public byte characterId;
        [ObservableProperty] public byte action;
        [ObservableProperty] public byte priority;
        [ObservableProperty] public sbyte voice1Id;
        [ObservableProperty] public byte voice1Chance;
        [ObservableProperty] public sbyte voice2Id;
        [ObservableProperty] public byte voice2Chance;
        [ObservableProperty] public sbyte voice3Id;
        [ObservableProperty] public byte voice3Chance;
        [ObservableProperty] public sbyte voice4Id;
        [ObservableProperty] public byte voice4Chance;
        [ObservableProperty] public sbyte voice5Id;
        [ObservableProperty] public byte voice5Chance;
        public string CharacterName => DataFetcher.GetCharacterName(characterId);

        public BattleVoiceTable_Wrapper(VoiceTableFile.Entry entry)
        {
            characterId = entry.CharacterId;
            action = entry.Action;
            priority = entry.Priority;
            voice1Id = entry.Voice1Id;
            voice1Chance = entry.Voice1Chance;
            voice2Id = entry.Voice2Id;
            voice2Chance = entry.Voice2Chance;
            voice3Id = entry.Voice3Id;
            voice3Chance = entry.Voice3Chance;
            voice4Id = entry.Voice4Id;
            voice4Chance = entry.Voice4Chance;
            voice5Id = entry.Voice5Id;
            voice5Chance = entry.Voice5Chance;
        }

        public VoiceTableFile.Entry ToEntry()
        {
            return new VoiceTableFile.Entry
            {
                CharacterId = characterId,
                Action = action,
                Priority = priority,
                Voice1Id = voice1Id,
                Voice1Chance = voice1Chance,
                Voice2Id = voice2Id,
                Voice2Chance = voice2Chance,
                Voice3Id = voice3Id,
                Voice3Chance = voice3Chance,
                Voice4Id = voice4Id,
                Voice4Chance = voice4Chance,
                Voice5Id = voice5Id,
                Voice5Chance = voice5Chance
            };
        }
    }
}
