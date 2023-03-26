using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Common.FindByPKGenerator
{
    public static class ContextExtension
    {
        public static T CreateAsInMemory<T>(string databaseName = "") where T : DbContext
        {
            databaseName = string.IsNullOrEmpty(databaseName) ? typeof(T).Name : databaseName;
            var optBuilder = new DbContextOptionsBuilder<T>()
                                      .UseInMemoryDatabase(databaseName: databaseName)
                                      .Options;
            return (T)Activator.CreateInstance(typeof(T), new object[] { optBuilder });
        }

        public static IEnumerable<Type> GetEntityClrTypes<T>(string databaseName = "") where T : DbContext
        {
            using (var db = CreateAsInMemory<T>(databaseName))
            {
                return db.Model.GetEntityTypes().Select(t => t.ClrType).Where(r => r != null);
            }
        }

        public static IEnumerable<IEntityType> GetEntityTypes<T>(string databaseName = "") where T : DbContext
        {
            using (var db = CreateAsInMemory<T>(databaseName))
            {
                return db.Model.GetEntityTypes();
            }
        }
    }
}