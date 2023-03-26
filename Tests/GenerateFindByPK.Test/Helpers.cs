using System.Reflection;
using System.Security.Cryptography;
using System.Text;

using GenerateFindByPK.Test.Properties;

namespace FindByPKGenerator.Test
{
    internal static class Helpers
    {
        public static string AdminContextFindByPrimaryKeyExtensionTemplateFileName => nameof(Resources.AdminContextFindByPrimaryKeyExtension) + ".cs";
        public static string GenerateTempFolderName()
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            return Path.Join(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
        }

        public static string CreateTempFolderName()
        {
            var tempPath = GenerateTempFolderName();
            Directory.CreateDirectory(tempPath);
            return tempPath;
        }

        public static string GetFileHash(string filename)
        {
            var hash = SHA512.Create();
            var clearBytes = File.ReadAllBytes(filename);
            var hashedBytes = hash.ComputeHash(clearBytes);
            return ConvertBytesToHex(hashedBytes);
        }

        public static string SaveAdminContextFindByPrimaryKeyExtensionTemplateFile(string path)
        {
            var tempFileName = Path.Combine(path, Path.GetRandomFileName() + AdminContextFindByPrimaryKeyExtensionTemplateFileName);
            File.WriteAllText(tempFileName, Resources.AdminContextFindByPrimaryKeyExtension);
            return tempFileName;
        }

        public static string GetTempFileName(string path, string ext = "")
        {
            return Path.Join(path, Path.GetRandomFileName() + ext);
        }

        private static string ConvertBytesToHex(byte[] bytes)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x"));
            }
            return sb.ToString();
        }
    }
}
