using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.PartyAttacks
{
    internal partial class BattlePartyAttacks_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattlePartyAttacksEntry_Wrapper> LoadedEntries { get; set; }
        internal ObservableCollection<PartyAttacksFile.AttackSet> LoadedSets { get; set; }
        internal ObservableCollection<BattlePartyAttacksAttackEntry_Wrapper> LoadedSet { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public ObservableCollection<int> SetOptions { get; set; }

        [ObservableProperty] public int selectedSet;
        //[ObservableProperty] public bool showBasic;
        //public List<string> EntryTypeOptions => new BattleAttackParamsType_Converter().Options.Values.ToList();

        public BattlePartyAttacks_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattlePartyAttacksEntry_Wrapper>();
            LoadedSets = new ObservableCollection<PartyAttacksFile.AttackSet>();
            LoadedSet = new ObservableCollection<BattlePartyAttacksAttackEntry_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.PtyaFile);
        }

        public void LoadData(PartyAttacksFile ptyaFile)
        {
            LoadedEntries.Clear();
            foreach (PartyAttacksFile.Entry entry in ptyaFile.Entries)
            {
                LoadedEntries.Add(new BattlePartyAttacksEntry_Wrapper(entry));
            }

            LoadedSets.Clear();
            SetOptions = new ObservableCollection<int>();
            for (int i = 0; i < ptyaFile.AttackSets.Count; i++)
            {
                SetOptions.Add(i);
                LoadedSets.Add(ptyaFile.AttackSets[i]);
            }
            SelectedSet = 0;
            LoadSet();
        }

        public void SaveSet(int setId)
        {
            LoadedSets[setId].AttackEntries.Clear();
            foreach (BattlePartyAttacksAttackEntry_Wrapper wrapper in LoadedSet)
            {
                LoadedSets[setId].AttackEntries.Add(wrapper.ToEntry());
            }
        }

        public void LoadSet()
        {
            LoadedSet.Clear();
            foreach(PartyAttacksFile.AttackEntry entry in LoadedSets[SelectedSet].AttackEntries)
            {
                LoadedSet.Add(new BattlePartyAttacksAttackEntry_Wrapper(entry));
            }
        }

        partial void OnSelectedSetChanged(int oldValue, int newValue)
        {
            SaveSet(oldValue);
            LoadSet();
        }

        public void SaveFile()
        {
            SaveSet(selectedSet);

            FileBattle_Service.Instance.PtyaFile.Entries.Clear();
            foreach (BattlePartyAttacksEntry_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.PtyaFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.PtyaFile.AttackSets.Clear();
            foreach (PartyAttacksFile.AttackSet set in LoadedSets)
            {
                FileBattle_Service.Instance.PtyaFile.AttackSets.Add(set);
            }

            FileBattle_Service.Instance.SaveBarFile("ptya");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
