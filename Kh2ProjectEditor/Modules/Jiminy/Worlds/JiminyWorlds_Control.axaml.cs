using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Jiminy.Worlds;

namespace Kh2ProjectEditor;

public partial class JiminyWorlds_Control : UserControl
{
    JiminyWorlds_DataModel dataModel;
    public JiminyWorlds_Control()
    {
        dataModel = new JiminyWorlds_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}