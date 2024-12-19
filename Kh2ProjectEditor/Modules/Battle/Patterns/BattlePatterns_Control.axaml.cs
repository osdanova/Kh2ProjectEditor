using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.Patterns;

namespace Kh2ProjectEditor;

public partial class BattlePatterns_Control : UserControl
{
    BattlePatterns_DataModel dataModel;
    public BattlePatterns_Control()
    {
        dataModel = new BattlePatterns_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}