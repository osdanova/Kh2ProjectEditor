using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.Progress;

namespace Kh2ProjectEditor.Modules.Progress.DisableArea
{
    public partial class ProgressDisableArea_Wrapper : ObservableObject
    {
        public int Identifier { get; set; }
        [ObservableProperty][NotifyPropertyChangedFor(nameof(AreaName))] public World_Enum worldId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(AreaName))] public byte areaId;
        public string AreaName => DataFetcher.GetWorldRoomName((byte)WorldId, AreaId);

        public static ProgressDisableArea_Wrapper Wrap(DisableAreaFile.Entry entry)
        {
            ProgressDisableArea_Wrapper wrapper = new ProgressDisableArea_Wrapper();
            Property_Util.CopyProperties(entry, wrapper);
            return wrapper;
        }
        public DisableAreaFile.Entry Unwrap()
        {
            DisableAreaFile.Entry entry = new DisableAreaFile.Entry();
            Property_Util.CopyProperties(this, entry);
            return entry;
        }
    }
}
