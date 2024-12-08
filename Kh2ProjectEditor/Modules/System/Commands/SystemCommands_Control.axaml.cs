using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.Commands;

namespace Kh2ProjectEditor;

public partial class SystemCommands_Control : UserControl
{
    SystemCommands_DataModel dataModel;
    public SystemCommands_Control()
    {
        dataModel = new SystemCommands_DataModel();
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