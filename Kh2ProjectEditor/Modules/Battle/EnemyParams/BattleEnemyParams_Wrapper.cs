using CommunityToolkit.Mvvm.ComponentModel;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.EnemyParams
{
    internal partial class BattleEnemyParams_Wrapper : ObservableObject
    {
        [ObservableProperty] public ushort id;
        [ObservableProperty] public ushort level;
        [ObservableProperty] public ushort[] hp;
        [ObservableProperty] public ushort damageMax;
        [ObservableProperty] public ushort damageMin;
        [ObservableProperty] public ushort resPhysical;
        [ObservableProperty] public ushort resFire;
        [ObservableProperty] public ushort resBlizzard;
        [ObservableProperty] public ushort resThunder;
        [ObservableProperty] public ushort resDark;
        [ObservableProperty] public ushort resSpecial;
        [ObservableProperty] public ushort resAbsolute;
        [ObservableProperty] public ushort exp;
        [ObservableProperty] public ushort prize;
        [ObservableProperty] public ushort bonusLevel;
        //[ObservableProperty][NotifyPropertyChangedFor(nameof(Drop1Name))] public ushort drop1Id;
        //public string Drop1Name => DataFetcher.GetItemName(drop1Id);

        public BattleEnemyParams_Wrapper(EnemyParamsFile.Entry entry)
        {
            id = entry.Id;
            level = entry.Level;
            hp = entry.Hp;
            damageMax = entry.DamageMax;
            damageMin = entry.DamageMin;
            resPhysical = entry.ResPhysical;
            resFire = entry.ResFire;
            resBlizzard = entry.ResBlizzard;
            resThunder = entry.ResThunder;
            resDark = entry.ResDark;
            resSpecial = entry.ResSpecial;
            resAbsolute = entry.ResAbsolute;
            exp = entry.Exp;
            prize = entry.Prize;
            bonusLevel = entry.BonusLevel;
        }

        public EnemyParamsFile.Entry ToEntry()
        {
            return new EnemyParamsFile.Entry
            {
                Id = id,
                Level = level,
                Hp = hp,
                DamageMax = damageMax,
                DamageMin = damageMin,
                ResPhysical = resPhysical,
                ResFire = resFire,
                ResBlizzard = resBlizzard,
                ResThunder = resThunder,
                ResDark = resDark,
                ResSpecial = resSpecial,
                ResAbsolute = resAbsolute,
                Exp = exp,
                Prize = prize,
                BonusLevel = bonusLevel
            };
        }
    }
}
