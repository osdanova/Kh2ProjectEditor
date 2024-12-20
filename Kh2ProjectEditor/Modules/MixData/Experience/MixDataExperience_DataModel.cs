using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Mixdata;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.MixData.Experience
{
    internal class MixDataExperience_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<MixDataExperience_Wrapper> LoadedEntries { get; set; }

        public MixDataExperience_DataModel()
        {
            LoadedEntries = new ObservableCollection<MixDataExperience_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.MixDataExists)
            {
                return;
            }

            LoadData(FileMixData_Service.Instance.ExpFile);
        }

        public void LoadData(ExperienceFile khFile)
        {
            LoadedEntries.Clear();
            foreach (ExperienceFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new MixDataExperience_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileMixData_Service.Instance.ExpFile.Entries.Clear();
            foreach (MixDataExperience_Wrapper wrapper in LoadedEntries)
            {
                FileMixData_Service.Instance.ExpFile.Entries.Add(wrapper.ToEntry());
            }

            FileMixData_Service.Instance.SaveBarFile("exp\0");
            FileMixData_Service.Instance.SaveMixDataFile();
            FileMixData_Service.Instance.LoadFromProject();
        }
    }
}
