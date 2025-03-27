using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Progress.ProgressScripts;

namespace Kh2ProjectEditor;

public partial class ProgressScripts_Control : UserControl
{
    ProgressScripts_DataModel dataModel;
    public ProgressScripts_Control()
    {
        dataModel = new ProgressScripts_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_SaveScript(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveScript();
    }
    private void Button_SaveFile(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveWorld();
    }

    //private void Context_Remove(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    //{
    //    dataModel.RemoveEntry(DGrid.SelectedIndex);
    //}
    //private void Context_Add(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    //{
    //    dataModel.AddEntry();
    //}
}