using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;

namespace Kh2ProjectEditor.Modules.System.Shops
{
    public partial class SystemShopsProduct_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ItemName))] public ushort itemId;
        public string ItemName => DataFetcher.GetItemName(ItemId);

        public SystemShopsProduct_Wrapper(ushort itemId)
        {
            ItemId = itemId;
        }
    }
}
