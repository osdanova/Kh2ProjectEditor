using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Jiminy.Diagrams;

namespace Kh2ProjectEditor;

public partial class JiminyDiagrams_Control : UserControl
{
    JiminyDiagrams_DataModel dataModel;
    public JiminyDiagrams_Control()
    {
        dataModel = new JiminyDiagrams_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }

    private void DataGrid_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        dataModel.LoadCharacters((JiminyDiagramsEntry_Wrapper)EntryGrid.SelectedItem);
    }
}