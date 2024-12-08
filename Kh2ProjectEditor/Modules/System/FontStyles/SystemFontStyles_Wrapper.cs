using CommunityToolkit.Mvvm.ComponentModel;
using KhLib.Kh2.KhSystem;

namespace Kh2ProjectEditor.Modules.KhSystem.FontStyles
{
    internal partial class SystemFontStyles_Wrapper : ObservableObject
    {
        [ObservableProperty] public int id;
        [ObservableProperty] public uint color1;
        [ObservableProperty] public uint color2;
        [ObservableProperty] public uint color3;
        [ObservableProperty] public uint color4;
        [ObservableProperty] public uint color5;
        [ObservableProperty] public uint color6;
        [ObservableProperty] public uint color7;
        [ObservableProperty] public uint color8;
        [ObservableProperty] public uint color9;
        [ObservableProperty] public uint color10;
        [ObservableProperty] public uint color11;
        [ObservableProperty] public uint color12;
        [ObservableProperty] public uint color13;
        [ObservableProperty] public uint color14;
        [ObservableProperty] public uint color15;
        [ObservableProperty] public uint color16;
        [ObservableProperty] public uint color17;
        [ObservableProperty] public uint color18;
        [ObservableProperty] public uint color19;

        public SystemFontStyles_Wrapper(FontStyleFile.Entry entry)
        {
            id = entry.Id;
            color1 = entry.Colors[0];
            color2 = entry.Colors[1];
            color3 = entry.Colors[2];
            color4 = entry.Colors[3];
            color5 = entry.Colors[4];
            color6 = entry.Colors[5];
            color7 = entry.Colors[6];
            color8 = entry.Colors[7];
            color9 = entry.Colors[8];
            color10 = entry.Colors[9];
            color11 = entry.Colors[10];
            color12 = entry.Colors[11];
            color13 = entry.Colors[12];
            color14 = entry.Colors[13];
            color15 = entry.Colors[14];
            color16 = entry.Colors[15];
            color17 = entry.Colors[16];
            color18 = entry.Colors[17];
            color19 = entry.Colors[18];
        }

        public FontStyleFile.Entry ToEntry()
        {
            FontStyleFile.Entry entry = new FontStyleFile.Entry
            {
                Id = id,
                Colors = new uint[19]
            };
            entry.Colors[0] = color1;
            entry.Colors[1] = color2;
            entry.Colors[2] = color3;
            entry.Colors[3] = color4;
            entry.Colors[4] = color5;
            entry.Colors[5] = color6;
            entry.Colors[6] = color7;
            entry.Colors[7] = color8;
            entry.Colors[8] = color9;
            entry.Colors[9] = color10;
            entry.Colors[10] = color11;
            entry.Colors[11] = color12;
            entry.Colors[12] = color13;
            entry.Colors[13] = color14;
            entry.Colors[14] = color15;
            entry.Colors[15] = color16;
            entry.Colors[16] = color17;
            entry.Colors[17] = color18;
            entry.Colors[18] = color19;

            return entry;
        }
    }
}
