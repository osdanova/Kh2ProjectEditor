using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.System.Treasures
{
    internal partial class SystemTreasures_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<SystemTreasures_Wrapper> LoadedEntries { get; set; }
        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new World_Converter().Options.Values.ToList();

        public SystemTreasures_DataModel()
        {
            LoadedEntries = new ObservableCollection<SystemTreasures_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.TrsrFile);
        }

        public void LoadData(TreasuresFile treasuresFile)
        {
            LoadedEntries.Clear();
            foreach (TreasuresFile.Entry entry in treasuresFile.Entries)
            {
                LoadedEntries.Add(new SystemTreasures_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.TrsrFile.Entries.Clear();
            foreach (SystemTreasures_Wrapper wrapper in LoadedEntries)
            {
                FileSystem_Service.Instance.TrsrFile.Entries.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.SaveBarFile("trsr");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
