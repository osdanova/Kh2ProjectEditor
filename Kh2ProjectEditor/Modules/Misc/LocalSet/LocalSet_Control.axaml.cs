using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Misc.LocalSet;

namespace Kh2ProjectEditor;

public partial class LocalSet_Control : UserControl
{
    LocalSet_DataModel dataModel;
    public LocalSet_Control()
    {
        dataModel = new LocalSet_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }

    private void Context_Remove(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.RemoveEntry(DGrid.SelectedIndex);
    }
    private void Context_Add(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.AddEntry();
    }
}