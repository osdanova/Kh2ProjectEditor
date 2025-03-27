using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Progress;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Progress.DisableArea
{
    internal class ProgressDisableArea_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<ProgressDisableArea_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new World_Converter().Options.Values.ToList();
        public ProgressDisableArea_DataModel()
        {
            LoadedEntries = new ObservableCollection<ProgressDisableArea_Wrapper>();
            LoadFromFile();
        }
        public void LoadFromFile()
        {
            if (!ProjectService.Instance.ProgressExists)
            {
                return;
            }

            DisableAreaFile dsa = FileProgress_Service.Instance.DsaFile;

            LoadData(FileProgress_Service.Instance.DsaFile);
        }

        public void LoadData(DisableAreaFile thisFile)
        {
            LoadedEntries.Clear();
            for(int i = 0; i < thisFile.Entries.Count; i++)
            {
                ProgressDisableArea_Wrapper wrapper = ProgressDisableArea_Wrapper.Wrap(thisFile.Entries[i]);
                wrapper.Identifier = i;
                LoadedEntries.Add(wrapper);
            }
        }

        public void AddEntry()
        {
            LoadedEntries.Add(new ProgressDisableArea_Wrapper());
        }
        public void RemoveEntry(int entryIndex)
        {
            LoadedEntries.RemoveAt(entryIndex);
        }

        public void SaveFile()
        {
            FileProgress_Service.Instance.DsaFile.Entries.Clear();
            foreach (ProgressDisableArea_Wrapper wrapper in LoadedEntries)
            {
                FileProgress_Service.Instance.DsaFile.Entries.Add(wrapper.Unwrap());
            }

            FileProgress_Service.Instance.SaveBarFile("dsa\0");
            FileProgress_Service.Instance.SaveFile();
            FileProgress_Service.Instance.LoadFromProject();
        }
    }
}
