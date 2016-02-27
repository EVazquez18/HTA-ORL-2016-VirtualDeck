using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_demo_build_console
{
    class Program
    {
        static void Main(string[] args)
        {
       
            var repositoryName = @"hta-orl-2016-virtual-deck";
            var repositoryRootDirectory = @"C:\github\lcasillas\Source\Repos\" + repositoryName + @"\";



            var rootFolder = repositoryRootDirectory + @"docs";
            //var rootFolder = @"C:\git\fortegra-eam\src\Fortegra.Enterprise.Business.Management.Common\docs\";
            string sphinxSourceDirectory = Path.Combine(rootFolder, "source");
            
            ExecuteCommand(Path.Combine(rootFolder, @"make-and-start-site.bat"));
        }




        static void ExecuteCommand(string command, string arguments = null)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;



            if (arguments != null)
            {
                processInfo.Arguments = arguments;

            }


            var process = Process.Start(processInfo);

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("error>>" + e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
        }


    }
}
