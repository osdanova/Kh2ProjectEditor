using Avalonia.Controls;
using Kh2ProjectEditor.Modules.System.Shops;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor;

public partial class SystemShopsInventories_Control : UserControl
{
    public ObservableCollection<SystemShopsInventory_Wrapper> LoadedInventories { get; set; }
    public SystemShopsInventories_Control(ObservableCollection<SystemShopsInventory_Wrapper> inventories)
    {
        LoadedInventories = inventories;
        this.DataContext = this;
        InitializeComponent();

        if(LoadedInventories.Count > 0)
        {
            ProductsFrame.Content = new SystemShopsProducts_Control(LoadedInventories[0].Products);
        }
    }

    private void InvGrid_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        if (InvGrid.SelectedItem != null)
            ProductsFrame.Content = new SystemShopsProducts_Control(((SystemShopsInventory_Wrapper)InvGrid.SelectedItem).Products);
    }
}