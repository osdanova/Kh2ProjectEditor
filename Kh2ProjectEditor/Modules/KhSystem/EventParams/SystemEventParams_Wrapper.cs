using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.KhSystem;

namespace Kh2ProjectEditor.Modules.KhSystem.EventParams
{
    internal partial class SystemEventParams_Wrapper : ObservableObject
    {
        [ObservableProperty] public byte id;
        [ObservableProperty] public byte unkBitflag;
        [ObservableProperty] public int unk1;
        [ObservableProperty] public ushort unk2;
        //public string Unk2Desc => DataFetcher.GetProgressFlagDescription(Unk2); // Not in any msg text entries

        public SystemEventParams_Wrapper(EventParamsFile.Entry entry)
        {
            id = entry.Id;
            unkBitflag = entry.UnkBitflag;
            unk1 = entry.Unk1;
            unk2 = entry.Unk2;
        }

        public EventParamsFile.Entry ToEntry()
        {
            return new EventParamsFile.Entry
            {
                Id = id,
                UnkBitflag = unkBitflag,
                Unk1 = unk1,
                Unk2 = unk2
            };
        }
    }
}
