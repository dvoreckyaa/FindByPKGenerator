using System.Collections.Generic;

namespace Admin.DB
{
    public class Report
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string Sql { get; set; }
        public string Columns { get; set; }
        public string Tabs { get; set; }
        public bool Disabled { get; set; }
        public virtual List<ReportToUrlID> UrlIDEntities { get; set; }
        public int SequenceNum { get; set; }
    }

    public class ReportToUrlID
    {
        public string ReportID { get; set; }
        public string UrlID { get; set; }
        public virtual Report ReportEntity { get; set; }
        public virtual UrlID UrlIDEntity { get; set; }
    }

    public class UrlID
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }
        public virtual List<ReportToUrlID> ReportToUrlIDEntities { get; set; }
    }

}
