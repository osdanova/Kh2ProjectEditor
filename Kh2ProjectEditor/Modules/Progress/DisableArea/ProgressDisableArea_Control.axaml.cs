using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Progress.DisableArea;

namespace Kh2ProjectEditor;

public partial class ProgressDisableArea_Control : UserControl
{
    ProgressDisableArea_DataModel DataModel;
    public ProgressDisableArea_Control()
    {
        DataModel = new ProgressDisableArea_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Context_Add(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.AddEntry();
    }
    private void Context_Remove(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.RemoveEntry(DGrid.SelectedIndex);
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.SaveFile();
    }
}