using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Jiminy;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Jiminy.Quests
{
    internal class JiminyQuests_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<JiminyQuests_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new JmWorld_Converter().Options.Values.ToList();

        public JiminyQuests_DataModel()
        {
            LoadedEntries = new ObservableCollection<JiminyQuests_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.JiminyExists)
            {
                return;
            }

            LoadData(FileJiminy_Service.Instance.QuesFile);
        }

        public void LoadData(QuestsFile khFile)
        {
            LoadedEntries.Clear();
            foreach (QuestsFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new JiminyQuests_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileJiminy_Service.Instance.QuesFile.Entries.Clear();
            foreach (JiminyQuests_Wrapper wrapper in LoadedEntries)
            {
                FileJiminy_Service.Instance.QuesFile.Entries.Add(wrapper.ToEntry());
            }

            FileJiminy_Service.Instance.SaveBarFile("ques");
            FileJiminy_Service.Instance.SaveJiminyFile();
            FileJiminy_Service.Instance.LoadFromProject();
        }
    }
}
