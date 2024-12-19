using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.EnemyParams;

namespace Kh2ProjectEditor;

public partial class BattleEnemyParams_Control : UserControl
{
    BattleEnemyParams_DataModel dataModel;
    public BattleEnemyParams_Control()
    {
        dataModel = new BattleEnemyParams_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}