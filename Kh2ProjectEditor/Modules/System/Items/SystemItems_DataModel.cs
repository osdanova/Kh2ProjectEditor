using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.KhSystem;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.KhSystem.Items
{
    internal partial class SystemItems_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<SystemItemsItem_Wrapper> LoadedItems { get; set; }
        internal ObservableCollection<SystemItemsItem_Wrapper> DisplayedItems { get; set; }
        internal ObservableCollection<SystemItemsParam_Wrapper> LoadedParams { get; set; }
        /******************************************
         * View settings
         ******************************************/
        [ObservableProperty] public bool showAbility;
        [ObservableProperty] public bool showConsumable;
        [ObservableProperty] public bool showEquipment;
        [ObservableProperty] public bool showMagic;
        [ObservableProperty] public bool showSynthesis;
        [ObservableProperty] public bool showReport;
        [ObservableProperty] public bool showWeapon;
        [ObservableProperty] public bool showMap;
        [ObservableProperty] public string filterText;

        public List<string> ItemTypeOptions => new SystemItemsType_Converter().Options.Values.ToList();
        public List<string> ItemRankOptions => new SystemItemsRank_Converter().Options.Values.ToList();
        public List<string> ItemAbilityTypeOptions => new SystemItemsAbilityType_Converter().Options.Values.ToList();
        public List<string> ItemPrizeboxOptions => new SystemItemsPrizebox_Converter().Options.Values.ToList();
        public List<string> WorldOptions => new World_Converter().Options.Values.ToList();

        public SystemItems_DataModel()
        {
            LoadedItems = new ObservableCollection<SystemItemsItem_Wrapper>();
            DisplayedItems = new ObservableCollection<SystemItemsItem_Wrapper>();
            LoadedParams = new ObservableCollection<SystemItemsParam_Wrapper>();
            ShowConsumable = true;
            LoadFromFile();
            ApplyFilters();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.ItemFile);
        }

        public void LoadData(ItemsFile itemFile)
        {
            LoadedItems.Clear();
            foreach (ItemsFile.Entry entry in itemFile.Items)
            {
                LoadedItems.Add(new SystemItemsItem_Wrapper(entry));
            }

            LoadedParams.Clear();
            foreach (ItemsFile.Param param in itemFile.Params)
            {
                LoadedParams.Add(new SystemItemsParam_Wrapper(param));
            }
        }

        public void ApplyFilters()
        {
            DisplayedItems.Clear();
            foreach (SystemItemsItem_Wrapper entry in LoadedItems)
            {
                if (FilterText == null ||
                   FilterText == "" ||
                   entry.Id.ToString().Contains(FilterText) ||
                   entry.Name.ToString().ToLower().Contains(FilterText.ToLower()) ||
                   entry.Description.ToString().ToLower().Contains(FilterText.ToLower()))
                {
                    DisplayedItems.Add(entry);
                }
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.ItemFile.Items.Clear();
            foreach (SystemItemsItem_Wrapper wrapper in LoadedItems)
            {
                FileSystem_Service.Instance.ItemFile.Items.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.ItemFile.Params.Clear();
            foreach (SystemItemsParam_Wrapper wrapper in LoadedParams)
            {
                FileSystem_Service.Instance.ItemFile.Params.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.SaveBarFile("item");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
