using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Battle.Magic;

namespace Kh2ProjectEditor;

public partial class BattleMagic_Control : UserControl
{
    BattleMagic_DataModel dataModel;
    public BattleMagic_Control()
    {
        dataModel = new BattleMagic_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}