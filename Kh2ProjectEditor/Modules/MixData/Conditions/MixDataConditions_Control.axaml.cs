using Avalonia.Controls;
using Kh2ProjectEditor.Modules.MixData.Conditions;

namespace Kh2ProjectEditor;

public partial class MixDataConditions_Control : UserControl
{
    MixDataConditions_DataModel dataModel;
    public MixDataConditions_Control()
    {
        dataModel = new MixDataConditions_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}