using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.LevelParams;

namespace Kh2ProjectEditor;

public partial class BattleLevelParams_Control : UserControl
{
    BattleLevelParams_DataModel DataModel;
    public BattleLevelParams_Control()
    {
        DataModel = new BattleLevelParams_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.SaveFile();
    }
}