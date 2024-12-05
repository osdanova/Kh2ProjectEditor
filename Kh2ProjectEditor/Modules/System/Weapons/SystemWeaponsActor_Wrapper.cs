using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services.Files;

namespace Kh2ProjectEditor.Modules.System.Weapons
{
    internal partial class SystemWeaponsActor_Wrapper : ObservableObject
    {
        [ObservableProperty] public int id;
        [ObservableProperty] public string rightWeapon;
        [ObservableProperty] public string leftWeapon;
        [ObservableProperty] public int setId;

        public SystemWeaponsActor_Wrapper(int weaponActorId)
        {
            id = weaponActorId;
            RightWeapon = FileSystem_Service.Instance.WmstFile.Entries[weaponActorId].RightWeapon;
            LeftWeapon = FileSystem_Service.Instance.WmstFile.Entries[weaponActorId].LeftWeapon;
            SetId = FileSystem_Service.Instance.WentFile.WeaponActorSetPointers[weaponActorId];
        }
    }
}
