using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Jiminy;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Jiminy.Worlds
{
    internal class JiminyWorlds_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<JiminyWorlds_Wrapper> LoadedEntries { get; set; }

        public JiminyWorlds_DataModel()
        {
            LoadedEntries = new ObservableCollection<JiminyWorlds_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.JiminyExists)
            {
                return;
            }

            LoadData(FileJiminy_Service.Instance.WorlFile);
        }

        public void LoadData(WorldsFile khFile)
        {
            LoadedEntries.Clear();
            foreach (WorldsFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new JiminyWorlds_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileJiminy_Service.Instance.WorlFile.Entries.Clear();
            foreach (JiminyWorlds_Wrapper wrapper in LoadedEntries)
            {
                FileJiminy_Service.Instance.WorlFile.Entries.Add(wrapper.ToEntry());
            }

            FileJiminy_Service.Instance.SaveBarFile("worl");
            FileJiminy_Service.Instance.SaveJiminyFile();
            FileJiminy_Service.Instance.LoadFromProject();
        }
    }
}
