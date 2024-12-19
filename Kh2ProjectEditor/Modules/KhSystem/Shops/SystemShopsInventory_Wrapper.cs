using CommunityToolkit.Mvvm.ComponentModel;
using KhLib.Kh2.KhSystem;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.KhSystem.Shops
{
    public partial class SystemShopsInventory_Wrapper : ObservableObject
    {
        [ObservableProperty] public short unlockEventId;
        internal ObservableCollection<SystemShopsProduct_Wrapper> Products { get; set; }

        public SystemShopsInventory_Wrapper(ShopsFile.Inventory inventory)
        {
            unlockEventId = inventory.UnlockEventId;
            Products = new ObservableCollection<SystemShopsProduct_Wrapper>();
            foreach(ushort itemId in inventory.ItemIds)
            {
                Products.Add(new SystemShopsProduct_Wrapper(itemId));
            }
        }

        public ShopsFile.Inventory ToEntry()
        {
            ShopsFile.Inventory inventory = new ShopsFile.Inventory
            {
                UnlockEventId = unlockEventId,
                ItemIds = new List<ushort>()
            };

            foreach (SystemShopsProduct_Wrapper product in Products)
            {
                inventory.ItemIds.Add(product.ItemId);
            }

            return inventory;
        }
    }
}
