using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.PrizeTable
{
    internal class BattlePrizeTable_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattlePrizeTable_Wrapper> LoadedEntries { get; set; }

        public BattlePrizeTable_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattlePrizeTable_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.PrztFile);
        }

        public void LoadData(PrizeTableFile prztFile)
        {
            LoadedEntries.Clear();
            foreach (PrizeTableFile.Entry entry in prztFile.Entries)
            {
                LoadedEntries.Add(new BattlePrizeTable_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.PrztFile.Entries.Clear();
            foreach (BattlePrizeTable_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.PrztFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("przt");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
