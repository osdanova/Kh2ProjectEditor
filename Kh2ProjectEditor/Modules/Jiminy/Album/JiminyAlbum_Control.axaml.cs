using Avalonia.Controls;
using Kh2ProjectEditor.Modules.Jiminy.Album;

namespace Kh2ProjectEditor;

public partial class JiminyAlbum_Control : UserControl
{
    JiminyAlbum_DataModel dataModel;
    public JiminyAlbum_Control()
    {
        dataModel = new JiminyAlbum_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}