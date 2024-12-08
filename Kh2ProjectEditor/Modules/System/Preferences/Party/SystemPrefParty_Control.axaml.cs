using Avalonia.Controls;
using Kh2ProjectEditor.Modules.System.Preferences.Party;

namespace Kh2ProjectEditor;

public partial class SystemPrefParty_Control : UserControl
{
    SystemPrefParty_DataModel dataModel;
    public SystemPrefParty_Control()
    {
        dataModel = new SystemPrefParty_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}