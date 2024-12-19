using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.PlayerParams;

namespace Kh2ProjectEditor;

public partial class BattlePlayerParams_Control : UserControl
{
    BattlePlayerParams_DataModel dataModel;
    public BattlePlayerParams_Control()
    {
        dataModel = new BattlePlayerParams_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}