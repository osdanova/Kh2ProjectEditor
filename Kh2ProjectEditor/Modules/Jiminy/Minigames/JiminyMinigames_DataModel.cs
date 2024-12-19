using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Jiminy;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Jiminy.Minigames
{
    internal class JiminyMinigames_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<JiminyMinigames_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new JmWorld_Converter().Options.Values.ToList();

        public JiminyMinigames_DataModel()
        {
            LoadedEntries = new ObservableCollection<JiminyMinigames_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.JiminyExists)
            {
                return;
            }

            LoadData(FileJiminy_Service.Instance.MiniFile);
        }

        public void LoadData(MinigamesFile khFile)
        {
            LoadedEntries.Clear();
            foreach (MinigamesFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new JiminyMinigames_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileJiminy_Service.Instance.MiniFile.Entries.Clear();
            foreach (JiminyMinigames_Wrapper wrapper in LoadedEntries)
            {
                FileJiminy_Service.Instance.MiniFile.Entries.Add(wrapper.ToEntry());
            }

            FileJiminy_Service.Instance.SaveBarFile("mini");
            FileJiminy_Service.Instance.SaveJiminyFile();
            FileJiminy_Service.Instance.LoadFromProject();
        }
    }
}
