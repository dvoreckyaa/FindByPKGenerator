using System;

namespace Admin.DB
{
    public class AppValidation
    {
        public string ApplicationID { get; set; }
        public string ValidationType { get; set; }
        public bool ValidationStatus { get; set; }
        public string ValidationText { get; set; }
        public string ValidationObject { get; set; }
        public DateTime ValidationDate { get; set; }
    }
}
