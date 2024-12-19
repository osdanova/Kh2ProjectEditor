using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.PrizeTable
{
    internal partial class BattlePrizeTable_Wrapper : ObservableObject
    {
        [ObservableProperty] public ushort id;
        [ObservableProperty] public byte hpS;
        [ObservableProperty] public byte hpL;
        [ObservableProperty] public byte munnyL;
        [ObservableProperty] public byte munnyM;
        [ObservableProperty] public byte munnyS;
        [ObservableProperty] public byte mpS;
        [ObservableProperty] public byte mpL;
        [ObservableProperty] public byte driveS;
        [ObservableProperty] public byte driveL;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Drop1Name))] public ushort drop1Id;
        [ObservableProperty] public ushort drop1Chance;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Drop2Name))] public ushort drop2Id;
        [ObservableProperty] public ushort drop2Chance;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Drop3Name))] public ushort drop3Id;
        [ObservableProperty] public ushort drop3Chance;
        public string Drop1Name => DataFetcher.GetItemName(drop1Id);
        public string Drop2Name => DataFetcher.GetItemName(drop2Id);
        public string Drop3Name => DataFetcher.GetItemName(drop3Id);

        public BattlePrizeTable_Wrapper(PrizeTableFile.Entry entry)
        {
            id = entry.Id;
            hpS = entry.HpS;
            hpL = entry.HpL;
            munnyL = entry.MunnyL;
            munnyM = entry.MunnyM;
            munnyS = entry.MunnyS;
            mpS = entry.MpS;
            mpL = entry.MpL;
            driveS = entry.DriveS;
            driveL = entry.DriveL;
            drop1Id = entry.Drop1Id;
            drop1Chance = entry.Drop1Chance;
            drop2Id = entry.Drop2Id;
            drop2Chance = entry.Drop2Chance;
            drop3Id = entry.Drop3Id;
            drop3Chance = entry.Drop3Chance;
        }

        public PrizeTableFile.Entry ToEntry()
        {
            return new PrizeTableFile.Entry
            {
                Id = id,
                HpS = hpS,
                HpL = hpL,
                MunnyL = munnyL,
                MunnyM = munnyM,
                MunnyS = munnyS,
                MpS = mpS,
                MpL = mpL,
                DriveS = driveS,
                DriveL = driveL,
                Drop1Id = drop1Id,
                Drop1Chance = drop1Chance,
                Drop2Id = drop2Id,
                Drop2Chance = drop2Chance,
                Drop3Id = drop3Id,
                Drop3Chance = drop3Chance
            };
        }
    }
}
