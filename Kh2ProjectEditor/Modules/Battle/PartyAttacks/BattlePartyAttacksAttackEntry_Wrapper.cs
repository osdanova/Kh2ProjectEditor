using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.PartyAttacks
{
    internal partial class BattlePartyAttacksAttackEntry_Wrapper : ObservableObject
    {
        [ObservableProperty] public byte id;
        [ObservableProperty] public byte type;
        [ObservableProperty] public sbyte sub;
        [ObservableProperty] public byte comboOffset;
        [ObservableProperty] public bool flagAerial;
        [ObservableProperty] public bool flagGroundToAir;
        [ObservableProperty] public bool flagFinisher;
        [ObservableProperty] public bool flagUnk;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(MotionName))] public ushort motion;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(NextMotionName))] public ushort nextMotion;
        [ObservableProperty] public float jump;
        [ObservableProperty] public float jumpMax;
        [ObservableProperty] public float jumpMin;
        [ObservableProperty] public float speedMin;
        [ObservableProperty] public float speedMax;
        [ObservableProperty] public float near;
        [ObservableProperty] public float far;
        [ObservableProperty] public float low;
        [ObservableProperty] public float high;
        [ObservableProperty] public float innerMin;
        [ObservableProperty] public float innerMax;
        [ObservableProperty] public float blendTime;
        [ObservableProperty] public float distAdjust;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(AbilityName))] public ushort abilityId;
        [ObservableProperty] public ushort score;
        public string MotionName => DataFetcher.GetMotionName((short)Motion);
        public string NextMotionName => DataFetcher.GetMotionName((short)NextMotion);
        public string AbilityName => DataFetcher.GetAbilityName(abilityId);

        public BattlePartyAttacksAttackEntry_Wrapper(PartyAttacksFile.AttackEntry entry)
        {
            id = entry.Id;
            type = entry.Type;
            sub = entry.Sub;
            comboOffset = entry.ComboOffset;
            flagAerial = entry.FlagAerial;
            flagGroundToAir = entry.FlagGroundToAir;
            flagFinisher = entry.FlagFinisher;
            flagUnk = entry.FlagUnk;
            motion = entry.Motion;
            nextMotion = entry.NextMotion;
            jump = entry.Jump;
            jumpMax = entry.JumpMax;
            jumpMin = entry.JumpMin;
            speedMin = entry.SpeedMin;
            speedMax = entry.SpeedMax;
            near = entry.Near;
            far = entry.Far;
            low = entry.Low;
            high = entry.High;
            innerMin = entry.InnerMin;
            innerMax = entry.InnerMax;
            blendTime = entry.BlendTime;
            distAdjust = entry.DistAdjust;
            abilityId = entry.AbilityId;
            score = entry.Score;
        }

        public PartyAttacksFile.AttackEntry ToEntry()
        {
            return new PartyAttacksFile.AttackEntry
            {
                Id = id,
                Type = type,
                Sub = sub,
                ComboOffset = comboOffset,
                FlagAerial = flagAerial,
                FlagGroundToAir = flagGroundToAir,
                FlagFinisher = flagFinisher,
                FlagUnk = flagUnk,
                Motion = motion,
                NextMotion = nextMotion,
                Jump = jump,
                JumpMax = jumpMax,
                JumpMin = jumpMin,
                SpeedMin = speedMin,
                SpeedMax = speedMax,
                Near = near,
                Far = far,
                Low = low,
                High = high,
                InnerMin = innerMin,
                InnerMax = innerMax,
                BlendTime = blendTime,
                DistAdjust = distAdjust,
                AbilityId = abilityId,
                Score = score
            };
        }
    }
}
