using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Jiminy.Limits;

namespace Kh2ProjectEditor;

public partial class JiminyLimits_Control : UserControl
{
    JiminyLimits_DataModel dataModel;
    public JiminyLimits_Control()
    {
        dataModel = new JiminyLimits_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}