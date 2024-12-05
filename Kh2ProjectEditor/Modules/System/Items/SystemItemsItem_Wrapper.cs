using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.System;
using static KhLib.Kh2.System.ItemsFile;

namespace Kh2ProjectEditor.Modules.System.Items
{
    internal partial class SystemItemsItem_Wrapper : ObservableObject
    {
        [ObservableProperty] public ushort id;
        [ObservableProperty] public Type type;
        [ObservableProperty] public ushort paramId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Name))] public ushort nameId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Description))] public ushort descriptionId;
        [ObservableProperty] public ushort buyPrice;
        [ObservableProperty] public ushort sellPrice;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CommandName))] public ushort commandId;
        [ObservableProperty] public ushort slot;
        [ObservableProperty] public short picture;
        [ObservableProperty] public PrizeboxType prizebox;
        [ObservableProperty] public byte icon;
        [ObservableProperty] public short abilityId;
        [ObservableProperty] public AbilityType abiType;
        [ObservableProperty] public byte abilityAp;
        [ObservableProperty] public short consumableCureRate;
        [ObservableProperty] public short consumableEffect;
        [ObservableProperty] public short equipmentParam;
        [ObservableProperty] public short magicId;
        [ObservableProperty] public byte synthesisType;
        [ObservableProperty] public Rank synthesisRank;
        [ObservableProperty] public short reportId;
        [ObservableProperty] public short weaponId;
        [ObservableProperty] public short weaponParam;
        [ObservableProperty] public World_Enum mapWorld;

        public string CommandName => ProjectService.Instance.SystemExists ? DataFetcher.GetCommandMessage(CommandId) : null;
        public string Name => MessageService.Instance.GetEntryText(NameId);
        public string Description => MessageService.Instance.GetEntryText(DescriptionId);

        public SystemItemsItem_Wrapper(ItemsFile.Entry entry)
        {
            id = entry.Id;
            type = entry.Type;
            nameId = entry.NameId;
            descriptionId = entry.DescriptionId;
            buyPrice = entry.BuyPrice;
            sellPrice = entry.SellPrice;
            commandId = entry.CommandId;
            slot = entry.Slot;
            picture = entry.Picture;
            prizebox = entry.Prizebox;
            icon = entry.Icon;

            switch (type)
            {
                case (Type.Ability):
                    abilityId = entry.AbilityId;
                    abiType = (AbilityType)entry.AbilityType;
                    abilityAp = entry.AbilityAp;
                    break;
                case (Type.Consumable):
                    consumableCureRate = entry.ConsumableCureRate;
                    consumableEffect = entry.ConsumableEffect;
                    break;
                case Type.Armor:
                case Type.Accessory:
                    equipmentParam = entry.EquipmentParam;
                    break;
                case (Type.Magic):
                    magicId = entry.MagicId;
                    break;
                case (Type.Synthesis):
                    synthesisType = entry.SynthesisType;
                    synthesisRank = (Rank)entry.SynthesisRank;
                    break;
                case (Type.Report):
                    reportId = entry.ReportId;
                    break;
                case Type.Keyblade:
                case Type.Staff:
                case Type.Shield:
                case Type.PingWeapon:
                case Type.AuronWeapon:
                case Type.BeastWeapon:
                case Type.JackWeapon:
                case Type.DummyWeapon:
                case Type.RikuWeapon:
                case Type.SimbaWeapon:
                case Type.JackSparrowWeapon:
                case Type.TronWeapon:
                    weaponId = entry.WeaponId;
                    weaponParam = entry.WeaponParam;
                    break;
                case (Type.Map):
                    mapWorld = entry.MapWorld;
                    break;
            }
        }

        public ItemsFile.Entry ToEntry()
        {
            ItemsFile.Entry entry = new ItemsFile.Entry
            {
                Id = id,
                Type = type,
                NameId = nameId,
                DescriptionId = descriptionId,
                BuyPrice = buyPrice,
                SellPrice = sellPrice,
                CommandId = commandId,
                Slot = slot,
                Picture = picture,
                Prizebox = prizebox,
                Icon = icon
            };

            switch (type)
            {
                case (Type.Ability):
                    entry.AbilityId = abilityId;
                    entry.AbilityType = (byte)abiType;
                    entry.AbilityAp = abilityAp;
                    break;
                case (Type.Consumable):
                    entry.ConsumableCureRate = consumableCureRate;
                    entry.ConsumableEffect = consumableEffect;
                    break;
                case Type.Armor:
                case Type.Accessory:
                    entry.EquipmentParam = equipmentParam;
                    break;
                case (Type.Magic):
                    entry.MagicId = magicId;
                    break;
                case (Type.Synthesis):
                    entry.SynthesisType = synthesisType;
                    entry.SynthesisRank = (byte)synthesisRank;
                    break;
                case (Type.Report):
                    entry.ReportId = reportId;
                    break;
                case Type.Keyblade:
                case Type.Staff:
                case Type.Shield:
                case Type.PingWeapon:
                case Type.AuronWeapon:
                case Type.BeastWeapon:
                case Type.JackWeapon:
                case Type.DummyWeapon:
                case Type.RikuWeapon:
                case Type.SimbaWeapon:
                case Type.JackSparrowWeapon:
                case Type.TronWeapon:
                    entry.WeaponId = weaponId;
                    entry.WeaponParam = weaponParam;
                    break;
                case (Type.Map):
                    entry.MapWorld = mapWorld;
                    break;
            }

            return entry;
        }
    }
}
