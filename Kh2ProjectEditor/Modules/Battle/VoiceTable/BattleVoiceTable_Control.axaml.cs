using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.VoiceTable;

namespace Kh2ProjectEditor;

public partial class BattleVoiceTable_Control : UserControl
{
    BattleVoiceTable_DataModel DataModel;
    public BattleVoiceTable_Control()
    {
        DataModel = new BattleVoiceTable_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.SaveFile();
    }
}