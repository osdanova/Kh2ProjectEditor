using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Jiminy.Quests;

namespace Kh2ProjectEditor;

public partial class JiminyQuests_Control : UserControl
{
    JiminyQuests_DataModel dataModel;
    public JiminyQuests_Control()
    {
        dataModel = new JiminyQuests_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}