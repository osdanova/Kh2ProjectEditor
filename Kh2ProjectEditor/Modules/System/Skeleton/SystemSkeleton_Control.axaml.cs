using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.Skeleton;

namespace Kh2ProjectEditor;

public partial class SystemSkeleton_Control : UserControl
{
    SystemSkeleton_DataModel dataModel;
    public SystemSkeleton_Control()
    {
        dataModel = new SystemSkeleton_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.SaveFile();
    }
}