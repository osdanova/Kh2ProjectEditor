using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Jiminy.Characters;

namespace Kh2ProjectEditor;

public partial class JiminyCharacters_Control : UserControl
{
    JiminyCharacters_DataModel dataModel;
    public JiminyCharacters_Control()
    {
        dataModel = new JiminyCharacters_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}