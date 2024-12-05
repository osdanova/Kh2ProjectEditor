using Avalonia.Controls;
using Kh2ProjectEditor.Modules.System.Treasures;

namespace Kh2ProjectEditor;

public partial class SystemTreasures_Control : UserControl
{
    SystemTreasures_DataModel dataModel;
    public SystemTreasures_Control()
    {
        dataModel = new SystemTreasures_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}