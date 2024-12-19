using CommunityToolkit.Mvvm.ComponentModel;
using KhLib.Kh2.KhSystem;
using System;

namespace Kh2ProjectEditor.Modules.KhSystem.Preferences.FormAbilities
{
    internal partial class SystemPrefFormAbilitiesEntry_Wrapper : ObservableObject
    {
        [ObservableProperty] public string level;
        [ObservableProperty] public float highJumpHeight;
        [ObservableProperty] public float airDodgeHeight;
        [ObservableProperty] public float airDodgeSpeed;
        [ObservableProperty] public float airSlideTime;
        [ObservableProperty] public float airSlideSpeed;
        [ObservableProperty] public float airSlideBrake;
        [ObservableProperty] public float airSlideStopBrake;
        [ObservableProperty] public float airSlideStarTime;
        [ObservableProperty] public float glideSpeed;
        [ObservableProperty] public float glideFallRatio;
        [ObservableProperty] public float glideFallHeight;
        [ObservableProperty] public float glideFallMax;
        [ObservableProperty] public float glideAccel;
        [ObservableProperty] public float glideStartHeight;
        [ObservableProperty] public float glideEndHeight;
        [ObservableProperty] public float glideTurnSpeed;
        [ObservableProperty] public float dodgeRollStarTime;

        public SystemPrefFormAbilitiesEntry_Wrapper(PrefFormAbilitiesFile.Entry entry, int abiLevel)
        {
            highJumpHeight = entry.HighJumpHeight;
            airDodgeHeight = entry.AirDodgeHeight;
            airDodgeSpeed = entry.AirDodgeSpeed;
            airSlideTime = entry.AirSlideTime;
            airSlideSpeed = entry.AirSlideSpeed;
            airSlideBrake = entry.AirSlideBrake;
            airSlideStopBrake = entry.AirSlideStopBrake;
            airSlideStarTime = entry.AirSlideStarTime;
            glideSpeed = entry.GlideSpeed;
            glideFallRatio = entry.GlideFallRatio;
            glideFallHeight = entry.GlideFallHeight;
            glideFallMax = entry.GlideFallMax;
            glideAccel = entry.GlideAccel;
            glideStartHeight = entry.GlideStartHeight;
            glideEndHeight = entry.GlideEndHeight;
            glideTurnSpeed = entry.GlideTurnSpeed;
            dodgeRollStarTime = entry.DodgeRollStarTime;

            switch (abiLevel)
            {
                case 0:
                    level = "1";
                    break;
                case 1:
                    level = "2";
                    break;
                case 2:
                    level = "3";
                    break;
                case 3:
                    level = "MAX";
                    break;
                case 4:
                    level = "Dragon Xemnas";
                    break;
                default:
                    throw new Exception("Given ability level shouldn't exist");
            }
        }

        public PrefFormAbilitiesFile.Entry ToEntry()
        {
            return new PrefFormAbilitiesFile.Entry
            {
                HighJumpHeight = highJumpHeight,
                AirDodgeHeight = airDodgeHeight,
                AirDodgeSpeed = airDodgeSpeed,
                AirSlideTime = airSlideTime,
                AirSlideSpeed = airSlideSpeed,
                AirSlideBrake = airSlideBrake,
                AirSlideStopBrake = airSlideStopBrake,
                AirSlideStarTime = airSlideStarTime,
                GlideSpeed = glideSpeed,
                GlideFallRatio = glideFallRatio,
                GlideFallHeight = glideFallHeight,
                GlideFallMax = glideFallMax,
                GlideAccel = glideAccel,
                GlideStartHeight = glideStartHeight,
                GlideEndHeight = glideEndHeight,
                GlideTurnSpeed = glideTurnSpeed,
                DodgeRollStarTime = dodgeRollStarTime,
            };
        }

    }
}
