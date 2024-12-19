using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.LevelUp
{
    internal partial class BattleLevelUpEntry_Wrapper : ObservableObject
    {
        [ObservableProperty] public int level;
        [ObservableProperty] public int exp;
        [ObservableProperty] public byte strength;
        [ObservableProperty] public byte magic;
        [ObservableProperty] public byte defense;
        [ObservableProperty] public byte ap;
        [ObservableProperty] public ushort abilitySwordId;
        [ObservableProperty] public ushort abilityShieldId;
        [ObservableProperty] public ushort abilityStaffId;
        public string AbilitySwordName => DataFetcher.GetItemName(abilitySwordId);
        public string AbilityShieldName => DataFetcher.GetItemName(abilityShieldId);
        public string AbilityStaffName => DataFetcher.GetItemName(abilityStaffId);

        public BattleLevelUpEntry_Wrapper(LevelUpFile.Entry entry)
        {
            level = entry.Level;
            exp = entry.Exp;
            strength = entry.Strength;
            magic = entry.Magic;
            defense = entry.Defense;
            ap = entry.Ap;
            abilitySwordId = entry.AbilitySwordId;
            abilityShieldId = entry.AbilityShieldId;
            abilityStaffId = entry.AbilityStaffId;
        }

        public LevelUpFile.Entry ToEntry()
        {
            return new LevelUpFile.Entry
            {
                Level = level,
                Exp = exp,
                Strength = strength,
                Magic = magic,
                Defense = defense,
                Ap = ap,
                AbilitySwordId = abilitySwordId,
                AbilityShieldId = abilityShieldId,
                AbilityStaffId = abilityStaffId
            };
        }
    }
}
