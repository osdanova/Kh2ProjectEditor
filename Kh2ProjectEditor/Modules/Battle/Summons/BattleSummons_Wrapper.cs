using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.Summons
{
    internal partial class BattleSummons_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CommandName))] public ushort commandId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ItemName))] public ushort itemId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Object1Name))] public uint object1Id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Object2Name))] public uint object2Id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(LimitCommandName))] public ushort limitCommandId;
        public string CommandName => DataFetcher.GetCommandMessage(CommandId);
        public string ItemName => DataFetcher.GetItemName(ItemId);
        public string Object1Name => DataFetcher.GetObjectDescription(Object1Id);
        public string Object2Name => DataFetcher.GetObjectDescription(Object2Id);
        public string LimitCommandName => DataFetcher.GetCommandMessage(LimitCommandId);

        public BattleSummons_Wrapper(SummonsFile.Entry entry)
        {
            commandId = entry.CommandId;
            itemId = entry.ItemId;
            object1Id = entry.Object1Id;
            object2Id = entry.Object2Id;
            limitCommandId = entry.LimitCommandId;
        }

        public SummonsFile.Entry ToEntry()
        {
            return new SummonsFile.Entry
            {
                CommandId = commandId,
                ItemId = itemId,
                Object1Id = object1Id,
                Object2Id = object2Id,
                LimitCommandId = limitCommandId
            };
        }
    }
}
