using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;

namespace Kh2ProjectEditor.Modules.KhSystem.Weapons
{
    internal partial class SystemWeaponsSet_Wrapper : ObservableObject
    {
        [ObservableProperty] public int id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ObjectDesc))] public int objectId;
        public string ObjectDesc => DataFetcher.GetObjectDescription((uint)objectId);

        public SystemWeaponsSet_Wrapper(int entryId, int entryObjectId)
        {
            Id = entryId;
            ObjectId = entryObjectId;
        }
    }
}
