using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.BonusLevels
{
    internal partial class BattleBonusLevelsEntry_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(BonusEventName))] public byte bonusEventId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CharacterName))] public byte characterId;
        [ObservableProperty] public byte hp;
        [ObservableProperty] public byte mp;
        [ObservableProperty] public byte drive;
        [ObservableProperty] public byte itemSlot;
        [ObservableProperty] public byte accessorySlot;
        [ObservableProperty] public byte armorSlot;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item1Name))] public ushort item1Id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item2Name))] public ushort item2Id;
        public string BonusEventName => DataFetcher.GetBonusEventDesc(bonusEventId);
        public string CharacterName => DataFetcher.GetCharacterName(characterId);
        public string Item1Name => DataFetcher.GetItemName(item1Id);
        public string Item2Name => DataFetcher.GetItemName(item2Id);

        public BattleBonusLevelsEntry_Wrapper(BonusLevelsFile.Entry entry)
        {
            bonusEventId = entry.BonusEventId;
            characterId = entry.CharacterId;
            hp = entry.Hp;
            mp = entry.Mp;
            drive = entry.Drive;
            itemSlot = entry.ItemSlot;
            accessorySlot = entry.AccessorySlot;
            armorSlot = entry.ArmorSlot;
            item1Id = entry.Item1Id;
            item2Id = entry.Item2Id;
        }

        public BonusLevelsFile.Entry ToEntry()
        {
            return new BonusLevelsFile.Entry
            {
                BonusEventId = bonusEventId,
                CharacterId = characterId,
                Hp = hp,
                Mp = mp,
                Drive = drive,
                ItemSlot = itemSlot,
                AccessorySlot = accessorySlot,
                ArmorSlot = armorSlot,
                Item1Id = item1Id,
                Item2Id = item2Id
            };
        }
    }
}
