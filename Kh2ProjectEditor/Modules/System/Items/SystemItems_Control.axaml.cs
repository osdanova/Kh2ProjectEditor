using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.Items;

namespace Kh2ProjectEditor;

public partial class SystemItems_Control : UserControl
{
    SystemItems_DataModel dataModel;
    public SystemItems_Control()
    {
        dataModel = new SystemItems_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_ApplyFilter(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.ApplyFilters();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}