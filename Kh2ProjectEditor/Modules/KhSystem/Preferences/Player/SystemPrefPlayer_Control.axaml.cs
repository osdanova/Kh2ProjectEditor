using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.Preferences.Player;

namespace Kh2ProjectEditor;

public partial class SystemPrefPlayer_Control : UserControl
{
    SystemPrefPlayer_DataModel dataModel;
    public SystemPrefPlayer_Control()
    {
        dataModel = new SystemPrefPlayer_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}