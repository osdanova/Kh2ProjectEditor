using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.Patterns
{
    internal class BattlePatterns_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattlePatterns_Wrapper> LoadedEntries { get; set; }

        public BattlePatterns_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattlePatterns_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.PatnFile);
        }

        public void LoadData(PatternsFile patnFile)
        {
            LoadedEntries.Clear();
            foreach (PatternsFile.Entry entry in patnFile.Entries)
            {
                LoadedEntries.Add(new BattlePatterns_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.PatnFile.Entries.Clear();
            foreach (BattlePatterns_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.PatnFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("patn");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
