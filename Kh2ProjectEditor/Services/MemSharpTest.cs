using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binarysharp.MSharp;

namespace Kh2ProjectEditor.Services
{
    public class MemSharpTest
    {
        public void check()
        {
            var sharp = new MemorySharp(Process.GetCurrentProcess());
        }


        public static void DetectAndHook()
        {
            Process proc = Process.GetProcessesByName("KINGDOM HEARTS II FINAL MIX").FirstOrDefault();
            var sharp = new MemorySharp(proc);
            char[] a = sharp.Read<char>(0x2A22BA0,6);
            string b = sharp.ReadString(0x2A22BA0, maxLength:6);
            Debug.WriteLine("Base address: " + proc.MainModule.BaseAddress);
            Debug.WriteLine("Sharp Base address: " + sharp.Modules.MainModule.BaseAddress);
        }
    }
}
