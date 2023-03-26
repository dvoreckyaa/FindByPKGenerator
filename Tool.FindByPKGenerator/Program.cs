using CommandLine;

using Common.FindByPKGenerator;

var result = CommandLine.Parser.Default.ParseArguments<Options>(args).MapResult((opts) => RunOptionsAndReturnExitCode(opts), errs => HandleParseError(errs));


int RunOptionsAndReturnExitCode(Options o)
{
    Console.WriteLine($"Assembly Path: {o.AssemblyPath}");
    Console.WriteLine($"Output Folder: {o.OutputFolder}");
    if (!string.IsNullOrEmpty(o.ContextName))
    {
        Console.WriteLine($"Context name: {o.ContextName}");
    }
    if (!string.IsNullOrEmpty(o.FileName))
    {
        Console.WriteLine($"FileName name: {o.FileName}");
    }
    new DbSetExtensionGenerator().GenerateFileFromAssembly(o.AssemblyPath, o.OutputFolder, out IList<string> generatedFileNames, o.ContextName, o.FileName);
    foreach (var fileName in generatedFileNames)
    {
        Console.WriteLine(fileName);
    }
    if (!generatedFileNames.Any())
    {
        Console.WriteLine("DbContext not found");
    }
    Console.WriteLine("Done.");
    return 0;
}

int HandleParseError(IEnumerable<Error> errs)
{
    var result = -2;
    Console.WriteLine("errors {0}", errs.Count());
    if (errs.Any(x => x is HelpRequestedError || x is VersionRequestedError))
        result = -1;
    Console.WriteLine("Exit code {0}", result);
    return result;
}

class Options
{
    [Option('a', "assembly", Required = true, HelpText = "DbContext assembly path")]
    public string AssemblyPath { get; set; }
    [Option('o', "outputFolder", Required = true, HelpText = "Output folder")]
    public string OutputFolder { get; set; }
    [Option('x', "contextName", Required = false, HelpText = "Context name")]
    public string ContextName { get; set; }
    [Option('f', "fileName", Required = false, HelpText = "Output file name")]
    public string FileName { get; set; }
}
