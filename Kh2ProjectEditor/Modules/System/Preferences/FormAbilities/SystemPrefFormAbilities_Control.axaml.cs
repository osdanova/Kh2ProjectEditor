using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.Preferences.FormAbilities;

namespace Kh2ProjectEditor;

public partial class SystemPrefFormAbilities_Control : UserControl
{
    SystemPrefFormAbilities_DataModel dataModel;
    public SystemPrefFormAbilities_Control()
    {
        dataModel = new SystemPrefFormAbilities_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_ApplyFilter(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //dataModel.ApplyFilters();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}