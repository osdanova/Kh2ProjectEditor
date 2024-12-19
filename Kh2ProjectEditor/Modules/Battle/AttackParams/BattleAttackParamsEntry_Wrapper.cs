using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;
using static KhLib.Kh2.Battle.AttackParamsFile;

namespace Kh2ProjectEditor.Modules.Battle.AttackParams
{
    internal partial class BattleAttackParamsEntry_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(EntryDesc))] public ushort id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(EntryDesc))] public ushort level;
        [ObservableProperty] public AttackType type;
        [ObservableProperty] public byte baseAdjust;
        [ObservableProperty] public ushort power;
        [ObservableProperty] public TeamType team;
        [ObservableProperty] public ElementType element;
        [ObservableProperty] public byte reactionId;
        [ObservableProperty] public byte effect;
        [ObservableProperty] public short knockbackStr1;
        [ObservableProperty] public short knockbackStr2;
        [ObservableProperty] public ushort unk16;
        [ObservableProperty] public bool flagBgHit;
        [ObservableProperty] public bool flagLimitPAX;
        [ObservableProperty] public bool flagLand;
        [ObservableProperty] public bool flagCapturePax;
        [ObservableProperty] public bool flagThankYou;
        [ObservableProperty] public bool flagKillBoss;
        [ObservableProperty] public RefactType refactSelf;
        [ObservableProperty] public RefactType refactOther;
        [ObservableProperty] public byte reflectMotion;
        [ObservableProperty] public short reflectHitBack;
        [ObservableProperty] public int reflectAct;
        [ObservableProperty] public int hitSoundEffectId;
        [ObservableProperty] public ushort reflectRC;
        [ObservableProperty] public byte refRange;
        [ObservableProperty] public sbyte refAngle;
        [ObservableProperty] public byte damageEffect;
        [ObservableProperty] public byte switchValue;
        [ObservableProperty] public ushort framesPerHit;
        [ObservableProperty] public byte floorCheck;
        [ObservableProperty] public byte addDrive;
        [ObservableProperty] public byte revenge;
        [ObservableProperty] public TrReactionType trReaction;
        [ObservableProperty] public byte comboGroup;
        [ObservableProperty] public byte randomEffect;
        [ObservableProperty] public KindType kind;
        [ObservableProperty] public byte hpGain;
        public string EntryDesc => DataFetcher.GetAttackParamDesc(Id, Level);

        public BattleAttackParamsEntry_Wrapper(AttackParamsFile.Entry entry)
        {
            id = entry.Id;
            level = entry.Level;
            type = entry.Type;
            baseAdjust = entry.BaseAdjust;
            power = entry.Power;
            team = entry.Team;
            element = entry.Element;
            reactionId = entry.ReactionId;
            effect = entry.Effect;
            knockbackStr1 = entry.KnockbackStr1;
            knockbackStr2 = entry.KnockbackStr2;
            unk16 = entry.Unk16;
            flagBgHit = entry.FlagBgHit;
            flagLimitPAX = entry.FlagLimitPAX;
            flagLand = entry.FlagLand;
            flagCapturePax = entry.FlagCapturePax;
            flagThankYou = entry.FlagThankYou;
            flagKillBoss = entry.FlagKillBoss;
            refactSelf = entry.RefactSelf;
            refactOther = entry.RefactOther;
            reflectMotion = entry.ReflectMotion;
            reflectHitBack = entry.ReflectHitBack;
            reflectAct = entry.ReflectAct;
            hitSoundEffectId = entry.HitSoundEffectId;
            reflectRC = entry.ReflectRC;
            refRange = entry.RefRange;
            refAngle = entry.RefAngle;
            damageEffect = entry.DamageEffect;
            switchValue = entry.SwitchValue;
            framesPerHit = entry.FramesPerHit;
            floorCheck = entry.FloorCheck;
            addDrive = entry.AddDrive;
            revenge = entry.Revenge;
            trReaction = entry.TrReaction;
            comboGroup = entry.ComboGroup;
            randomEffect = entry.RandomEffect;
            kind = entry.Kind;
            hpGain = entry.HpGain;
        }

        public AttackParamsFile.Entry ToEntry()
        {
            return new AttackParamsFile.Entry
            {
                Id = id,
                Level = level,
                Type = type,
                BaseAdjust = baseAdjust,
                Power = power,
                Team = team,
                Element = element,
                ReactionId = reactionId,
                Effect = effect,
                KnockbackStr1 = knockbackStr1,
                KnockbackStr2 = knockbackStr2,
                Unk16 = unk16,
                FlagBgHit = FlagBgHit,
                FlagLimitPAX = flagLimitPAX,
                FlagLand = flagLand,
                FlagCapturePax = flagCapturePax,
                FlagThankYou = flagThankYou,
                FlagKillBoss = flagKillBoss,
                RefactSelf = refactSelf,
                RefactOther = refactOther,
                ReflectMotion = reflectMotion,
                ReflectHitBack = reflectHitBack,
                ReflectAct = reflectAct,
                HitSoundEffectId = hitSoundEffectId,
                ReflectRC = reflectRC,
                RefRange = refRange,
                RefAngle = refAngle,
                DamageEffect = damageEffect,
                SwitchValue = switchValue,
                FramesPerHit = framesPerHit,
                FloorCheck = floorCheck,
                AddDrive = addDrive,
                Revenge = revenge,
                TrReaction = trReaction,
                ComboGroup = comboGroup,
                RandomEffect = randomEffect,
                Kind = kind,
                HpGain = hpGain
            };
        }
    }
}
