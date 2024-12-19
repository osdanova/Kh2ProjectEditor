using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.LevelUp;

namespace Kh2ProjectEditor;

public partial class BattleLevelUp_Control : UserControl
{
    BattleLevelUp_DataModel DataModel;
    public BattleLevelUp_Control()
    {
        DataModel = new BattleLevelUp_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.SaveFile();
    }
}