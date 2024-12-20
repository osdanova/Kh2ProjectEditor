using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Mixdata;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.MixData.Levels
{
    internal class MixDataLevels_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<MixDataLevels_Wrapper> LoadedEntries { get; set; }

        public MixDataLevels_DataModel()
        {
            LoadedEntries = new ObservableCollection<MixDataLevels_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.MixDataExists)
            {
                return;
            }

            LoadData(FileMixData_Service.Instance.LeveFile);
        }

        public void LoadData(LevelsFile khFile)
        {
            LoadedEntries.Clear();
            foreach (LevelsFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new MixDataLevels_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileMixData_Service.Instance.LeveFile.Entries.Clear();
            foreach (MixDataLevels_Wrapper wrapper in LoadedEntries)
            {
                FileMixData_Service.Instance.LeveFile.Entries.Add(wrapper.ToEntry());
            }

            FileMixData_Service.Instance.SaveBarFile("leve");
            FileMixData_Service.Instance.SaveMixDataFile();
            FileMixData_Service.Instance.LoadFromProject();
        }
    }
}
