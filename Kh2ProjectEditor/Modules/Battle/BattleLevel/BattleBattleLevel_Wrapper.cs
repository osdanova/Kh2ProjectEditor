using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.BattleLevel
{
    internal partial class BattleBattleLevel_Wrapper : ObservableObject
    {
        [ObservableProperty] public int id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ProgressFlagDesc))] public int progressFlag;
        [ObservableProperty] public byte world0;
        [ObservableProperty] public byte world1;
        [ObservableProperty] public byte world2;
        [ObservableProperty] public byte world3;
        [ObservableProperty] public byte world4;
        [ObservableProperty] public byte world5;
        [ObservableProperty] public byte world6;
        [ObservableProperty] public byte world7;
        [ObservableProperty] public byte world8;
        [ObservableProperty] public byte world9;
        [ObservableProperty] public byte world10;
        [ObservableProperty] public byte world11;
        [ObservableProperty] public byte world12;
        [ObservableProperty] public byte world13;
        [ObservableProperty] public byte world14;
        [ObservableProperty] public byte world15;
        [ObservableProperty] public byte world16;
        [ObservableProperty] public byte world17;
        [ObservableProperty] public byte world18;
        public string ProgressFlagDesc => DataFetcher.GetProgressFlagDescription((ushort)ProgressFlag);

        public BattleBattleLevel_Wrapper(BattleLevelFile.Entry entry)
        {
            id = entry.Id;
            progressFlag = entry.ProgressFlag;
            world0 = entry.WorldBLs[0];
            world1 = entry.WorldBLs[1];
            world2 = entry.WorldBLs[2];
            world3 = entry.WorldBLs[3];
            world4 = entry.WorldBLs[4];
            world5 = entry.WorldBLs[5];
            world6 = entry.WorldBLs[6];
            world7 = entry.WorldBLs[7];
            world8 = entry.WorldBLs[8];
            world9 = entry.WorldBLs[9];
            world10 = entry.WorldBLs[10];
            world11 = entry.WorldBLs[11];
            world12 = entry.WorldBLs[12];
            world13 = entry.WorldBLs[13];
            world14 = entry.WorldBLs[14];
            world15 = entry.WorldBLs[15];
            world16 = entry.WorldBLs[16];
            world17 = entry.WorldBLs[17];
            world18 = entry.WorldBLs[18];
        }

        public BattleLevelFile.Entry ToEntry()
        {
            BattleLevelFile.Entry entry = new BattleLevelFile.Entry();
            entry.Id = id;
            entry.ProgressFlag = progressFlag;
            entry.WorldBLs[0] = world0;
            entry.WorldBLs[1] = world1;
            entry.WorldBLs[2] = world2;
            entry.WorldBLs[3] = world3;
            entry.WorldBLs[4] = world4;
            entry.WorldBLs[5] = world5;
            entry.WorldBLs[6] = world6;
            entry.WorldBLs[7] = world7;
            entry.WorldBLs[8] = world8;
            entry.WorldBLs[9] = world9;
            entry.WorldBLs[10] = world10;
            entry.WorldBLs[11] = world11;
            entry.WorldBLs[12] = world12;
            entry.WorldBLs[13] = world13;
            entry.WorldBLs[14] = world14;
            entry.WorldBLs[15] = world15;
            entry.WorldBLs[16] = world16;
            entry.WorldBLs[17] = world17;
            entry.WorldBLs[18] = world18;

            return entry;
        }
    }
}
