using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.FormLevels;

namespace Kh2ProjectEditor;

public partial class BattleFormLevels_Control : UserControl
{
    BattleFormLevels_DataModel dataModel;
    public BattleFormLevels_Control()
    {
        dataModel = new BattleFormLevels_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}