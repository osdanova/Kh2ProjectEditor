using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.BonusLevels;

namespace Kh2ProjectEditor;

public partial class BattleBonusLevels_Control : UserControl
{
    BattleBonusLevels_DataModel dataModel;
    public BattleBonusLevels_Control()
    {
        dataModel = new BattleBonusLevels_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}