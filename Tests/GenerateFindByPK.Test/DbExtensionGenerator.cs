using System.Reflection;

using Admin.DB;

using Common.FindByPKGenerator;

using GenerateFindByPK.Test.Properties;

using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FindByPKGenerator.Test
{
    public class FindByPKGenerator
    {
        private ILogger logger = null;
        private ILogger Logger
        {
            get
            {
                if (logger == null)
                {
                    var loggerFactory = LoggerFactory.Create(builder =>
                    {
                        builder.AddConsole();
                    });
                    logger = loggerFactory.CreateLogger<Program>();
                }
                return logger;
            }
        }

        [Fact]
        public async Task Generate_File_FromAssembly_Default()
        {
            var tempPath = Helpers.CreateTempFolderName();
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            Directory.CreateDirectory(tempPath);
            try
            {
                new DbSetExtensionGenerator(Logger).GenerateFileFromAssembly(assemblyPath, tempPath, out IList<string> generatedFileNames);
                var generatedFileName = generatedFileNames.FirstOrDefault();

                Assert.True(File.Exists(generatedFileName));
                Assert.Equal(Path.GetFileName(generatedFileName), Helpers.AdminContextFindByPrimaryKeyExtensionTemplateFileName);

                var templateFileName = await Helpers.SaveAdminContextFindByPrimaryKeyExtensionTemplateFileAsync(tempPath);
                var hashOfTemplateFile = await Helpers.GetFileHashAsync(templateFileName);
                var hashOfGeneratedFile = await Helpers.GetFileHashAsync(generatedFileName);
                Assert.Equal(hashOfTemplateFile, hashOfGeneratedFile);
            }
            finally
            {
                Directory.Delete(tempPath, true);
            }
        }

        [Fact]
        public async Task Generate_File_FromProject_Default()
        {
            var tempPath = Helpers.CreateTempFolderName();
            var projFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestedDbContext\\AdminContext.csproj");
            Directory.CreateDirectory(tempPath);
            try
            {
                new DbSetExtensionGenerator(Logger).GenerateFileFromProject(projFilePath, tempPath, out IList<string> generatedFileNames);
                var generatedFileName = generatedFileNames.FirstOrDefault();

                Assert.True(File.Exists(generatedFileName));
                Assert.Equal(Path.GetFileName(generatedFileName), Helpers.AdminContextFindByPrimaryKeyExtensionTemplateFileName);

                var templateFileName = await Helpers.SaveAdminContextFindByPrimaryKeyExtensionTemplateFileAsync(tempPath);
                var hashOfTemplateFile = await Helpers.GetFileHashAsync(templateFileName);
                var hashOfGeneratedFile = await Helpers.GetFileHashAsync(generatedFileName);
                Assert.Equal(hashOfTemplateFile, hashOfGeneratedFile);
            }
            finally
            {
                Directory.Delete(tempPath, true);
            }
        }

        [Fact]
        public async Task Generate_File_FromProject_Custom_Params()
        {
            var contextName = nameof(AdminContext);
            var tempPath = Helpers.CreateTempFolderName();
            var customFileName = Path.GetRandomFileName() + ".cs";
            var projFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestedDbContext\\AdminContext.csproj");
            Directory.CreateDirectory(tempPath);
            try
            {
                new DbSetExtensionGenerator(Logger).GenerateFileFromProject(projFilePath, tempPath, out IList<string> generatedFileNames, contextName, customFileName);
                var generatedFileName = generatedFileNames.FirstOrDefault();

                Assert.True(File.Exists(generatedFileName));
                Assert.Equal(Path.GetFileName(generatedFileName), customFileName);

                var templateFileName = await Helpers.SaveAdminContextFindByPrimaryKeyExtensionTemplateFileAsync(tempPath);
                var hashOfTemplateFile = await Helpers.GetFileHashAsync(templateFileName);
                var hashOfGeneratedFile = await Helpers.GetFileHashAsync(generatedFileName);
                Assert.Equal(hashOfTemplateFile, hashOfGeneratedFile);
            }
            finally
            {
                Directory.Delete(tempPath, true);
            }
        }

        [Fact]
        public async Task Generate_File_FromAssembly_Custom_Params()
        {
            var contextName = nameof(AdminContext);
            var tempPath = Helpers.CreateTempFolderName();
            var customFileName = Path.GetRandomFileName() + ".cs";
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            Directory.CreateDirectory(tempPath);
            try
            {
                new DbSetExtensionGenerator(Logger).GenerateFileFromAssembly(assemblyPath, tempPath, out IList<string> generatedFileNames, contextName, customFileName);
                var generatedFileName = generatedFileNames.FirstOrDefault();

                Assert.True(File.Exists(generatedFileName));
                Assert.Equal(Path.GetFileName(generatedFileName), customFileName);

                var templateFileName = await Helpers.SaveAdminContextFindByPrimaryKeyExtensionTemplateFileAsync(tempPath);
                var hashOfTemplateFile = await Helpers.GetFileHashAsync(templateFileName);
                var hashOfGeneratedFile = await Helpers.GetFileHashAsync(generatedFileName);
                Assert.Equal(hashOfTemplateFile, hashOfGeneratedFile);
            }
            finally
            {
                Directory.Delete(tempPath, true);
            }
        }

        [Fact]
        public async Task Generate_File_FromClass_Default()
        {
            var tempPath = Helpers.CreateTempFolderName();
            Directory.CreateDirectory(tempPath);
            try
            {
                new DbSetExtensionGenerator(Logger).GenerateFileFromType<AdminContext>(tempPath, out string generatedFileName);

                Assert.True(File.Exists(generatedFileName));
                Assert.Equal(Path.GetFileName(generatedFileName), Helpers.AdminContextFindByPrimaryKeyExtensionTemplateFileName);

                var templateFileName = await Helpers.SaveAdminContextFindByPrimaryKeyExtensionTemplateFileAsync(tempPath);
                var hashOfTemplateFile = await Helpers.GetFileHashAsync(templateFileName);
                var hashOfGeneratedFile = await Helpers.GetFileHashAsync(generatedFileName);
                Assert.Equal(hashOfTemplateFile, hashOfGeneratedFile);
            }
            finally
            {
                Directory.Delete(tempPath, true);
            }
        }

        [Fact]
        public async Task Generate_File_FromClass_CustomParams()
        {
            var tempPath = Helpers.CreateTempFolderName();
            var customFileName = Path.GetRandomFileName() + ".cs";
            Directory.CreateDirectory(tempPath);
            try
            {
                new DbSetExtensionGenerator(Logger).GenerateFileFromType<AdminContext>(tempPath, out string generatedFileName, customFileName);

                Assert.True(File.Exists(generatedFileName));
                Assert.Equal(Path.GetFileName(generatedFileName), customFileName);

                var templateFileName = await Helpers.SaveAdminContextFindByPrimaryKeyExtensionTemplateFileAsync(tempPath);
                var hashOfTemplateFile = await Helpers.GetFileHashAsync(templateFileName);
                var hashOfGeneratedFile = await Helpers.GetFileHashAsync(generatedFileName);
                Assert.Equal(hashOfTemplateFile, hashOfGeneratedFile);
            }
            finally
            {
                Directory.Delete(tempPath, true);
            }
        }

        [Fact]
        public void Generate_Content_FromClass_Default()
        {
            var content = DbSetExtensionGenerator.GenerateFileContentFromType<AdminContext>();
            Assert.Equal(Resources.AdminContextFindByPrimaryKeyExtension, content);
        }
    }
}