using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Mixdata;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.MixData.Conditions
{
    internal class MixDataConditions_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<MixDataConditions_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> RewardTypeOptions => new MixDataConditionsRewardType_Converter().Options.Values.ToList();
        public List<string> CountTypeOptions => new MixDataConditionsCountType_Converter().Options.Values.ToList();

        public MixDataConditions_DataModel()
        {
            LoadedEntries = new ObservableCollection<MixDataConditions_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.MixDataExists)
            {
                return;
            }

            LoadData(FileMixData_Service.Instance.CondFile);
        }

        public void LoadData(ConditionsFile khFile)
        {
            LoadedEntries.Clear();
            foreach (ConditionsFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new MixDataConditions_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileMixData_Service.Instance.CondFile.Entries.Clear();
            foreach (MixDataConditions_Wrapper wrapper in LoadedEntries)
            {
                FileMixData_Service.Instance.CondFile.Entries.Add(wrapper.ToEntry());
            }

            FileMixData_Service.Instance.SaveBarFile("cond");
            FileMixData_Service.Instance.SaveMixDataFile();
            FileMixData_Service.Instance.LoadFromProject();
        }
    }
}
