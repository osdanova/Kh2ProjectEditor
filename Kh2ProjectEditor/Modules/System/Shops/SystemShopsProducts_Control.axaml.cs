using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.Shops;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor;

public partial class SystemShopsProducts_Control : UserControl
{
    public ObservableCollection<SystemShopsProduct_Wrapper> LoadedProducts { get; set; }
    public SystemShopsProducts_Control(ObservableCollection<SystemShopsProduct_Wrapper> products)
    {
        LoadedProducts = products;
        this.DataContext = this;
        InitializeComponent();
    }
}