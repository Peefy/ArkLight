using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ArkLight.Cmd
{
    public class RunCommand
    {
        public Process Process { get; set; }

        public RunCommand()
        {
            Process = new Process();
        }

        public RunCommand(Process process)
        {
            Process = process;
        }

        public void Run(string cmd)
        {
            InernalRun(Process, cmd);           
        }

        public static void RunCmd(string cmd)
        {
            InernalRun(new Process(), cmd);
        }

        public static void RunCmd(Process process, string cmd)
        {
            InernalRun(process, cmd);
        }

        private static void InernalRun(Process process, string cmd)
        {
            if (process == null)
            {
                throw new ArgumentNullException(nameof(process));
            }
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            var cmdWriter = process.StandardInput;
            process.BeginOutputReadLine();
            if (!string.IsNullOrEmpty(cmd))
            {
                cmdWriter.WriteLine(cmd);
            }
            cmdWriter.Close();
            process.Close();
        }
    }
}
