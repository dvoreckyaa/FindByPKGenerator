namespace Admin.DB
{
    public class SystemTaskCompleted
    {
        public Guid SysRowID { get; set; }
        public string ApplicationID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string UserName { get; set; }
        public string UserFIO { get; set; }
        public string TaskType { get; set; }
        public string TaskParams { get; set; }
        public int TaskResult { get; set; }
        public string ErrorText { get; set; }
        public string TaskNote { get; set; }
        public string TaskLog { get; set; }
        public bool TaskLogExists { get; set; }
        public string ContextParams { get; set; }
        public int? TaskProgress { get; set; }
    }
}
