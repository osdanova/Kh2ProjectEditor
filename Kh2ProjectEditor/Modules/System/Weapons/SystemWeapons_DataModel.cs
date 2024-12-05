using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2;
using KhLib.Kh2.System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Kh2ProjectEditor.Modules.System.Weapons
{
    internal partial class SystemWeapons_DataModel : ObservableObject
    {
        public ObservableCollection<SystemWeaponsActor_Wrapper> LoadedWeaponActors { get; set; }
        public List<List<SystemWeaponsSet_Wrapper>> LoadedWeaponSets {  get; set; }
        
        // Selected weapon set
        public ObservableCollection<SystemWeaponsSet_Wrapper> LoadedWeaponSet { get; set; }

        // Weapon set selector
        public ObservableCollection<int> WeaponSetOptions { get; set; }

        [ObservableProperty] public int selectedWeaponSet;

        public SystemWeapons_DataModel()
        {
            LoadedWeaponActors = new ObservableCollection<SystemWeaponsActor_Wrapper>();
            LoadedWeaponSets = new List<List<SystemWeaponsSet_Wrapper>>();
            LoadedWeaponSet = new ObservableCollection<SystemWeaponsSet_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadWeaponSetOptionsFromFile();
            LoadData(FileSystem_Service.Instance.WentFile, FileSystem_Service.Instance.WmstFile);
        }

        public void LoadData(WeaponEntriesFile wentFile, WeaponMotionSetsFile wmstFile)
        {
            LoadedWeaponActors.Clear();
            for(int i = 0; i < 70; i++)
            {
                LoadedWeaponActors.Add(new SystemWeaponsActor_Wrapper(i));
            }

            LoadedWeaponSets.Clear();
            foreach(var set in wentFile.Sets)
            {
                List<SystemWeaponsSet_Wrapper> weaponSet = new List<SystemWeaponsSet_Wrapper>();
                for (int i = 0; i < set.Entries.Count; i++)
                {
                    weaponSet.Add(new SystemWeaponsSet_Wrapper(i, set.Entries[i]));
                }
                LoadedWeaponSets.Add(weaponSet);
            }

            LoadWeaponSet(0);
        }

        private void LoadWeaponSet(int setId)
        {
            LoadedWeaponSet.Clear();
            foreach(SystemWeaponsSet_Wrapper weaponWrapper in LoadedWeaponSets[setId])
            {
                LoadedWeaponSet.Add(weaponWrapper);
            }
        }

        private void LoadWeaponSetOptionsFromFile()
        {
            WeaponSetOptions = new ObservableCollection<int>();
            for (int i = 0; i < FileSystem_Service.Instance.WentFile.Sets.Count; i++)
            {
                WeaponSetOptions.Add(i);
            }
            SelectedWeaponSet = 0;
        }

        partial void OnSelectedWeaponSetChanged(int oldValue, int newValue)
        {
            LoadedWeaponSet.Clear();
            for (int i = 0; i < FileSystem_Service.Instance.WentFile.Sets[newValue].Entries.Count; i++)
            {
                LoadedWeaponSet.Add(new SystemWeaponsSet_Wrapper(i, FileSystem_Service.Instance.WentFile.Sets[newValue].Entries[i]));
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.WentFile.WeaponActorSetPointers.Clear();
            FileSystem_Service.Instance.WentFile.Sets.Clear();
            FileSystem_Service.Instance.WmstFile.Entries.Clear();

            foreach (SystemWeaponsActor_Wrapper weaponActor in LoadedWeaponActors)
            {
                FileSystem_Service.Instance.WentFile.WeaponActorSetPointers.Add(weaponActor.SetId);
                FileSystem_Service.Instance.WmstFile.Entries.Add(new WeaponMotionSetsFile.Entry { RightWeapon = weaponActor.RightWeapon, LeftWeapon = weaponActor.LeftWeapon });
            }

            foreach(List<SystemWeaponsSet_Wrapper> weaponSet in LoadedWeaponSets)
            {
                List<int> setEntries = new List<int>();
                foreach(SystemWeaponsSet_Wrapper weaponWrapper in weaponSet)
                {
                    setEntries.Add(weaponWrapper.objectId);
                }
                FileSystem_Service.Instance.WentFile.Sets.Add(new WeaponEntriesFile.Set { Entries = setEntries });
            }

            FileSystem_Service.Instance.SaveBarFile("went");
            FileSystem_Service.Instance.SaveBarFile("wmst");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
