using System.Reflection;

using CommandLine;

using Common.FindByPKGenerator;

using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
ILogger logger = loggerFactory.CreateLogger(Assembly.GetExecutingAssembly().GetName().Name);


var result = CommandLine.Parser.Default.ParseArguments<Options>(args).MapResult((opts) => RunOptionsAndReturnExitCode(opts), errs => HandleParseError(errs));

int RunOptionsAndReturnExitCode(Options o)
{
    logger.LogInformation($"File Path: {o.FilePath}");
    logger.LogInformation($"Output Folder: {o.OutputFolder}");
    if (!string.IsNullOrEmpty(o.OutputFileName))
    {
        logger.LogInformation($"Output file name: {o.OutputFileName}");
    }
    if (!string.IsNullOrEmpty(o.ContextName))
    {
        logger.LogInformation($"Context name: {o.ContextName}");
    }
    List<string> generatedFileNames = new List<string>();
    if (Directory.Exists(o.FilePath))
    {
        foreach (var fileName in Directory.GetFiles(o.FilePath, "*.csproj", SearchOption.TopDirectoryOnly))
        {
            logger.LogInformation($"Found: {fileName}");
            new DbSetExtensionGenerator(logger).GenerateFileFromProject(fileName, o.OutputFolder, out IList<string> generatedFileNamesCur, o.ContextName, o.OutputFileName);
            generatedFileNames.AddRange(generatedFileNamesCur);
        }
    }
    else
    if (Path.GetExtension(o.FilePath).Equals(".csproj", StringComparison.OrdinalIgnoreCase))
    {
        new DbSetExtensionGenerator(logger).GenerateFileFromProject(o.FilePath, o.OutputFolder, out IList<string> generatedFileNamesCur, o.ContextName, o.OutputFileName);
        generatedFileNames.AddRange(generatedFileNamesCur);
    }
    else
    {
        new DbSetExtensionGenerator(logger).GenerateFileFromAssembly(o.FilePath, o.OutputFolder, out IList<string> generatedFileNamesCur, o.ContextName, o.OutputFileName);
        generatedFileNames.AddRange(generatedFileNamesCur);
    }

    foreach (var fileName in generatedFileNames)
    {
        logger.LogInformation(fileName);
    }
    if (!generatedFileNames.Any())
    {
        logger.LogInformation("DbContext not found");
    }
    logger.LogInformation("Done.");
    return 0;
}

int HandleParseError(IEnumerable<Error> errs)
{
    var result = -2;
    logger.LogError("errors {0}", errs.Count());
    if (errs.Any(x => x is HelpRequestedError || x is VersionRequestedError))
        result = -1;
    logger.LogError("Exit code {0}", result);
    return result;
}

class Options
{
    [Option('i', "filePath", Required = true, HelpText = "DbContext assembly path or csproj file path or the path to the folder containig csproj file")]
    public string FilePath { get; set; }
    [Option('o', "outputFolder", Required = true, HelpText = "Output folder")]
    public string OutputFolder { get; set; }
    [Option('x', "contextName", Required = false, HelpText = "Context name")]
    public string ContextName { get; set; }
    [Option('f', "outputFileName", Required = false, HelpText = "Output file name")]
    public string OutputFileName { get; set; }
}
