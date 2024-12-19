using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.FontStyles;

namespace Kh2ProjectEditor;

public partial class SystemFontStyles_Control : UserControl
{
    SystemFontStyles_DataModel dataModel;
    public SystemFontStyles_Control()
    {
        dataModel = new SystemFontStyles_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}