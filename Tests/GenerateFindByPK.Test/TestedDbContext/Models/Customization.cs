using System;

namespace Admin.DB
{
    public class Customization
    {
        public string UserLogin { get; set; }
        public string ApplicationID { get; set; }
        public string CustomizationType { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }
        public DateTime ChangedOn { get; set; }
    }
}
