using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.KhSystem;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.KhSystem.EventParams
{
    internal class SystemEventParams_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<SystemEventParams_Wrapper> LoadedEntries { get; set; }
        /******************************************
         * View settings
         ******************************************/
        public List<string> FadeTypeOptions => new SystemEventParamsFadeType_Converter().Options.Values.ToList();

        public SystemEventParams_DataModel()
        {
            LoadedEntries = new ObservableCollection<SystemEventParams_Wrapper>();
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

        public void LoadData(EventTypeFile evtpFile)
        {
            LoadedEntries.Clear();
            foreach (EventTypeFile.Entry entry in evtpFile.Entries)
            {
                LoadedEntries.Add(new SystemEventParams_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.EvtpFile.Entries.Clear();
            foreach (SystemEventParams_Wrapper wrapper in LoadedEntries)
            {
                FileSystem_Service.Instance.EvtpFile.Entries.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.SaveBarFile("evtp");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
