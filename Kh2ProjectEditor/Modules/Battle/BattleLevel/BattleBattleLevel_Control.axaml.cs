using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.BattleLevel;

namespace Kh2ProjectEditor;

public partial class BattleBattleLevel_Control : UserControl
{
    BattleBattleLevel_DataModel dataModel;
    public BattleBattleLevel_Control()
    {
        dataModel = new BattleBattleLevel_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}