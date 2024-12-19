using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Jiminy.Story;

namespace Kh2ProjectEditor;

public partial class JiminyStory_Control : UserControl
{
    JiminyStory_DataModel dataModel;
    public JiminyStory_Control()
    {
        dataModel = new JiminyStory_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}