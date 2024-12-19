using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Jiminy;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Jiminy.Ansem
{
    internal class JiminyAnsemReports_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<JiminyAnsemReports_Wrapper> LoadedEntries { get; set; }

        public JiminyAnsemReports_DataModel()
        {
            LoadedEntries = new ObservableCollection<JiminyAnsemReports_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.JiminyExists)
            {
                return;
            }

            LoadData(FileJiminy_Service.Instance.AnseFile);
        }

        public void LoadData(AnsemReportsFile khFile)
        {
            LoadedEntries.Clear();
            foreach (AnsemReportsFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new JiminyAnsemReports_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileJiminy_Service.Instance.AnseFile.Entries.Clear();
            foreach (JiminyAnsemReports_Wrapper wrapper in LoadedEntries)
            {
                FileJiminy_Service.Instance.AnseFile.Entries.Add(wrapper.ToEntry());
            }

            FileJiminy_Service.Instance.SaveBarFile("anse");
            FileJiminy_Service.Instance.SaveJiminyFile();
            FileJiminy_Service.Instance.LoadFromProject();
        }
    }
}
