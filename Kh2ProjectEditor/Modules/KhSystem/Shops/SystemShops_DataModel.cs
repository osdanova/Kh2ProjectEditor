using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.KhSystem;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.KhSystem.Shops
{
    internal partial class SystemShops_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        public ObservableCollection<SystemShopsShop_Wrapper> LoadedShops { get; set; }

        /******************************************
         * View settings
         ******************************************/
        [ObservableProperty] public bool showGameFlags;
        [ObservableProperty] public bool showObject;
        [ObservableProperty] public bool showType;
        [ObservableProperty] public bool showProducts;

        public SystemShops_DataModel()
        {
            LoadedShops = new ObservableCollection<SystemShopsShop_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.ShopFile);
        }

        public void LoadData(ShopsFile shopsFile)
        {
            LoadedShops = new ObservableCollection<SystemShopsShop_Wrapper>();
            foreach (ShopsFile.Shop shop in shopsFile.Shops)
            {
                LoadedShops.Add(new SystemShopsShop_Wrapper(shop));
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.ShopFile.Shops.Clear();
            foreach (SystemShopsShop_Wrapper wrapper in LoadedShops)
            {
                FileSystem_Service.Instance.ShopFile.Shops.Add(wrapper.ToEntry());
            }
        
            FileSystem_Service.Instance.SaveBarFile("shop");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
