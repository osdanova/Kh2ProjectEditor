using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Tools.EntityList;

namespace Kh2ProjectEditor;

public partial class ToolsEntityList_Control : UserControl
{
    ToolsEntityList_DataModel _DataModel { get; set; }
    public ToolsEntityList_Control()
    {
        _DataModel = new ToolsEntityList_DataModel();
        this.DataContext = _DataModel;
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _DataModel.LoadSheet();
    }
}