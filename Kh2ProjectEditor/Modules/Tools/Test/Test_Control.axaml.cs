using Avalonia.Controls;
using Avalonia.Input;
using Kh2ProjectEditor.Modules.Tools.Test;
using Kh2ProjectEditor.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace Kh2ProjectEditor;

public partial class Test_Control : UserControl
{
    public Test_Control()
    {
        InitializeComponent();
        AddHandler(DragDrop.DropEvent, Drop);
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
            string[] directoryFiles = Directory.GetFiles(filePath);
            List<TestObject> testObjects = new();
            foreach (string singleFilePath in directoryFiles)
            {
                if (Path.GetFileName(singleFilePath).StartsWith("localset-")) {
                    testObjects.AddRange(ProcessFile(singleFilePath));
                }
            }

            //testObjects.Sort((p, q) => p.Id.CompareTo(q.Id));

            foreach (TestObject to in testObjects)
            {
                Debug.WriteLine(to.FileName + "\t" + to.Unk + "\t" + to.Id + "\t" + to.Name);
            }

            //Debug.WriteLine("This is a folder");
            //return;
        }

        else if (File.Exists(filePath))
        {
            //Debug.WriteLine("File doesn't exist");
            //return;
        }

        //ProcessFile(filePath);
    }

    private List<TestObject> ProcessFile(string filePath)
    {
        byte[] byteFile = File.ReadAllBytes(filePath);
        string filename = Path.GetFileNameWithoutExtension(filePath);

        List<TestObject> testObjects = new List<TestObject>();
        using (MemoryStream stream = new MemoryStream(byteFile))
        using (BinaryReader reader = new BinaryReader(stream))
        {
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                TestObject to = BinaryMapping.ReadObject<TestObject>(stream);
                to.FileName = filename;
                testObjects.Add(to);
            }
            //testObjects.Sort((p, q) => p.id.CompareTo(q.id));
            //
            //foreach (TestObject to in testObjects)
            //{
            //    Debug.WriteLine(to.id + "\t" + to.name);
            //}
        }
        return testObjects;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //GameHook_Service.Instance.DetectAndHook();
        //MemSharpTest.DetectAndHook();
        Process_Service.Instance.AutoDetect();
    }
}