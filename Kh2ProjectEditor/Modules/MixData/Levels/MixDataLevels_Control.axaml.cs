using Avalonia.Controls;
using Kh2ProjectEditor.Modules.MixData.Levels;

namespace Kh2ProjectEditor;

public partial class MixDataLevels_Control : UserControl
{
    MixDataLevels_DataModel dataModel;
    public MixDataLevels_Control()
    {
        dataModel = new MixDataLevels_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}