using System.Diagnostics;

using Microsoft.Build.Execution;
using Microsoft.Build.Locator;
using Microsoft.Extensions.Logging;

namespace Common.FindByPKGenerator.Helpers
{
    internal static class ProjectBuilder
    {
        public static bool CompileProject(string projectFilePath, out string targetPath, Microsoft.Extensions.Logging.ILogger logger)
        {
            if (!MSBuildLocator.IsRegistered)
            {
                MSBuildLocator.RegisterInstance(MSBuildLocator.QueryVisualStudioInstances().OrderByDescending(instance => instance.Version).First());
                //MSBuildLocator.RegisterDefaults();
            }
            return BuildProjectInternal(projectFilePath, out targetPath, logger);
        }

        /* private static bool GetProjectInternal(string projectFilePath, out string targetPath)
         {
             BuildManager manager = BuildManager.DefaultBuildManager;
             var project = new ProjectInstance(projectFilePath);
             targetPath = project.GetPropertyValue("TargetPath");
             project.SetProperty("Configuration", "Release");
             var result = manager.Build(
                new BuildParameters()
                {
                    DetailedSummary = true,
                    Loggers = new List<Microsoft.Build.Framework.ILogger>() { new ConsoleLogger(LoggerVerbosity.Diagnostic) }
                },
                new BuildRequestData(project, new string[] { "Build" }));
             var buildResult = result.ResultsByTarget["Build"];
             return true;
         }*/

        private static bool BuildProjectInternal(string projectFilePath, out string targetPath, Microsoft.Extensions.Logging.ILogger logger)
        {
            var processInfo = new ProcessStartInfo("dotnet", $"build \"{projectFilePath}\"")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = Directory.GetCurrentDirectory()
            };

            //StringBuilder sb = new StringBuilder();
            Process p = Process.Start(processInfo);
            p.OutputDataReceived += (sender, args) => logger?.LogInformation(args.Data); //sb.AppendLine(args.Data);
            p.BeginOutputReadLine();
            p.WaitForExit();

            var project = new ProjectInstance(projectFilePath);
            targetPath = project.GetPropertyValue("TargetPath");
            /*if (string.IsNullOrEmpty(targetPath))
            {
                string targetFw = project.GetPropertyValue("MicrosoftNETBuildTasksTFM");
                string restFolder = project.GetPropertyValue("RestoreOutputPath");
                targetPath = Path.Combine(targetFw, restFolder);
            }
            return p.ExitCode == 0;*/
            return File.Exists(targetPath);
        }
    }
}

