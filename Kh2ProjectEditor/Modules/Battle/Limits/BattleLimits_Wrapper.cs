using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;
using KhLib.Kh2.Dictionaries;

namespace Kh2ProjectEditor.Modules.Battle.Limits
{
    internal partial class BattleLimits_Wrapper : ObservableObject
    {
        [ObservableProperty] public byte id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Character1Name))] public byte character1Id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Character2Name))] public byte character2Id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Character3Name))] public byte character3Id;
        [ObservableProperty] public string filename;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ObjectName))] public uint objectId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CommandName))] public ushort commandId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ItemName))] public ushort itemId;
        [ObservableProperty] public World_Enum worldId;
        public string Character1Name => DataFetcher.GetCharacterName(Character1Id);
        public string Character2Name => DataFetcher.GetCharacterName(Character2Id);
        public string Character3Name => DataFetcher.GetCharacterName(Character3Id);
        public string ObjectName => DataFetcher.GetObjectDescription(ObjectId);
        public string CommandName => DataFetcher.GetCommandMessage(CommandId);
        public string ItemName => DataFetcher.GetItemName(ItemId);

        public BattleLimits_Wrapper(LimitsFile.Entry entry)
        {
            id = entry.Id;
            character1Id = entry.Character1Id;
            character2Id = entry.Character2Id;
            character3Id = entry.Character3Id;
            filename = entry.Filename;
            objectId = entry.ObjectId;
            commandId = entry.CommandId;
            itemId = entry.ItemId;
            worldId = entry.WorldId;
        }

        public LimitsFile.Entry ToEntry()
        {
            return new LimitsFile.Entry
            {
                Id = id,
                Character1Id = character1Id,
                Character2Id = character2Id,
                Character3Id = character3Id,
                Filename = filename,
                ObjectId = ObjectId,
                CommandId = commandId,
                ItemId = itemId,
                WorldId = worldId
            };
        }
    }
}
