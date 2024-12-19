using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.FormLevels
{
    internal class BattleFormLevels_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleFormLevels_Wrapper> LoadedEntries { get; set; }

        public BattleFormLevels_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattleFormLevels_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.FmlvFile);
        }

        public void LoadData(FormLevelsFile fmlvFile)
        {
            LoadedEntries.Clear();
            foreach (FormLevelsFile.Entry entry in fmlvFile.Entries)
            {
                LoadedEntries.Add(new BattleFormLevels_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.FmlvFile.Entries.Clear();
            foreach (BattleFormLevels_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.FmlvFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("fmlv");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
