namespace Admin.DB
{
    public class UserData
    {
        public string UserLogin { get; set; }
        public string UserAgent { get; set; }
        public string UserResolvedAgent { get; set; }
        public string UserOS { get; set; }
        public string ApplicationID { get; set; }
        public string ClientID { get; set; }
        public double? UserTimeZone { get; set; }
        public string ClientAddress { get; set; }
        public DateTime LastSignedIn { get; set; }
        public DateTime? LastActivity { get; set; }
    }
}
