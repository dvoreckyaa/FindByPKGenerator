# FindByPKGenerator
This project is to generate DbSet extensions to support Find by primary key functions with named parameters.

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
 
* GenerateFileFromAssembly -  Generates a source file containing an extension to support Find functions with named parameters. assembly (dll) file must be provied as parameter.
* GenerateFileFromProject - Generates a source file containing an extension to support Find functions with named parameters. csproj file must be provied as parameter.
* GenerateFileContentFromType -  Generates a string containing an extension to support Find functions with named parameters.
* GenerateFileFromType -  Generates *.cs a file containing an extension to support Find functions with named parameters.

#### Tool.FindByPKGenerator.exe - a CLI tool to generate DBSet extensions.

| Short Name   | Name                |Description                        |
|------------- |:--------------------|:----------------------------------|
| -a           | --assembly          | Required. DbContext assembly path or csproj file path or the path to the folder containig csproj file |
| -o           | --outputFolder      | Required. Output folder           |
| -x           | --contextName       | Context name                      |
| -f           | --outputFileName    | Output file name                  |

#### Examples:
```
 -i c:\Projects\Admin.Db\ -o c:\Projects\Admin.Db\Generated --f FindByPKExtension
 -i c:\Projects\Admin.Db\Admin.Db.csproj -o c:\Projects\Admin.Db\Generated
 -i c:\Projects\Build\Admin.Db.dll -o c:\Projects\Admin.Db\Generated
```
    
The tool uses [commandlineparser](https://github.com/commandlineparser/commandline) to parse command line arguments.