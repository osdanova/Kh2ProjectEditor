using CommunityToolkit.Mvvm.ComponentModel;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.Patterns
{
    internal partial class BattlePatterns_Wrapper : ObservableObject
    {
        [ObservableProperty] public byte id;
        [ObservableProperty] public sbyte reaction0;
        [ObservableProperty] public sbyte reaction1;
        [ObservableProperty] public sbyte reaction2;
        [ObservableProperty] public sbyte reaction3;
        [ObservableProperty] public sbyte reaction4;
        [ObservableProperty] public sbyte reaction5;
        [ObservableProperty] public sbyte reaction6;
        [ObservableProperty] public sbyte reaction7;
        [ObservableProperty] public sbyte reaction8;
        [ObservableProperty] public sbyte reaction9;
        [ObservableProperty] public sbyte reaction10;
        [ObservableProperty] public sbyte reaction11;
        [ObservableProperty] public sbyte reaction12;
        [ObservableProperty] public sbyte reaction13;
        [ObservableProperty] public sbyte reaction14;
        [ObservableProperty] public sbyte reaction15;
        [ObservableProperty] public sbyte reaction16;
        [ObservableProperty] public sbyte reaction17;
        [ObservableProperty] public sbyte reaction18;

        public BattlePatterns_Wrapper(PatternsFile.Entry entry)
        {
            id = entry.Id;
            reaction0 = entry.Reactions[0];
            reaction1 = entry.Reactions[1];
            reaction2 = entry.Reactions[2];
            reaction3 = entry.Reactions[3];
            reaction4 = entry.Reactions[4];
            reaction5 = entry.Reactions[5];
            reaction6 = entry.Reactions[6];
            reaction7 = entry.Reactions[7];
            reaction8 = entry.Reactions[8];
            reaction9 = entry.Reactions[9];
            reaction10 = entry.Reactions[10];
            reaction11 = entry.Reactions[11];
            reaction12 = entry.Reactions[12];
            reaction13 = entry.Reactions[13];
            reaction14 = entry.Reactions[14];
            reaction15 = entry.Reactions[15];
            reaction16 = entry.Reactions[16];
            reaction17 = entry.Reactions[17];
            reaction18 = entry.Reactions[18];
        }

        public PatternsFile.Entry ToEntry()
        {
            PatternsFile.Entry entry = new PatternsFile.Entry();
            entry.Id = id;
            entry.Reactions[0] = reaction0;
            entry.Reactions[1] = reaction1;
            entry.Reactions[2] = reaction2;
            entry.Reactions[3] = reaction3;
            entry.Reactions[4] = reaction4;
            entry.Reactions[5] = reaction5;
            entry.Reactions[6] = reaction6;
            entry.Reactions[7] = reaction7;
            entry.Reactions[8] = reaction8;
            entry.Reactions[9] = reaction9;
            entry.Reactions[10] = reaction10;
            entry.Reactions[11] = reaction11;
            entry.Reactions[12] = reaction12;
            entry.Reactions[13] = reaction13;
            entry.Reactions[14] = reaction14;
            entry.Reactions[15] = reaction15;
            entry.Reactions[16] = reaction16;
            entry.Reactions[17] = reaction17;
            entry.Reactions[18] = reaction18;
            return entry;
        }
    }
}
