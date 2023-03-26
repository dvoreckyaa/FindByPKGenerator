using System;

namespace Admin.DB
{
    public class AssemblyStorage
    {
        public string ApplicationID { get; set; }
        public string AssemblyType { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }
        public DateTime ChangedOn { get; set; }
        public string Hash { get; set; }
        public byte[] StorageData { get; set; }
    }
}
