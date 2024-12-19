using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.Summons;

namespace Kh2ProjectEditor;

public partial class BattleSummons_Control : UserControl
{
    BattleSummons_DataModel dataModel;
    public BattleSummons_Control()
    {
        dataModel = new BattleSummons_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}