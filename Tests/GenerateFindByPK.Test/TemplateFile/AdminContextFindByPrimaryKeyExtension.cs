using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Admin.DB
{
    public static class AdminContextExtension
    {
        public static Admin.DB.AccountLog FindByPrimaryKey(this DbSet<Admin.DB.AccountLog> entities, Int32 seq, String logType, DateTime logDate)
        {
            return entities.Find(seq, logType, logDate);
        }

        public static async Task<Admin.DB.AccountLog> FindByPrimaryKeyAsync(this DbSet<Admin.DB.AccountLog> entities, Int32 seq, String logType, DateTime logDate)
        {
            return await entities.FindAsync(seq, logType, logDate);
        }

        public static Admin.DB.AppValidation FindByPrimaryKey(this DbSet<Admin.DB.AppValidation> entities, String applicationID, String validationType)
        {
            return entities.Find(applicationID, validationType);
        }

        public static async Task<Admin.DB.AppValidation> FindByPrimaryKeyAsync(this DbSet<Admin.DB.AppValidation> entities, String applicationID, String validationType)
        {
            return await entities.FindAsync(applicationID, validationType);
        }

        public static Admin.DB.AssemblyStorage FindByPrimaryKey(this DbSet<Admin.DB.AssemblyStorage> entities, String applicationID, String assemblyType, String key)
        {
            return entities.Find(applicationID, assemblyType, key);
        }

        public static async Task<Admin.DB.AssemblyStorage> FindByPrimaryKeyAsync(this DbSet<Admin.DB.AssemblyStorage> entities, String applicationID, String assemblyType, String key)
        {
            return await entities.FindAsync(applicationID, assemblyType, key);
        }

        public static Admin.DB.Config FindByPrimaryKey(this DbSet<Admin.DB.Config> entities, String section, String key, String applicationID)
        {
            return entities.Find(section, key, applicationID);
        }

        public static async Task<Admin.DB.Config> FindByPrimaryKeyAsync(this DbSet<Admin.DB.Config> entities, String section, String key, String applicationID)
        {
            return await entities.FindAsync(section, key, applicationID);
        }

        public static Admin.DB.Content FindByPrimaryKey(this DbSet<Admin.DB.Content> entities, String applicationID, String contentType, String iD)
        {
            return entities.Find(applicationID, contentType, iD);
        }

        public static async Task<Admin.DB.Content> FindByPrimaryKeyAsync(this DbSet<Admin.DB.Content> entities, String applicationID, String contentType, String iD)
        {
            return await entities.FindAsync(applicationID, contentType, iD);
        }

        public static Admin.DB.Customization FindByPrimaryKey(this DbSet<Admin.DB.Customization> entities, String applicationID, String userLogin, String customizationType, String key)
        {
            return entities.Find(applicationID, userLogin, customizationType, key);
        }

        public static async Task<Admin.DB.Customization> FindByPrimaryKeyAsync(this DbSet<Admin.DB.Customization> entities, String applicationID, String userLogin, String customizationType, String key)
        {
            return await entities.FindAsync(applicationID, userLogin, customizationType, key);
        }

        public static Admin.DB.FieldData FindByPrimaryKey(this DbSet<Admin.DB.FieldData> entities, String applicationID, String tableName, String fieldName, String formID)
        {
            return entities.Find(applicationID, tableName, fieldName, formID);
        }

        public static async Task<Admin.DB.FieldData> FindByPrimaryKeyAsync(this DbSet<Admin.DB.FieldData> entities, String applicationID, String tableName, String fieldName, String formID)
        {
            return await entities.FindAsync(applicationID, tableName, fieldName, formID);
        }

        public static Admin.DB.Localization FindByPrimaryKey(this DbSet<Admin.DB.Localization> entities, String applicationID, String culture, String key)
        {
            return entities.Find(applicationID, culture, key);
        }

        public static async Task<Admin.DB.Localization> FindByPrimaryKeyAsync(this DbSet<Admin.DB.Localization> entities, String applicationID, String culture, String key)
        {
            return await entities.FindAsync(applicationID, culture, key);
        }

        public static Admin.DB.Message FindByPrimaryKey(this DbSet<Admin.DB.Message> entities, String applicationID, String messageType, String iD)
        {
            return entities.Find(applicationID, messageType, iD);
        }

        public static async Task<Admin.DB.Message> FindByPrimaryKeyAsync(this DbSet<Admin.DB.Message> entities, String applicationID, String messageType, String iD)
        {
            return await entities.FindAsync(applicationID, messageType, iD);
        }

        public static Admin.DB.MessageStatus FindByPrimaryKey(this DbSet<Admin.DB.MessageStatus> entities, String applicationID, String messageType, String iD, String userLogin)
        {
            return entities.Find(applicationID, messageType, iD, userLogin);
        }

        public static async Task<Admin.DB.MessageStatus> FindByPrimaryKeyAsync(this DbSet<Admin.DB.MessageStatus> entities, String applicationID, String messageType, String iD, String userLogin)
        {
            return await entities.FindAsync(applicationID, messageType, iD, userLogin);
        }

        public static Admin.DB.RecentVisitedPage FindByPrimaryKey(this DbSet<Admin.DB.RecentVisitedPage> entities, String applicationID, Int32 seq, String userLogin)
        {
            return entities.Find(applicationID, seq, userLogin);
        }

        public static async Task<Admin.DB.RecentVisitedPage> FindByPrimaryKeyAsync(this DbSet<Admin.DB.RecentVisitedPage> entities, String applicationID, Int32 seq, String userLogin)
        {
            return await entities.FindAsync(applicationID, seq, userLogin);
        }

        public static Admin.DB.Report FindByPrimaryKey(this DbSet<Admin.DB.Report> entities, String iD)
        {
            return entities.Find(iD);
        }

        public static async Task<Admin.DB.Report> FindByPrimaryKeyAsync(this DbSet<Admin.DB.Report> entities, String iD)
        {
            return await entities.FindAsync(iD);
        }

        public static Admin.DB.ReportToUrlID FindByPrimaryKey(this DbSet<Admin.DB.ReportToUrlID> entities, String reportID, String urlID)
        {
            return entities.Find(reportID, urlID);
        }

        public static async Task<Admin.DB.ReportToUrlID> FindByPrimaryKeyAsync(this DbSet<Admin.DB.ReportToUrlID> entities, String reportID, String urlID)
        {
            return await entities.FindAsync(reportID, urlID);
        }

        public static Admin.DB.SystemTaskCompleted FindByPrimaryKey(this DbSet<Admin.DB.SystemTaskCompleted> entities, Guid sysRowID)
        {
            return entities.Find(sysRowID);
        }

        public static async Task<Admin.DB.SystemTaskCompleted> FindByPrimaryKeyAsync(this DbSet<Admin.DB.SystemTaskCompleted> entities, Guid sysRowID)
        {
            return await entities.FindAsync(sysRowID);
        }

        public static Admin.DB.SystemTaskQueue FindByPrimaryKey(this DbSet<Admin.DB.SystemTaskQueue> entities, Guid sysRowID)
        {
            return entities.Find(sysRowID);
        }

        public static async Task<Admin.DB.SystemTaskQueue> FindByPrimaryKeyAsync(this DbSet<Admin.DB.SystemTaskQueue> entities, Guid sysRowID)
        {
            return await entities.FindAsync(sysRowID);
        }

        public static Admin.DB.UpdateScript FindByPrimaryKey(this DbSet<Admin.DB.UpdateScript> entities, String name, DateTime dateOfAppl)
        {
            return entities.Find(name, dateOfAppl);
        }

        public static async Task<Admin.DB.UpdateScript> FindByPrimaryKeyAsync(this DbSet<Admin.DB.UpdateScript> entities, String name, DateTime dateOfAppl)
        {
            return await entities.FindAsync(name, dateOfAppl);
        }

        public static Admin.DB.UrlID FindByPrimaryKey(this DbSet<Admin.DB.UrlID> entities, String iD)
        {
            return entities.Find(iD);
        }

        public static async Task<Admin.DB.UrlID> FindByPrimaryKeyAsync(this DbSet<Admin.DB.UrlID> entities, String iD)
        {
            return await entities.FindAsync(iD);
        }

        public static Admin.DB.UserConfiguration FindByPrimaryKey(this DbSet<Admin.DB.UserConfiguration> entities, String applicationID, String userLogin)
        {
            return entities.Find(applicationID, userLogin);
        }

        public static async Task<Admin.DB.UserConfiguration> FindByPrimaryKeyAsync(this DbSet<Admin.DB.UserConfiguration> entities, String applicationID, String userLogin)
        {
            return await entities.FindAsync(applicationID, userLogin);
        }

        public static Admin.DB.UserData FindByPrimaryKey(this DbSet<Admin.DB.UserData> entities, String applicationID, String userLogin, String clientID)
        {
            return entities.Find(applicationID, userLogin, clientID);
        }

        public static async Task<Admin.DB.UserData> FindByPrimaryKeyAsync(this DbSet<Admin.DB.UserData> entities, String applicationID, String userLogin, String clientID)
        {
            return await entities.FindAsync(applicationID, userLogin, clientID);
        }

        public static Admin.DB.UserStorage FindByPrimaryKey(this DbSet<Admin.DB.UserStorage> entities, String userLogin, String key, String dataType)
        {
            return entities.Find(userLogin, key, dataType);
        }

        public static async Task<Admin.DB.UserStorage> FindByPrimaryKeyAsync(this DbSet<Admin.DB.UserStorage> entities, String userLogin, String key, String dataType)
        {
            return await entities.FindAsync(userLogin, key, dataType);
        }

    }
}