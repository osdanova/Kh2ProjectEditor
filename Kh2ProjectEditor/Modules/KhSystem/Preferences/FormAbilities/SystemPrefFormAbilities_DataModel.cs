using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.KhSystem;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.KhSystem.Preferences.FormAbilities
{
    internal partial class SystemPrefFormAbilities_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<SystemPrefFormAbilitiesEntry_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        [ObservableProperty] public bool showHighJump;
        [ObservableProperty] public bool showAirDodge;
        [ObservableProperty] public bool showAirSlide;
        [ObservableProperty] public bool showGlide;
        [ObservableProperty] public bool showDodgeRoll;

        public SystemPrefFormAbilities_DataModel()
        {
            ShowHighJump = true;
            LoadedEntries = new ObservableCollection<SystemPrefFormAbilitiesEntry_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.PrefFmabFile);
        }

        public void LoadData(PrefFormAbilitiesFile file)
        {
            LoadedEntries.Clear();
            for(int i = 0; i < file.Entries.Count; i++)
            {
                LoadedEntries.Add(new SystemPrefFormAbilitiesEntry_Wrapper(file.Entries[i], i));
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.PrefFmabFile.Entries.Clear();
            foreach (SystemPrefFormAbilitiesEntry_Wrapper wrapper in LoadedEntries)
            {
                FileSystem_Service.Instance.PrefFmabFile.Entries.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.SaveBarFile("pref","fmab");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
