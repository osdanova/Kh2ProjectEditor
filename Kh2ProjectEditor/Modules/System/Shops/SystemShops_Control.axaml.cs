using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.Shops;

namespace Kh2ProjectEditor;

public partial class SystemShops_Control : UserControl
{
    SystemShops_DataModel dataModel;
    public SystemShops_Control()
    {
        dataModel = new SystemShops_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();

        if(dataModel.LoadedShops.Count > 0)
        {
            InventoriesFrame.Content = new SystemShopsInventories_Control(dataModel.LoadedShops[0].Inventories);
        }
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }

    private void ShopGrid_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        if(ShopGrid.SelectedItem != null)
            InventoriesFrame.Content = new SystemShopsInventories_Control(((SystemShopsShop_Wrapper)ShopGrid.SelectedItem).Inventories);
    }
}