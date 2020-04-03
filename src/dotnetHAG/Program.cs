using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace dotnetHAG
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = GetConsoleOutput("dotnet --version");
            Console.WriteLine($"This is what I got: [{output}]");
            Console.ReadLine();
        }

        private static string GetConsoleOutput(string command)
        {
            command = command.Trim();

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;

            if (command.Contains(" "))
            {
                var parts = command.Split(new char[] { ' ' }, 2);
                p.StartInfo.FileName = parts[0];
                p.StartInfo.Arguments = parts[1];
            }
            else
            {
                p.StartInfo.FileName = command;
            }

            try
            {
                p.Start();
                p.WaitForExit();
                return p.StandardOutput.ReadToEnd().Trim();
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.ToString();
                if (exceptionMessage.Contains("The system cannot find the file specified"))
                    return "file not found";
                return
                    exceptionMessage;
            }
        }
    }
}
