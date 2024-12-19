using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.LevelUp
{
    internal partial class BattleLevelUp_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleLevelUpPointer_Wrapper> LoadedPointers { get; set; }
        internal ObservableCollection<LevelUpFile.EntrySet> LoadedSets { get; set; }
        internal ObservableCollection<BattleLevelUpEntry_Wrapper> LoadedSet { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public ObservableCollection<int> SetOptions { get; set; }

        [ObservableProperty] public int selectedSet;
        //[ObservableProperty] public bool showBasic;
        //public List<string> EntryTypeOptions => new BattleAttackParamsType_Converter().Options.Values.ToList();

        public BattleLevelUp_DataModel()
        {
            LoadedPointers = new ObservableCollection<BattleLevelUpPointer_Wrapper>();
            LoadedSets = new ObservableCollection<LevelUpFile.EntrySet>();
            LoadedSet = new ObservableCollection<BattleLevelUpEntry_Wrapper>();
            LoadFromFile();
        }
        
        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }
        
            LoadData(FileBattle_Service.Instance.LvupFile);
        }
        
        public void LoadData(LevelUpFile lvupFile)
        {
            LoadedPointers.Clear();
            foreach (LevelUpFile.EntryPointer pointer in lvupFile.Pointers)
            {
                LoadedPointers.Add(new BattleLevelUpPointer_Wrapper(pointer));
            }
        
            LoadedSets.Clear();
            SetOptions = new ObservableCollection<int>();
            for (int i = 0; i < lvupFile.EntrySets.Count; i++)
            {
                SetOptions.Add(i);
                LoadedSets.Add(lvupFile.EntrySets[i]);
            }
            SelectedSet = 0;
            LoadSet();
        }
        
        public void SaveSet(int setId)
        {
            LoadedSets[setId].Entries.Clear();
            foreach (BattleLevelUpEntry_Wrapper wrapper in LoadedSet)
            {
                LoadedSets[setId].Entries.Add(wrapper.ToEntry());
            }
        }
        
        public void LoadSet()
        {
            LoadedSet.Clear();
            foreach (LevelUpFile.Entry entry in LoadedSets[SelectedSet].Entries)
            {
                LoadedSet.Add(new BattleLevelUpEntry_Wrapper(entry));
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
        
            FileBattle_Service.Instance.LvupFile.Pointers.Clear();
            foreach (BattleLevelUpPointer_Wrapper wrapper in LoadedPointers)
            {
                FileBattle_Service.Instance.LvupFile.Pointers.Add(wrapper.ToEntry());
            }
        
            FileBattle_Service.Instance.LvupFile.EntrySets.Clear();
            foreach (LevelUpFile.EntrySet set in LoadedSets)
            {
                FileBattle_Service.Instance.LvupFile.EntrySets.Add(set);
            }
        
            FileBattle_Service.Instance.SaveBarFile("lvup");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
