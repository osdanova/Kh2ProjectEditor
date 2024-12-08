using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.KhSystem;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.System.Preferences.Party
{
    internal class SystemPrefParty_DataModel
    {
        public ObservableCollection<SystemPrefParty_Wrapper> LoadedEntries { get; set; }
        public List<PrefPartyFile.PartyEntry> LoadedPartyEntries { get; set; }

        public SystemPrefParty_DataModel()
        {
            LoadedEntries = new ObservableCollection<SystemPrefParty_Wrapper>();
            LoadedPartyEntries = new List<PrefPartyFile.PartyEntry>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.PrefPrtyFile);
        }

        public void LoadData(PrefPartyFile prtyFile)
        {
            LoadedEntries.Clear();
            foreach (PrefPartyFile.Entry entry in prtyFile.Entries)
            {
                LoadedEntries.Add(new SystemPrefParty_Wrapper(entry));
            }

            LoadedPartyEntries.Clear();
            foreach (PrefPartyFile.PartyEntry partyEntry in prtyFile.PartyEntries)
            {
                LoadedPartyEntries.Add(partyEntry);
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.PrefPrtyFile.Entries.Clear();
            foreach (SystemPrefParty_Wrapper wrapper in LoadedEntries)
            {
                FileSystem_Service.Instance.PrefPrtyFile.Entries.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.PrefPrtyFile.PartyEntries.Clear();
            foreach (PrefPartyFile.PartyEntry partyEntry in LoadedPartyEntries)
            {
                FileSystem_Service.Instance.PrefPrtyFile.PartyEntries.Add(partyEntry);
            }

            FileSystem_Service.Instance.SaveBarFile("pref", "prty");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
