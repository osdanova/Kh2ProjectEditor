using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Mixdata;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.MixData.Recipes
{
    internal class MixDataRecipes_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<MixDataRecipes_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> TypeOptions => new MixDataRecipesType_Converter().Options.Values.ToList();
        public List<string> RankOptions => new MixDataRecipesRank_Converter().Options.Values.ToList();

        public MixDataRecipes_DataModel()
        {
            LoadedEntries = new ObservableCollection<MixDataRecipes_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.MixDataExists)
            {
                return;
            }

            LoadData(FileMixData_Service.Instance.ReciFile);
        }

        public void LoadData(RecipesFile khFile)
        {
            LoadedEntries.Clear();
            foreach (RecipesFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new MixDataRecipes_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileMixData_Service.Instance.ReciFile.Entries.Clear();
            foreach (MixDataRecipes_Wrapper wrapper in LoadedEntries)
            {
                FileMixData_Service.Instance.ReciFile.Entries.Add(wrapper.ToEntry());
            }

            FileMixData_Service.Instance.SaveBarFile("reci");
            FileMixData_Service.Instance.SaveMixDataFile();
            FileMixData_Service.Instance.LoadFromProject();
        }
    }
}
