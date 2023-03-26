namespace Admin.DB
{
    public class SystemTaskQueue
    {
        public Guid SysRowID { get; set; }
        public string ApplicationID { get; set; }
        public DateTime StartDate { get; set; }
        public string UserName { get; set; }
        public string UserFIO { get; set; }
        public string TaskType { get; set; }
        public string TaskParams { get; set; }
        public string TaskNote { get; set; }
        public string ContextParams { get; set; }
    }
}
