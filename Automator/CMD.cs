using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Automator
{
    class CMD
    {
        private Process _cmdProcess;

        public CMD()
        {
            _cmdProcess = new Process();
            _cmdProcess.StartInfo.FileName = "cmd.exe";
            _cmdProcess.StartInfo.RedirectStandardInput = true;
            _cmdProcess.StartInfo.CreateNoWindow = false;
            _cmdProcess.StartInfo.UseShellExecute = false;
            _cmdProcess.Start();
        }

        public void Run(string commandText)
        {
            _cmdProcess.StandardInput.WriteLine(commandText);
        }
    }
}
