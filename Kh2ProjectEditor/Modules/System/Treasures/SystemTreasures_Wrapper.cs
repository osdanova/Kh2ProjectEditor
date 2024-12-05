using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.System;
using static KhLib.Kh2.System.TreasuresFile;

namespace Kh2ProjectEditor.Modules.System.Treasures
{
    internal partial class SystemTreasures_Wrapper : ObservableObject
    {
        [ObservableProperty] public ushort id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ItemName))] public ushort itemId;
        [ObservableProperty] public TrsrType type;
        [ObservableProperty] public World_Enum world;
        [ObservableProperty] public byte room;
        [ObservableProperty] public byte roomChestIndex;
        [ObservableProperty] public short eventId;
        [ObservableProperty] public short overallChestIndex;
        public string ItemName => ProjectService.Instance.SystemExists ? DataFetcher.GetItemName(itemId) : null;
        public string RoomName => DataFetcher.GetWorldRoomName((byte)world, room);

        public SystemTreasures_Wrapper(TreasuresFile.Entry entry)
        {
            id = entry.Id;
            itemId = entry.ItemId;
            type = entry.Type;
            world = entry.World;
            room = entry.Room;
            roomChestIndex = entry.RoomChestIndex;
            eventId = entry.EventId;
            overallChestIndex = entry.OverallChestIndex;
        }

        public TreasuresFile.Entry ToEntry()
        {
            return new TreasuresFile.Entry
            {
                Id = id,
                ItemId = itemId,
                Type = type,
                World = world,
                Room = room,
                RoomChestIndex = roomChestIndex,
                EventId = eventId,
                OverallChestIndex = overallChestIndex,
            };
        }
    }
}
