using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Jiminy.Minigames;

namespace Kh2ProjectEditor;

public partial class JiminyMinigames_Control : UserControl
{
    JiminyMinigames_DataModel dataModel;
    public JiminyMinigames_Control()
    {
        dataModel = new JiminyMinigames_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}