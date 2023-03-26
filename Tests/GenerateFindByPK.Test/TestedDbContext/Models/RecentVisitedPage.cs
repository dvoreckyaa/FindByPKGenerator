using System;

namespace Admin.DB
{
    public class RecentVisitedPage
    {
        public string ApplicationID { get; set; }
        public string UserLogin { get; set; }
        public DateTime AddedDate { get; set; }
        public int Seq { get; set; }
        public string Url { get; set; }
        public string QueryParams { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
