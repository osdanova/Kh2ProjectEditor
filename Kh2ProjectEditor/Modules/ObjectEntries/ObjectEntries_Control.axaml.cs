using Avalonia.Controls;
using Kh2ProjectEditor.Modules.ObjectEntries;

namespace Kh2ProjectEditor;

public partial class ObjectEntries_Control : UserControl
{
    ObjectEntries_DataModel dataModel;
    public ObjectEntries_Control()
    {
        dataModel = new ObjectEntries_DataModel();
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