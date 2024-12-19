using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.KhSystem;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.KhSystem.Preferences.Player
{
    internal class SystemPrefPlayer_DataModel
    {
        public ObservableCollection<SystemPrefPlayerEntry_Wrapper> LoadedEntries { get; set; }
        public List<PrefPlayerFile.PlayerPreference> LoadedPreferences { get; set; }

        public SystemPrefPlayer_DataModel()
        {
            LoadedEntries = new ObservableCollection<SystemPrefPlayerEntry_Wrapper>();
            LoadedPreferences = new List<PrefPlayerFile.PlayerPreference>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.PrefPlyrFile);
        }

        public void LoadData(PrefPlayerFile plyrFile)
        {
            LoadedEntries.Clear();
            foreach(PrefPlayerFile.Entry entry in plyrFile.Entries)
            {
                LoadedEntries.Add(new SystemPrefPlayerEntry_Wrapper(entry));
            }

            LoadedPreferences.Clear();
            foreach (PrefPlayerFile.PlayerPreference preference in plyrFile.Preferences)
            {
                LoadedPreferences.Add(preference);
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.PrefPlyrFile.Entries.Clear();
            foreach (SystemPrefPlayerEntry_Wrapper wrapper in LoadedEntries)
            {
                FileSystem_Service.Instance.PrefPlyrFile.Entries.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.PrefPlyrFile.Preferences.Clear();
            foreach (PrefPlayerFile.PlayerPreference preference in LoadedPreferences)
            {
                FileSystem_Service.Instance.PrefPlyrFile.Preferences.Add(preference);
            }
            
            FileSystem_Service.Instance.SaveBarFile("pref","plyr");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
