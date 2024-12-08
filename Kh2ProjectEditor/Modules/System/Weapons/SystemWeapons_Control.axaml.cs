using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.Weapons;

namespace Kh2ProjectEditor;

public partial class SystemWeapons_Control : UserControl
{
    SystemWeapons_DataModel DataModel;
    public SystemWeapons_Control()
    {
        DataModel = new SystemWeapons_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.SaveFile();
    }
}