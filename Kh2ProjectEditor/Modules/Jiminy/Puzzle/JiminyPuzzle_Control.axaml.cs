using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Jiminy.Puzzle;

namespace Kh2ProjectEditor;

public partial class JiminyPuzzle_Control : UserControl
{
    JiminyPuzzle_DataModel dataModel;
    public JiminyPuzzle_Control()
    {
        dataModel = new JiminyPuzzle_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}