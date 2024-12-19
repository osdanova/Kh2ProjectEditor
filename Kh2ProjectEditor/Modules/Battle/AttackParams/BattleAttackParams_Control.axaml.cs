using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.AttackParams;

namespace Kh2ProjectEditor;

public partial class BattleAttackParams_Control : UserControl
{
    BattleAttackParams_DataModel DataModel;
    public BattleAttackParams_Control()
    {
        DataModel = new BattleAttackParams_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Button_ApplyFilter(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.ApplyFilters();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.SaveFile();
    }
}