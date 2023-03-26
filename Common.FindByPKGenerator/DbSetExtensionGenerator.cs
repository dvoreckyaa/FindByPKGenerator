using System.Reflection;

using Common.FindByPKGenerator.Models;
using Common.FindByPKGenerator.Template;

using Microsoft.EntityFrameworkCore;

namespace Common.FindByPKGenerator
{
    public class DbSetExtensionGenerator
    {
        private const string fileName = "FindByPrimaryKeyExtension";
        private string outputFileName = string.Empty;

        /// <summary>
        /// Generates *.cs a file containing an extension to support Find functons with named parameters. 
        /// Find(params object?[]? keyValues) -> FindByPrimaryKey(this DbSet<User> entities, Int32 userNo)
        /// </summary>
        /// <param name="contextAssemblyPath">path to the assemby containing DbContext</param>
        /// <param name="outputFolder">folder where the extension file should be generated</param>
        /// <param name="generatedFileNames">the list containing the generated files</param>
        /// <param name="dbContextName">the name of the contex (optional). can be used if the assembly conatins several DbContext</param>
        /// <param name="outputFileName">the name of the generated file (optional)</param>
        public void GenerateFileFromAssembly(string contextAssemblyPath, string outputFolder, out IList<string> generatedFileNames, string dbContextName = "", string outputFileName = "")
        {
            this.outputFileName = outputFileName;
            generatedFileNames = new List<string>();
            var sampleAssembly = Assembly.LoadFrom(contextAssemblyPath);
            var dbContextTypes = sampleAssembly.GetTypes().Where(t => t.IsAssignableTo(typeof(DbContext))
                                                                && (string.IsNullOrEmpty(dbContextName) || t.Name.Equals(dbContextName, StringComparison.InvariantCultureIgnoreCase)));
            foreach (var type in dbContextTypes)
            {
                var calledMethodInfo = typeof(DbSetExtensionGenerator).GetMethod(nameof(FindByPKGeneratorFile), BindingFlags.NonPublic | BindingFlags.Static);
                var calledMethod = calledMethodInfo.MakeGenericMethod(type);
                TemplateModel templateModel = calledMethod.Invoke(null, new object[] { }) as TemplateModel;
                var generatedFileName = GetFileName(type, outputFolder);
                generatedFileNames.Add(generatedFileName);
                GenerateFile(templateModel, generatedFileName);
            }
        }

        /// <summary>
        /// Generates a string containing an extension to support Find functons with named parameters.
        /// Find(params object?[]? keyValues) -> FindByPrimaryKey(this DbSet<User> entities, Int32 userNo)
        /// </summary>
        /// <typeparam name="T">Type of DbContext</typeparam>
        /// <returns>string containing the extension</returns>
        public static string GenerateFileContentFromType<T>() where T : DbContext
        {
            var model = FindByPKGeneratorFile<T>();
            return GenerateContent(model);
        }

        /// <summary>
        /// Generates *.cs a file containing an extension to support Find functons with named parameters. 
        /// Find(params object?[]? keyValues) -> FindByPrimaryKey(this DbSet<User> entities, Int32 userNo)
        /// </summary>
        /// <typeparam name="T">Type of DbContext</typeparam>
        /// <param name="outputFolder">folder where the extension file should be generated</param>
        /// <param name="generatedFileNames">the list containing the generated files</param>
        /// <param name="outputFileName">the name of the generated file (optional)</param>
        public void GenerateFileFromType<T>(string outputFolder, out string generatedFileNames, string outputFileName = "") where T : DbContext
        {
            this.outputFileName = outputFileName;
            var model = FindByPKGeneratorFile<T>();
            generatedFileNames = GetFileName(typeof(T), outputFolder);
            GenerateFile(model, generatedFileNames);
        }

        private string GetFileName(Type t, string basePath)
        {
            var generatedFileName = string.IsNullOrEmpty(outputFileName) ? $"{t.Name}{fileName}.cs" : Path.ChangeExtension(outputFileName, ".cs");
            return Path.Join(basePath, generatedFileName);
        }

        private static TemplateModel FindByPKGeneratorFile<T>() where T : DbContext
        {
            var dbNamespace = typeof(T).Namespace;
            var templateModel = new TemplateModel()
            {
                ContextName = typeof(T).Name,
                DbNamespace = dbNamespace
            };

            var entityList = ContextExtension.GetEntityTypes<T>().Where(r => r.ClrType != null);
            var contextName = typeof(T).Name;
            foreach (Microsoft.EntityFrameworkCore.Metadata.IEntityType entityType in entityList)
            {
                FindByPKGeneratorFunction(templateModel, entityType);
            }
            return templateModel;
        }

        private static void FindByPKGeneratorFunction(TemplateModel templateModel, Microsoft.EntityFrameworkCore.Metadata.IEntityType entityType)
        {
            var entityFullName = entityType.Name;
            //var entitName = entityType.ShortName();
            var pkFields = entityType.FindPrimaryKey().Properties.OrderBy(r => r.GetIndex()).ToList();
            var paramList = string.Join(", ", pkFields.Select(r => $"{r.ClrType.Name} {MakeLowerCaseArgs(r.Name)}"));
            var argList = string.Join(", ", pkFields.Select(r => $"{MakeLowerCaseArgs(r.Name)}"));
            templateModel.EntityModels.Add(new EntityModel()
            {
                ArgumentList = argList,
                ParamList = paramList,
                EntityFullName = entityFullName
            });
        }

        static string MakeLowerCaseArgs(string arg)
        {
            if (string.IsNullOrEmpty(arg))
            {
                return string.Empty;
            }
            return $"{arg[0].ToString().ToLower()}{arg.Substring(1)}";
        }

        static string GenerateContent(TemplateModel templateModel)
        {
            var template = new FindByPrimaryKeyExtension();
            return template.TransformText(templateModel);
        }

        static void GenerateFile(TemplateModel templateModel, string fileName)
        {
            var content = GenerateContent(templateModel);
            Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            System.IO.File.WriteAllText(fileName, content);
        }
    }
}