using Avalonia.Controls;
using Kh2ProjectEditor.Modules.System.Preferences.Sstm;

namespace Kh2ProjectEditor;

public partial class SystemPrefSstm_Control : UserControl
{
    SystemPrefSstm_DataModel dataModel;
    public SystemPrefSstm_Control()
    {
        dataModel = new SystemPrefSstm_DataModel();
        this.DataContext = dataModel.SystemPrefs;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}