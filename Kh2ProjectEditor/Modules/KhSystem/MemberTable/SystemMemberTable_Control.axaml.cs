using Avalonia.Controls;
using Kh2ProjectEditor.Modules.KhSystem.MemberTable;

namespace Kh2ProjectEditor;

public partial class SystemMemberTable_Control : UserControl
{
    SystemMemberTable_DataModel DataModel;
    public SystemMemberTable_Control()
    {
        DataModel = new SystemMemberTable_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.SaveFile();
    }
}