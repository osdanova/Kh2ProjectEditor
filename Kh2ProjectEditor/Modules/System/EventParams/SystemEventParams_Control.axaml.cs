using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.EventParams;

namespace Kh2ProjectEditor;

public partial class SystemEventParams_Control : UserControl
{
    SystemEventParams_DataModel dataModel;
    public SystemEventParams_Control()
    {
        dataModel = new SystemEventParams_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}