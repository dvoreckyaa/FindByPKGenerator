using System.Reflection;

using Admin.DB;

using Common.FindByPKGenerator;

using GenerateFindByPK.Test.Properties;

namespace FindByPKGenerator.Test
{
    public class FindByPKGenerator
    {
        [Fact]
        public void Generate_File_FromAssembly_Default()
        {
            var tempPath = Helpers.CreateTempFolderName();
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            Directory.CreateDirectory(tempPath);
            try
            {
                new DbSetExtensionGenerator().GenerateFileFromAssembly(assemblyPath, tempPath, out IList<string> generatedFileNames);
                var generatedFileName = generatedFileNames.FirstOrDefault();

                Assert.True(File.Exists(generatedFileName));
                Assert.Equal(Path.GetFileName(generatedFileName), Helpers.AdminContextFindByPrimaryKeyExtensionTemplateFileName);

                var templateFileName = Helpers.SaveAdminContextFindByPrimaryKeyExtensionTemplateFile(tempPath);
                var hashOfTemplateFile = Helpers.GetFileHash(templateFileName);
                var hashOfGeneratedFile = Helpers.GetFileHash(generatedFileName);
                Assert.Equal(hashOfTemplateFile, hashOfGeneratedFile);
            }
            finally
            {
                Directory.Delete(tempPath, true);
            }
        }

        [Fact]
        public void Generate_File_FromAssembly_Custom_Params()
        {
            var contextName = nameof(AdminContext);
            var tempPath = Helpers.CreateTempFolderName();
            var customFileName = Path.GetRandomFileName() + ".cs";
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            Directory.CreateDirectory(tempPath);
            try
            {
                new DbSetExtensionGenerator().GenerateFileFromAssembly(assemblyPath, tempPath, out IList<string> generatedFileNames, contextName, customFileName);
                var generatedFileName = generatedFileNames.FirstOrDefault();

                Assert.True(File.Exists(generatedFileName));
                Assert.Equal(Path.GetFileName(generatedFileName), customFileName);

                var templateFileName = Helpers.SaveAdminContextFindByPrimaryKeyExtensionTemplateFile(tempPath);
                var hashOfTemplateFile = Helpers.GetFileHash(templateFileName);
                var hashOfGeneratedFile = Helpers.GetFileHash(generatedFileName);
                Assert.Equal(hashOfTemplateFile, hashOfGeneratedFile);
            }
            finally
            {
                Directory.Delete(tempPath, true);
            }
        }

        [Fact]
        public void Generate_File_FromClass_Default()
        {
            var tempPath = Helpers.CreateTempFolderName();
            Directory.CreateDirectory(tempPath);
            try
            {
                new DbSetExtensionGenerator().GenerateFileFromType<AdminContext>(tempPath, out string generatedFileName);

                Assert.True(File.Exists(generatedFileName));
                Assert.Equal(Path.GetFileName(generatedFileName), Helpers.AdminContextFindByPrimaryKeyExtensionTemplateFileName);

                var templateFileName = Helpers.SaveAdminContextFindByPrimaryKeyExtensionTemplateFile(tempPath);
                var hashOfTemplateFile = Helpers.GetFileHash(templateFileName);
                var hashOfGeneratedFile = Helpers.GetFileHash(generatedFileName);
                Assert.Equal(hashOfTemplateFile, hashOfGeneratedFile);
            }
            finally
            {
                Directory.Delete(tempPath, true);
            }
        }

        [Fact]
        public void Generate_File_FromClass_CustomParams()
        {
            var tempPath = Helpers.CreateTempFolderName();
            var customFileName = Path.GetRandomFileName() + ".cs";
            Directory.CreateDirectory(tempPath);
            try
            {
                new DbSetExtensionGenerator().GenerateFileFromType<AdminContext>(tempPath, out string generatedFileName, customFileName);

                Assert.True(File.Exists(generatedFileName));
                Assert.Equal(Path.GetFileName(generatedFileName), customFileName);

                var templateFileName = Helpers.SaveAdminContextFindByPrimaryKeyExtensionTemplateFile(tempPath);
                var hashOfTemplateFile = Helpers.GetFileHash(templateFileName);
                var hashOfGeneratedFile = Helpers.GetFileHash(generatedFileName);
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