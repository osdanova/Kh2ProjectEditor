using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.ReactionCount;

namespace Kh2ProjectEditor;

public partial class SystemReactionCount_Control : UserControl
{
    SystemReactionCount_DataModel dataModel;
    public SystemReactionCount_Control()
    {
        dataModel = new SystemReactionCount_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}