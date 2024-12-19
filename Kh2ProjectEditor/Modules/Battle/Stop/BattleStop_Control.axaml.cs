using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.Stop;

namespace Kh2ProjectEditor;

public partial class BattleStop_Control : UserControl
{
    BattleStop_DataModel dataModel;
    public BattleStop_Control()
    {
        dataModel = new BattleStop_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}