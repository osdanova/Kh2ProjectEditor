using CommunityToolkit.Mvvm.ComponentModel;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.LevelParams
{
    internal partial class BattleLevelParams_Wrapper : ObservableObject
    {
        [ObservableProperty] public int level;
        [ObservableProperty] public ushort hp;
        [ObservableProperty] public ushort strength;
        [ObservableProperty] public ushort defense;
        [ObservableProperty] public ushort attackMax;
        [ObservableProperty] public ushort attackMin;
        [ObservableProperty] public ushort exp;

        public BattleLevelParams_Wrapper(LevelParamsFile.Entry entry)
        {
            level = entry.Level;
            hp = entry.Hp;
            strength = entry.Strength;
            defense = entry.Defense;
            attackMax = entry.AttackMax;
            attackMin = entry.AttackMin;
            exp = entry.Exp;
        }

        public LevelParamsFile.Entry ToEntry()
        {
            return new LevelParamsFile.Entry
            {
                Level = level,
                Hp = hp,
                Strength = strength,
                Defense = defense,
                AttackMax = attackMax,
                AttackMin = attackMin,
                Exp = exp,
            };
        }
    }
}
