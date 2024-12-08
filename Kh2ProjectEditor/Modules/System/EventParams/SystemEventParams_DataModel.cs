using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.KhSystem;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.KhSystem.EventParams
{
    internal class SystemEventParams_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<EventParamsFile.Entry> LoadedEntries { get; set; }
        /******************************************
         * View settings
         ******************************************/
        //public List<string> WorldOptions => new World_Converter().Options.Values.ToList();

        public SystemEventParams_DataModel()
        {
            LoadedEntries = new ObservableCollection<EventParamsFile.Entry>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.EvtpFile);
        }

        public void LoadData(EventParamsFile evtpFile)
        {
            LoadedEntries.Clear();
            foreach (EventParamsFile.Entry entry in evtpFile.Entries)
            {
                LoadedEntries.Add(entry);
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.EvtpFile.Entries.Clear();
            foreach (EventParamsFile.Entry entry in LoadedEntries)
            {
                FileSystem_Service.Instance.EvtpFile.Entries.Add(entry);
            }

            FileSystem_Service.Instance.SaveBarFile("evtp");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
