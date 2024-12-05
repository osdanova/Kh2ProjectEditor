using Avalonia.Controls;
using Kh2ProjectEditor.Modules.System.AreaInfo;

namespace Kh2ProjectEditor;

public partial class SystemAreaInfo_Control : UserControl
{
    SystemAreaInfo_DataModel dataModel;
    public SystemAreaInfo_Control()
    {
        dataModel = new SystemAreaInfo_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}