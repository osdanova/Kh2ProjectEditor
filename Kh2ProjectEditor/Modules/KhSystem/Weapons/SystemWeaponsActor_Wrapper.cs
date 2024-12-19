using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services.Files;
using Kh2ProjectEditor.Utils;

namespace Kh2ProjectEditor.Modules.KhSystem.Weapons
{
    internal partial class SystemWeaponsActor_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(PlayerName))] public int id;
        [ObservableProperty] public string rightWeapon;
        [ObservableProperty] public string leftWeapon;
        [ObservableProperty] public int setId;
        public string PlayerName => DataFetcher.GetPlayerName((ushort)id);

        public SystemWeaponsActor_Wrapper(int weaponActorId)
        {
            id = weaponActorId;
            RightWeapon = FileSystem_Service.Instance.WmstFile.Entries[weaponActorId].RightWeapon;
            LeftWeapon = FileSystem_Service.Instance.WmstFile.Entries[weaponActorId].LeftWeapon;
            SetId = FileSystem_Service.Instance.WentFile.WeaponActorSetPointers[weaponActorId];
        }
    }
}
