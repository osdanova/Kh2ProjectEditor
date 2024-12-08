using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.KhSystem;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static KhLib.Kh2.KhSystem.ShopsFile;

namespace Kh2ProjectEditor.Modules.KhSystem.Shops
{
    internal partial class SystemShopsShop_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(SignalName))] public ushort gameSignalId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(MenuFlagName))] public ushort menuFlagId;
        [ObservableProperty] public ushort nameId;
        [ObservableProperty] public ushort shopkeeperObjectId;
        [ObservableProperty] public ushort posX;
        [ObservableProperty] public ushort posY;
        [ObservableProperty] public ushort posZ;
        [ObservableProperty] public bool sellsWeapons;
        [ObservableProperty] public bool sellsArmors;
        [ObservableProperty] public bool sellsAccessories;
        [ObservableProperty] public bool sellsItems;
        [ObservableProperty] public bool sellsMaterials;
        [ObservableProperty] public bool isSpecialtyShop;
        [ObservableProperty] public bool isShop;
        [ObservableProperty] public bool isMoogleWorkshop;
        [ObservableProperty] public ushort inventoryCount;
        [ObservableProperty] public byte shopId;
        [ObservableProperty] public byte allItemCount;
        public string ObjectDesc => DataFetcher.GetObjectDescription((uint)shopkeeperObjectId);
        public string Name => MessageService.Instance.GetEntryText(NameId);
        public string SignalName => DataFetcher.GetSignalName((byte)gameSignalId);
        public string MenuFlagName => DataFetcher.GetMenuFlagName((byte)menuFlagId);

        public ObservableCollection<SystemShopsInventory_Wrapper> Inventories { get; set; }

        public SystemShopsShop_Wrapper(ShopsFile.Shop shop)
        {
            gameSignalId = shop.GameSignalId;
            menuFlagId = shop.MenuFlagId;
            nameId = shop.NameId;
            shopkeeperObjectId = shop.ShopkeeperObjectId;
            posX = shop.PosX;
            posY = shop.PosY;
            posZ = shop.PosZ;
            sellsWeapons = shop.SellsWeapons;
            sellsArmors = shop.SellsArmors;
            sellsAccessories = shop.SellsAccessories;
            sellsItems = shop.SellsItems;
            sellsMaterials = shop.SellsMaterials;
            isSpecialtyShop = shop.IsSpecialtyShop;
            isShop = shop.IsShop;
            isMoogleWorkshop = shop.IsMoogleWorkshop;
            shopId = shop.ShopId;

            Inventories = new ObservableCollection<SystemShopsInventory_Wrapper>();
            foreach(ShopsFile.Inventory inventory in shop.Inventories)
            {
                Inventories.Add(new SystemShopsInventory_Wrapper(inventory));
            }
        }
        public ShopsFile.Shop ToEntry()
        {
            ShopsFile.Shop shop = new ShopsFile.Shop
            {
                GameSignalId = gameSignalId,
                MenuFlagId = menuFlagId,
                NameId = nameId,
                ShopkeeperObjectId = shopkeeperObjectId,
                PosX = posX,
                PosY = posY,
                PosZ = posZ,
                SellsWeapons = sellsWeapons,
                SellsArmors = sellsArmors,
                SellsAccessories = sellsAccessories,
                SellsItems = sellsItems,
                SellsMaterials = sellsMaterials,
                IsSpecialtyShop = isSpecialtyShop,
                IsShop = isShop,
                IsMoogleWorkshop = isMoogleWorkshop,
                ShopId = shopId,
                Inventories = new List<Inventory>()
            };

            foreach (SystemShopsInventory_Wrapper inventory in Inventories)
            {
                shop.Inventories.Add(inventory.ToEntry());
            }

            return shop;
        }
    }
}
