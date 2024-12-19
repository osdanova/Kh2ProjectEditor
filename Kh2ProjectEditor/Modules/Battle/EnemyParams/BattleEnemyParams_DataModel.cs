using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.EnemyParams
{
    internal class BattleEnemyParams_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleEnemyParams_Wrapper> LoadedEntries { get; set; }

        public BattleEnemyParams_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattleEnemyParams_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.EnmpFile);
        }

        public void LoadData(EnemyParamsFile prztFile)
        {
            LoadedEntries.Clear();
            foreach (EnemyParamsFile.Entry entry in prztFile.Entries)
            {
                LoadedEntries.Add(new BattleEnemyParams_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.EnmpFile.Entries.Clear();
            foreach (BattleEnemyParams_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.EnmpFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("enmp");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
