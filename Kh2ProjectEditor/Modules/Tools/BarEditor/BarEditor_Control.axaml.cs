using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Kh2ProjectEditor.Modules.Tools.BarEditor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static Kh2ProjectEditor.Modules.Tools.BarEditor.BarEditor_DataModel;

namespace Kh2ProjectEditor;

public partial class BarEditor_Control : UserControl
{
    BarEditor_DataModel dataModel;

    public BarEditor_Control()
    {
        dataModel = new BarEditor_DataModel();
        this.DataContext = dataModel;
        InitializeComponent();
        AddHandler(DragDrop.DropEvent, Drop);
    }

    public void Button_Save(object sender, RoutedEventArgs args)
    {
        dataModel.SaveFile();
    }

    private void ContextMenu_Export(object? sender, RoutedEventArgs e)
    {
        dataModel.ExportEntry((EntryWrapper)BarGrid.SelectedItem);
    }

    private void ContextMenu_Import(object? sender, RoutedEventArgs e)
    {
        dataModel.ImportEntry();
    }

    private void ContextMenu_Replace(object? sender, RoutedEventArgs e)
    {
        dataModel.ReplaceEntry((EntryWrapper)BarGrid.SelectedItem);
    }

    private void Drop(object sender, DragEventArgs e)
    {
        List<string> files = e.Data.GetFileNames().ToList();

        if (files.Count == 0)
        {
            Debug.WriteLine("No files found on drop");
            return;
        }

        string filePath = Uri.UnescapeDataString(files[0]);

        if (Directory.Exists(filePath))
        {
            Debug.WriteLine("This is a folder");
            return;
        }
        else if (!File.Exists(filePath))
        {
            Debug.WriteLine("File doesn't exist");
            return;
        }

        dataModel.LoadBarFile(filePath);
    }
}