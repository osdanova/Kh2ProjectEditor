using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.PartyAttacks;

namespace Kh2ProjectEditor;

public partial class BattlePartyAttacks_Control : UserControl
{
    BattlePartyAttacks_DataModel DataModel;
    public BattlePartyAttacks_Control()
    {
        DataModel = new BattlePartyAttacks_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.SaveFile();
    }
}