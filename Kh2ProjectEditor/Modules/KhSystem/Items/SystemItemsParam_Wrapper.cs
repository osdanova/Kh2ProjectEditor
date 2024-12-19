using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.KhSystem;

namespace Kh2ProjectEditor.Modules.KhSystem.Items
{
    internal partial class SystemItemsParam_Wrapper : ObservableObject
    {
        [ObservableProperty] public ushort id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Ability))] public ushort abilityId;
        [ObservableProperty] public byte strength;
        [ObservableProperty] public byte magic;
        [ObservableProperty] public byte defense;
        [ObservableProperty] public byte abilityPoints;
        [ObservableProperty] public byte physicalResistance;
        [ObservableProperty] public byte fireResistance;
        [ObservableProperty] public byte iceResistance;
        [ObservableProperty] public byte lightningResistance;
        [ObservableProperty] public byte darkResistance;
        [ObservableProperty] public byte neutralResistance;
        [ObservableProperty] public byte generalResistance;
        [ObservableProperty] public byte padding;

        public string Ability => DataFetcher.GetItemName(AbilityId);

        public SystemItemsParam_Wrapper(ItemsFile.Param entry)
        {
            id = entry.Id;
            abilityId = entry.AbilityId;
            strength = entry.Strength;
            magic = entry.Magic;
            defense = entry.Defense;
            abilityPoints = entry.AbilityPoints;
            physicalResistance = entry.PhysicalResistance;
            fireResistance = entry.FireResistance;
            iceResistance = entry.IceResistance;
            lightningResistance = entry.LightningResistance;
            darkResistance = entry.DarkResistance;
            neutralResistance = entry.NeutralResistance;
            generalResistance = entry.GeneralResistance;
            padding = entry.Padding;
        }

        public ItemsFile.Param ToEntry()
        {
            return new ItemsFile.Param
            {
                Id = id,
                AbilityId = abilityId,
                Strength = strength,
                Magic = magic,
                Defense = defense,
                AbilityPoints = abilityPoints,
                PhysicalResistance = physicalResistance,
                FireResistance = fireResistance,
                IceResistance = iceResistance,
                LightningResistance = lightningResistance,
                DarkResistance = darkResistance,
                NeutralResistance = neutralResistance,
                GeneralResistance = generalResistance,
                Padding = padding
            };
        }
    }
}
