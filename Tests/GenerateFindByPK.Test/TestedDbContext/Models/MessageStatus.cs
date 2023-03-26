using System;

namespace Admin.DB
{
    public class MessageStatus
    {
        public string ApplicationID { get; set; }
        public string MessageType { get; set; }
        public string ID { get; set; }
        public string UserLogin { get; set; }
        public string Status { get; set; }
        public DateTime Updated { get; set; }

        public virtual Message MessageIDNavigation { get; set; }
    }
}
