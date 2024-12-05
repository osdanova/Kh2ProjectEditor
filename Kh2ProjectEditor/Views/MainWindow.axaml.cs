using Avalonia.Controls;
using Kh2ProjectEditor.Utils;
using Kh2ProjectEditor.Views;
using System.Collections.Generic;
using System.IO;

namespace Kh2ProjectEditor;

public partial class MainWindow : Window
{
    MainDataModel dataModel;
    public MainWindow()
    {
        dataModel = new MainDataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private async void Button_ProjectPath(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        List<string> openDialogResults = await AvaloniaDialogUtils.OpenFolderDialog(this, "Select the project folder");
        if(openDialogResults.Count == 0 || !Directory.Exists(openDialogResults[0])) {
            return;
        }
        dataModel.LoadProjectFolder(openDialogResults[0]);
    }

    private void MenuItem_ObjectEntries(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new ObjectEntries_Control();

    private void MenuItem_SystemReactionCount(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemReactionCount_Control();
    private void MenuItem_SystemCommands(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemCommands_Control();
    private void MenuItem_SystemMemberTable(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemMemberTable_Control();
    private void MenuItem_SystemWeapons(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemWeapons_Control();
    private void MenuItem_SystemItems(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemItems_Control();
    private void MenuItem_SystemTreasures(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemTreasures_Control();
    private void MenuItem_SystemAreaInfo(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemAreaInfo_Control();
    private void MenuItem_SystemFontStyles(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemFontStyles_Control();
    private void MenuItem_SystemShops(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemShops_Control();
}