using System;
using System.Collections.Generic;

namespace Admin.DB
{
    public class Message
    {
        public Message()
        {
            MessageStatus = new HashSet<MessageStatus>();
        }

        public string ApplicationID { get; set; }
        public string MessageType { get; set; }
        public string ID { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserList { get; set; }
        public string ArmNoList { get; set; }
        public string RegNoList { get; set; }
        public virtual ICollection<MessageStatus> MessageStatus { get; set; }
    }
}
