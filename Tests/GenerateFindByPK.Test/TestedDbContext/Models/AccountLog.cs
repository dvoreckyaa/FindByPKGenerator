using System;

namespace Admin.DB
{
    public class AccountLogPartial
    {
        public string LogType { get; set; }
        public DateTime EventDate { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string LogText { get; set; }
        public string ApplicationID { get; set; }
    }

    public class AccountLog : AccountLogPartial
    {
        public int Seq { get; set; }
        public DateTime LogDate { get; set; }
        public string SessionID { get; set; }
        public string ServerName { get; set; }
        public string ServerAddress { get; set; }
        public string Agent { get; set; }
        public string ResolvedAgent { get; set; }
        public string OS { get; set; }
        public string ClientAddress { get; set; }
        public string AppType { get; set; }
        public double? UserTimeZone { get; set; }
        public double? ServerTimeZone { get; set; }
    }
}
