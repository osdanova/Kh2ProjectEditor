using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.AreaInfo;

namespace Kh2ProjectEditor;

public partial class SystemAreaInfo_Control : UserControl
{
    SystemAreaInfo_DataModel dataModel;
    public SystemAreaInfo_Control()
    {
        dataModel = new SystemAreaInfo_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }

    private void Grid_Add(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.AddEntry();
    }
    private void Grid_Remove(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SystemAreaInfo_Wrapper entry = (SystemAreaInfo_Wrapper)DGrid.SelectedItem;
        dataModel.RemoveEntry(entry);
    }
}