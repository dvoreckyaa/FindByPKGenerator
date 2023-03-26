using System;

namespace Admin.DB
{
    public class UpdateScript
    {
        public string Name { get; set; }
        public DateTime DateOfAppl { get; set; }
        public Int64 DataBaseVersion { get; set; }
        public Int64 ScriptVersion { get; set; }
        public string ErrorText { get; set; }
    }
}
