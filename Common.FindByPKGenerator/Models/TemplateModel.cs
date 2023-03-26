namespace Common.FindByPKGenerator.Models
{
    public class TemplateModel
    {
        public string DbNamespace { get; set; }
        public string ContextName { get; set; }
        public IList<EntityModel> EntityModels { get; set; } = new List<EntityModel>();
    }
}
