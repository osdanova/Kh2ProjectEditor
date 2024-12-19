using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.Limits;

namespace Kh2ProjectEditor;

public partial class BattleLimits_Control : UserControl
{
    BattleLimits_DataModel dataModel;
    public BattleLimits_Control()
    {
        dataModel = new BattleLimits_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}