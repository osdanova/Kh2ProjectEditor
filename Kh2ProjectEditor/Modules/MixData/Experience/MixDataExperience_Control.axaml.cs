using Avalonia.Controls;
using Kh2ProjectEditor.Modules.MixData.Experience;

namespace Kh2ProjectEditor;

public partial class MixDataExperience_Control : UserControl
{
    MixDataExperience_DataModel dataModel;
    public MixDataExperience_Control()
    {
        dataModel = new MixDataExperience_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}