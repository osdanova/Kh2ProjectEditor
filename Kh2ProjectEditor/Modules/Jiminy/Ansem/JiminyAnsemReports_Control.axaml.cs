using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Jiminy.Ansem;

namespace Kh2ProjectEditor;

public partial class JiminyAnsemReports_Control : UserControl
{
    JiminyAnsemReports_DataModel dataModel;
    public JiminyAnsemReports_Control()
    {
        dataModel = new JiminyAnsemReports_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}