# FindByPKGenerator
This project is to generate DbSet extensions to support Find functions with named parameters.

For example, to obtain an entity using PK we use standard method Find
```cs
public virtual TEntity? Find(params object?[]? keyValues)
```

where parameters are object array. Which is a bit inconvenient because we don't know the order of the arguments and their types.
Instead of these Find methods this tool generates a DbSet extension.

```cs
public static Entity FindByPrimaryKey(this DbSet<Entity> entities, Int32 Id)
```


![](/img/screenshot1.png)


#### Common.FindByPKGenerator - assembly containing functions to generate source code file or string containing the source code
 
* GenerateFileFromAssembly -  Generates a source file containing an extension to support Find functions with named parameters. 
* GenerateFileContentFromType -  Generates a string containing an extension to support Find functions with named parameters.
* GenerateFileFromType -  Generates *.cs a file containing an extension to support Find functions with named parameters.

#### Tool.FindByPKGenerator.exe - a CLI tool to generate DBSet extensions.

| Short Name   | Name          |Description                        |
|------------- |:--------------|:----------------------------------|
| -a           | --assembly    | Required. DbContext assembly path |
| -o           | --outputFolder| Required. Output folder           |
| -x           | --contextName | Context name                      |
| -f           | --fileName    | Output file name                  |
    
The tool uses [commandlineparser](https://github.com/commandlineparser/commandline) to parse command line arguments.