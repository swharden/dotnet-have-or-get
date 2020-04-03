using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace dotnetHAG
{
    public static class VersionChecker
    {
        public static string GetConsoleOutput(string command)
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

        public static Version GetDotnetVersion()
        {
            string output = VersionChecker.GetConsoleOutput("dotnet --version");

            if (output is null)
                return new Version();

            bool outputIsVersionFormat = (output.Split('.').Length == 3);
            if (outputIsVersionFormat)
                return new Version(output);
            else
                return new Version();
        }
    }
}
