using Avalonia.Controls;
using Kh2ProjectEditor.Modules.MixData.Recipes;

namespace Kh2ProjectEditor;

public partial class MixDataRecipes_Control : UserControl
{
    MixDataRecipes_DataModel dataModel;
    public MixDataRecipes_Control()
    {
        dataModel = new MixDataRecipes_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}