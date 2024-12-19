using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.PrizeTable;

namespace Kh2ProjectEditor;

public partial class BattlePrizeTable_Control : UserControl
{
    BattlePrizeTable_DataModel dataModel;
    public BattlePrizeTable_Control()
    {
        dataModel = new BattlePrizeTable_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}