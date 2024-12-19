using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.KhSystem;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.System.Preferences.Magic
{
    internal class SystemPrefMagic_DataModel
    {
        public ObservableCollection<PrefMagicFile.Entry> LoadedEntries { get; set; }
        public List<PrefMagicFile.MagicEntry> LoadedMagicEntries { get; set; }

        public SystemPrefMagic_DataModel()
        {
            LoadedEntries = new ObservableCollection<PrefMagicFile.Entry>();
            LoadedMagicEntries = new List<PrefMagicFile.MagicEntry>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.PrefMagiFile);
        }

        public void LoadData(PrefMagicFile magiFile)
        {
            LoadedEntries.Clear();
            foreach (PrefMagicFile.Entry entry in magiFile.Entries)
            {
                LoadedEntries.Add(entry);
            }

            LoadedMagicEntries.Clear();
            foreach (PrefMagicFile.MagicEntry partyEntry in magiFile.MagicEntries)
            {
                LoadedMagicEntries.Add(partyEntry);
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.PrefMagiFile.Entries.Clear();
            foreach (PrefMagicFile.Entry entry in LoadedEntries)
            {
                FileSystem_Service.Instance.PrefMagiFile.Entries.Add(entry);
            }

            FileSystem_Service.Instance.PrefMagiFile.MagicEntries.Clear();
            foreach (PrefMagicFile.MagicEntry partyEntry in LoadedMagicEntries)
            {
                FileSystem_Service.Instance.PrefMagiFile.MagicEntries.Add(partyEntry);
            }

            FileSystem_Service.Instance.SaveBarFile("pref", "magi");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
