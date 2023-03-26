using Microsoft.EntityFrameworkCore;

namespace Admin.DB
{
    public class AdminContext : DbContext
    {
        public DbSet<Config> Config { get; set; }
        public DbSet<UserStorage> UserStorage { get; set; }
        public DbSet<AccountLog> AccountLog { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<ReportToUrlID> ReportToUrlID { get; set; }
        public DbSet<UrlID> UrlID { get; set; }
        public DbSet<UpdateScript> UpdateScript { get; set; }
        public DbSet<AppValidation> AppValidation { get; set; }
        public DbSet<Localization> Localization { get; set; }
        public DbSet<UserConfiguration> UserConfiguration { get; set; }
        public DbSet<SystemTaskCompleted> SystemTaskCompleted { get; set; }
        public DbSet<SystemTaskQueue> SystemTaskQueue { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MessageStatus> MessageStatus { get; set; }
        public DbSet<RecentVisitedPage> RecentVisitedPage { get; set; }
        public DbSet<FieldData> FieldData { get; set; }
        public DbSet<Customization> Customization { get; set; }
        public DbSet<AssemblyStorage> AssemblyStorage { get; set; }

        private const string defaultSchema = "adm";
        private const int NVarCharMaxLength = 10000;

        public AdminContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Config
            modelBuilder.HasDefaultSchema(defaultSchema)
            .Entity<Config>()
            .HasKey(b => new { b.Section, b.Key, b.ApplicationID });
            modelBuilder.Entity<Config>()
            .Property(b => b.Description)
            .HasMaxLength(255);
            modelBuilder.Entity<Config>()
            .Property(b => b.IntValue)
            .IsRequired(false);
            modelBuilder.Entity<Config>()
            .Property(b => b.FloatValue)
            .IsRequired(false);
            modelBuilder.Entity<Config>()
            .Property(b => b.DateValue)
            .IsRequired(false);
            #endregion

            #region UserStorage
            modelBuilder.HasDefaultSchema(defaultSchema)
            .Entity<UserStorage>()
            .HasKey(b => new { b.UserLogin, b.Key, b.DataType });
            modelBuilder.Entity<UserStorage>()
            .Property(b => b.IntValue)
            .IsRequired(false);
            modelBuilder.Entity<UserStorage>()
            .Property(b => b.FloatValue)
            .IsRequired(false);
            modelBuilder.Entity<UserStorage>()
            .Property(b => b.DateValue)
            .IsRequired(false);
            #endregion

            #region AccountLog
            modelBuilder.HasDefaultSchema(defaultSchema)
            .Entity<AccountLog>(entity =>
            {
                entity.HasKey(b => new { b.Seq, b.LogType, b.LogDate });
                entity.Property(b => b.LogDate).HasDefaultValueSql("getUtcDate()");
                entity.Property(b => b.Seq).ValueGeneratedOnAdd();
            });
            #endregion

            #region UserData
            modelBuilder.Entity<UserData>()
            .Property(b => b.ApplicationID)
            .HasMaxLength(50);
            modelBuilder.Entity<UserData>()
            .Property(b => b.UserLogin)
            .HasMaxLength(50);
            modelBuilder.Entity<UserData>()
            .Property(b => b.ClientID)
            .HasMaxLength(100);
            modelBuilder.HasDefaultSchema(defaultSchema)
             .Entity<UserData>()
            .HasKey(b => new { b.ApplicationID, b.UserLogin, b.ClientID });

            #endregion

            #region Report
            modelBuilder.HasDefaultSchema(defaultSchema)
            .Entity<Report>()
            .HasKey(b => new { b.ID });
            modelBuilder.HasDefaultSchema(defaultSchema)
            .Entity<Report>()
            .Property(p => p.Disabled)
            .HasDefaultValue(false).IsRequired();
            modelBuilder.HasDefaultSchema(defaultSchema)
            .Entity<Report>()
            .Property(p => p.SequenceNum)
            .HasDefaultValue(0);
            #endregion

            #region Report
            modelBuilder.HasDefaultSchema(defaultSchema)
            .Entity<ReportToUrlID>()
            .HasKey(b => new { b.ReportID, b.UrlID });
            modelBuilder.Entity<ReportToUrlID>()
            .HasOne(p => p.ReportEntity)
            .WithMany(b => b.UrlIDEntities)
            .HasForeignKey(p => p.ReportID)
            .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region UrlID
            modelBuilder.HasDefaultSchema(defaultSchema)
            .Entity<UrlID>()
            .HasKey(b => new { b.ID });
            modelBuilder.HasDefaultSchema(defaultSchema)
            .Entity<UrlID>()
            .Property(p => p.Disabled)
            .HasDefaultValue(false).IsRequired();
            #endregion

            #region ReportToUrlID
            modelBuilder.Entity<ReportToUrlID>()
            .HasOne(p => p.UrlIDEntity)
            .WithMany(b => b.ReportToUrlIDEntities)
            .HasForeignKey(p => p.UrlID)
            .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region UpdateScript
            modelBuilder.Entity<UpdateScript>()
                        .HasKey(b => new { b.Name, b.DateOfAppl });
            modelBuilder.Entity<UpdateScript>()
                        .Property(b => b.DateOfAppl)
                        .HasDefaultValueSql("getUtcDate()");
            #endregion

            #region AppValidation
            modelBuilder.Entity<AppValidation>()
                        .HasKey(b => new { b.ApplicationID, b.ValidationType });
            modelBuilder.Entity<AppValidation>()
                        .Property(b => b.ValidationDate)
                        .HasDefaultValueSql("getUtcDate()");
            #endregion

            #region Localization
            modelBuilder.Entity<Localization>()
                        .HasKey(b => new { b.ApplicationID, b.Culture, b.Key });
            #endregion

            #region UserConfiguration
            modelBuilder.Entity<UserConfiguration>(entity =>
            {
                entity.HasKey(b => new { b.ApplicationID, b.UserLogin });
                entity.Property(b => b.CondensedEquipmentParameters).IsRequired(true);
                entity.Property(b => b.CondensedEquipmentParameters).HasDefaultValue(false);
                entity.Property(b => b.EquipmentWsControlList).HasMaxLength(50);
                entity.Property(b => b.DeveloperMode).IsRequired(true);
                entity.Property(b => b.DeveloperMode).HasDefaultValue(false);
            });
            #endregion

            #region SystemTaskCompleted
            modelBuilder.Entity<SystemTaskCompleted>()
                        .HasKey(b => new { b.SysRowID });
            modelBuilder.Entity<SystemTaskCompleted>()
                        .Property(b => b.ContextParams)
                        .HasMaxLength(500);

            #endregion

            #region SystemTaskQueue
            modelBuilder.Entity<SystemTaskQueue>()
                         .HasKey(b => new { b.SysRowID });
            modelBuilder.Entity<SystemTaskQueue>()
                        .Property(b => b.SysRowID);
            modelBuilder.Entity<SystemTaskQueue>()
                        .Property(b => b.ContextParams)
                        .HasMaxLength(500);
            modelBuilder.Entity<SystemTaskCompleted>()
                        .Property(b => b.TaskLog)
                        .HasMaxLength(NVarCharMaxLength);
            #endregion

            #region Content
            modelBuilder.Entity<Content>()
                         .HasKey(b => new { b.ApplicationID, b.ContentType, b.ID });
            #endregion

            #region Message
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(b => new { b.ApplicationID, b.MessageType, b.ID });
                entity.Property(b => b.ID).HasMaxLength(15);
                entity.Property(b => b.MessageType).HasMaxLength(15);
                entity.Property(b => b.UserList).HasColumnType("nvarchar(max)");
                entity.Property(b => b.ArmNoList).HasColumnType("nvarchar(max)");
                entity.Property(b => b.RegNoList).HasColumnType("nvarchar(max)");
                entity.Property(b => b.Description).IsRequired(true);
                entity.Property(b => b.ShortDescription).IsRequired(true);
            });
            #endregion

            #region MessageStatus
            modelBuilder.Entity<MessageStatus>(entity =>
                {
                    entity.HasKey(b => new { b.ApplicationID, b.MessageType, b.ID, b.UserLogin });
                    entity.Property(b => b.ID).HasMaxLength(15);
                    entity.Property(b => b.MessageType).HasMaxLength(15);
                    entity.Property(b => b.Status).HasMaxLength(3);
                    entity.HasOne(b => b.MessageIDNavigation)
                          .WithMany(p => p.MessageStatus)
                          .HasForeignKey(b => new { b.ApplicationID, b.MessageType, b.ID })
                          .OnDelete(DeleteBehavior.Restrict)
                          .HasConstraintName("FK_MessageStatus_Message");
                });
            #endregion

            #region RecentVisitedPage
            modelBuilder.Entity<RecentVisitedPage>(entity =>
            {
                entity.HasKey(b => new { b.ApplicationID, b.Seq, b.UserLogin });
                entity.Property(b => b.Url).HasMaxLength(1000);
                entity.Property(b => b.Description).HasMaxLength(1000);
                entity.Property(b => b.Title).HasMaxLength(500);
                entity.Property(b => b.AddedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(b => b.Seq).ValueGeneratedOnAdd();
            });
            #endregion

            #region MessageStatus
            modelBuilder.Entity<FieldData>(entity =>
            {
                entity.HasKey(b => new { b.ApplicationID, b.TableName, b.FieldName, b.FormID });
                entity.Property(b => b.TableName).HasMaxLength(255);
                entity.Property(b => b.FieldName).HasMaxLength(255);
                entity.Property(b => b.Description).HasMaxLength(8000);
                entity.Property(b => b.Label).HasMaxLength(255);
                entity.Property(b => b.FormID)
                      .HasMaxLength(255)
                      .HasDefaultValue(string.Empty);
                entity.Property(b => b.Format)
                      .HasMaxLength(20)
                      .HasDefaultValue(string.Empty);
            });
            #endregion

            #region Customization
            modelBuilder.Entity<Customization>(entity =>
            {
                entity.HasKey(b => new { b.ApplicationID, b.UserLogin, b.CustomizationType, b.Key });
                entity.Property(b => b.Key).HasMaxLength(50);
                entity.Property(b => b.Content).HasMaxLength(8000);
                entity.Property(b => b.CustomizationType).HasMaxLength(20);
            });
            #endregion

            #region AssemblyStorage
            modelBuilder.Entity<AssemblyStorage>(entity =>
            {
                entity.HasKey(b => new { b.ApplicationID, b.AssemblyType, b.Key });
                entity.Property(b => b.Key).HasMaxLength(50);
                entity.Property(b => b.Content).HasMaxLength(8000);
                entity.Property(b => b.AssemblyType).HasMaxLength(20);
                entity.Property(b => b.StorageData).HasMaxLength(2_000_000);
                entity.Property(b => b.Hash).HasMaxLength(12);
            });
            #endregion
        }
    }
}
