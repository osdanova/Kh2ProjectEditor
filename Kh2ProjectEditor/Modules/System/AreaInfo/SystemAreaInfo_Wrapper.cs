using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.System;

namespace Kh2ProjectEditor.Modules.System.AreaInfo
{
    internal partial class SystemAreaInfo_Wrapper : ObservableObject
    {
        [ObservableProperty] public byte world;
        [ObservableProperty] public byte room;
        [ObservableProperty] public bool isKnownArea;
        [ObservableProperty] public bool indoorArea;
        [ObservableProperty] public bool monochrome;
        [ObservableProperty] public bool noShadow;
        [ObservableProperty] public bool hasGlow;
        [ObservableProperty] public int reverb;
        [ObservableProperty] public int backgroundSoundEffect1;
        [ObservableProperty] public int backgroundSoundEffect2;
        [ObservableProperty] public ushort bgmField1;
        [ObservableProperty] public ushort bgmBattle1;
        [ObservableProperty] public ushort bgmField2;
        [ObservableProperty] public ushort bgmBattle2;
        [ObservableProperty] public ushort bgmField3;
        [ObservableProperty] public ushort bgmBattle3;
        [ObservableProperty] public ushort bgmField4;
        [ObservableProperty] public ushort bgmBattle4;
        [ObservableProperty] public ushort bgmField5;
        [ObservableProperty] public ushort bgmBattle5;
        [ObservableProperty] public ushort bgmField6;
        [ObservableProperty] public ushort bgmBattle6;
        [ObservableProperty] public ushort bgmField7;
        [ObservableProperty] public ushort bgmBattle7;
        [ObservableProperty] public ushort bgmField8;
        [ObservableProperty] public ushort bgmBattle8;
        [ObservableProperty] public ushort voice;
        [ObservableProperty] public ushort navigationMapItem;
        [ObservableProperty] public byte command;
        public string RoomName => DataFetcher.GetWorldRoomName(world, room);


        public SystemAreaInfo_Wrapper(AreaInfoFile.AreaInfo entry)
        {
            isKnownArea = entry.IsKnownArea;
            indoorArea = entry.IndoorArea;
            monochrome = entry.Monochrome;
            noShadow = entry.NoShadow;
            hasGlow = entry.HasGlow;
            reverb = entry.Reverb;
            backgroundSoundEffect1 = entry.BackgroundSoundEffect1;
            backgroundSoundEffect2 = entry.BackgroundSoundEffect2;
            bgmField1 = entry.BackgroundMusic[0].BgmField;
            bgmBattle1 = entry.BackgroundMusic[0].BgmBattle;
            bgmField2 = entry.BackgroundMusic[1].BgmField;
            bgmBattle2 = entry.BackgroundMusic[1].BgmBattle;
            bgmField3 = entry.BackgroundMusic[2].BgmField;
            bgmBattle3 = entry.BackgroundMusic[2].BgmBattle;
            bgmField4 = entry.BackgroundMusic[3].BgmField;
            bgmBattle4 = entry.BackgroundMusic[3].BgmBattle;
            bgmField5 = entry.BackgroundMusic[4].BgmField;
            bgmBattle5 = entry.BackgroundMusic[4].BgmBattle;
            bgmField6 = entry.BackgroundMusic[5].BgmField;
            bgmBattle6 = entry.BackgroundMusic[5].BgmBattle;
            bgmField7 = entry.BackgroundMusic[6].BgmField;
            bgmBattle7 = entry.BackgroundMusic[6].BgmBattle;
            bgmField8 = entry.BackgroundMusic[7].BgmField;
            bgmBattle8 = entry.BackgroundMusic[7].BgmBattle;
            voice = entry.Voice;
            navigationMapItem = entry.NavigationMapItem;
            command = entry.Command;
        }

        public AreaInfoFile.AreaInfo ToEntry()
        {
            AreaInfoFile.AreaInfo areaInfo = new AreaInfoFile.AreaInfo
            {
                IsKnownArea = isKnownArea,
                IndoorArea = indoorArea,
                Monochrome = monochrome,
                NoShadow = noShadow,
                HasGlow = hasGlow,
                Reverb = reverb,
                BackgroundSoundEffect1 = backgroundSoundEffect1,
                BackgroundSoundEffect2 = backgroundSoundEffect2,
                Voice = voice,
                NavigationMapItem = navigationMapItem,
                Command = command,
            };

            areaInfo.BackgroundMusic = new AreaInfoFile.BgmSet[8];
            areaInfo.BackgroundMusic[0] = new AreaInfoFile.BgmSet();
            areaInfo.BackgroundMusic[0].BgmField = bgmField1;
            areaInfo.BackgroundMusic[0].BgmBattle = bgmBattle1;
            areaInfo.BackgroundMusic[1] = new AreaInfoFile.BgmSet();
            areaInfo.BackgroundMusic[1].BgmField = bgmField2;
            areaInfo.BackgroundMusic[1].BgmBattle = bgmBattle2;
            areaInfo.BackgroundMusic[2] = new AreaInfoFile.BgmSet();
            areaInfo.BackgroundMusic[2].BgmField = bgmField3;
            areaInfo.BackgroundMusic[2].BgmBattle = bgmBattle3;
            areaInfo.BackgroundMusic[3] = new AreaInfoFile.BgmSet();
            areaInfo.BackgroundMusic[3].BgmField = bgmField4;
            areaInfo.BackgroundMusic[3].BgmBattle = bgmBattle4;
            areaInfo.BackgroundMusic[4] = new AreaInfoFile.BgmSet();
            areaInfo.BackgroundMusic[4].BgmField = bgmField5;
            areaInfo.BackgroundMusic[4].BgmBattle = bgmBattle5;
            areaInfo.BackgroundMusic[5] = new AreaInfoFile.BgmSet();
            areaInfo.BackgroundMusic[5].BgmField = bgmField6;
            areaInfo.BackgroundMusic[5].BgmBattle = bgmBattle6;
            areaInfo.BackgroundMusic[6] = new AreaInfoFile.BgmSet();
            areaInfo.BackgroundMusic[6].BgmField = bgmField7;
            areaInfo.BackgroundMusic[6].BgmBattle = bgmBattle7;
            areaInfo.BackgroundMusic[7] = new AreaInfoFile.BgmSet();
            areaInfo.BackgroundMusic[7].BgmField = bgmField8;
            areaInfo.BackgroundMusic[7].BgmBattle = bgmBattle8;

            return areaInfo;
        }
    }
}
