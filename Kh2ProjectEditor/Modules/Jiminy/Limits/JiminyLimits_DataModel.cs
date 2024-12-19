using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Jiminy;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Jiminy.Limits
{
    internal class JiminyLimits_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<JiminyLimits_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new JmWorld_Converter().Options.Values.ToList();

        public JiminyLimits_DataModel()
        {
            LoadedEntries = new ObservableCollection<JiminyLimits_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.JiminyExists)
            {
                return;
            }

            LoadData(FileJiminy_Service.Instance.LimiFile);
        }

        public void LoadData(LimitsFile khFile)
        {
            LoadedEntries.Clear();
            foreach (LimitsFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new JiminyLimits_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileJiminy_Service.Instance.LimiFile.Entries.Clear();
            foreach (JiminyLimits_Wrapper wrapper in LoadedEntries)
            {
                FileJiminy_Service.Instance.LimiFile.Entries.Add(wrapper.ToEntry());
            }

            FileJiminy_Service.Instance.SaveBarFile("limi");
            FileJiminy_Service.Instance.SaveJiminyFile();
            FileJiminy_Service.Instance.LoadFromProject();
        }
    }
}
