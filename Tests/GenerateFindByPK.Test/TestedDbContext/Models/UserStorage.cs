using System;

namespace Admin.DB
{
    public class UserStorage
    {
        public string UserLogin { get; set; }
        public string Key { get; set; }
        public string DataType { get; set; }
        public string StrValue { get; set; }
        public int? IntValue { get; set; }
        public DateTime? DateValue { get; set; }
        public double? FloatValue { get; set; }
    }
}
