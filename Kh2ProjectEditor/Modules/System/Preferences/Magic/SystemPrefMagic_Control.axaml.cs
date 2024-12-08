using Avalonia.Controls;
using Kh2ProjectEditor.Modules.System.Preferences.Magic;

namespace Kh2ProjectEditor;

public partial class SystemPrefMagic_Control : UserControl
{
    SystemPrefMagic_DataModel dataModel;
    public SystemPrefMagic_Control()
    {
        dataModel = new SystemPrefMagic_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}