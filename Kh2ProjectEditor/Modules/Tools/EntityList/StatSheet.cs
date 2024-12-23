using Xe.BinaryMapper;

namespace Kh2ProjectEditor.Modules.Tools.EntityList
{
    internal class StatSheet
    {
        public class Entry
        {
            [Data(Count = 32)] public Health[] Hp { get; set; } // 384 bytes
            [Data] public int Mp { get; set; }
            [Data] public int MaxMp { get; set; }
            [Data] public Param Params { get; set; } // 8 bytes
            [Data] public Param NakedParams { get; set; }
            [Data] public int MaxAttack { get; set; }
            [Data] public int MinAttack { get; set; }
            [Data] public int MaxDamage { get; set; }
            [Data] public int MinDamage { get; set; }
            [Data(Count = 7)] public byte[] Element { get; set; }
            [Data] public byte DriveType { get; set; }
            [Data] public byte Drive { get; set; }
            [Data] public byte DriveCount { get; set; }
            [Data] public byte DriveCountMax { get; set; }
            [Data] public byte DriveTimeCount { get; set; }
            [Data] public float DriveTime { get; set; }
            [Data] public float DriveTimeMax { get; set; }
            [Data] public float MpDrive { get; set; }
            [Data] public float MpDriveMax { get; set; }
            [Data] public float PrizeRange { get; set; }
            [Data] public float HitBackAddition { get; set; }
            [Data] public Ability AbilitySheet { get; set; }
            [Data] public long PartRamPointer { get; set; }
            [Data] public long FormRamPointer { get; set; }
            [Data] public byte AttackLevel { get; set; }
            [Data(Count = 3)] public byte[] UnknownBytes { get; set; }
            [Data] public int CharacterId { get; set; }
            [Data] public int RefCount { get; set; }
            [Data] public int BattleObjectPointer { get; set; }
            [Data] public int SaveRambattlePointer { get; set; }
            [Data] public int EnemyParamPointer { get; set; }
            // 4b padding
        }

        public class Health
        {
            [Data] public int CurrentHp { get; set; }
            [Data] public int MaxHp { get; set; }
            [Data] public int MinHp { get; set; }
        }
        public class Param
        {
            [Data] public ushort Attack { get; set; }
            [Data] public ushort Wisdom { get; set; }
            [Data] public ushort Defence { get; set; }
            [Data] public ushort Ap { get; set; }
        }

        public class Ability
        {
            [Data(Count = 36)] public byte[] Flag { get; set; }
            [Data(Count = 5)] public byte[] MagicLevels { get; set; }
            [Data(Count = 3)] public byte[] UnknownBytes { get; set; }
            [Data] public long StatSheetPointer { get; set; }
            [Data] public byte Combo { get; set; }
            [Data] public byte AirCombo { get; set; }
            [Data] public byte FinishCombo { get; set; }
            [Data] public byte ExpChance { get; set; }
            [Data] public byte Defender { get; set; }
            [Data(Count = 3)] public byte[] UnknownBytes2 { get; set; }
            [Data] public float PrizeDrawRange { get; set; }
            [Data] public float MpDriveSpeed { get; set; }
            [Data] public float DriveBoost { get; set; }
            [Data] public float FormBoost { get; set; }
            [Data] public ushort FireUp { get; set; }
            [Data] public ushort BlizzardUp { get; set; }
            [Data] public ushort ThunderUp { get; set; }
            [Data] public ushort ComboDamageUp { get; set; }
            [Data] public ushort AirComboDamageUp { get; set; }
            [Data] public ushort RcDamageUp { get; set; }
            [Data] public ushort ItemUp { get; set; }
            [Data] public ushort DriveBerserk { get; set; }
            [Data] public float DamageDrive { get; set; }
            [Data] public float DamageAspil { get; set; }
            [Data] public float HyperHeal { get; set; }
            [Data] public float CombiBoost { get; set; }
            [Data] public float PrizeUp { get; set; }
            [Data] public float LuckUp { get; set; }
            [Data] public float SummonBoost { get; set; }
            [Data] public float DriveConvert { get; set; }
            [Data] public float DefenceMaster { get; set; }
        }
    }
}
