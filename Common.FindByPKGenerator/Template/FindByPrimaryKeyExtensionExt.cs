using Common.FindByPKGenerator.Models;

namespace Common.FindByPKGenerator.Template
{
    public partial class FindByPrimaryKeyExtension
    {
        public TemplateModel TemplateModel { get; private set; }
        public virtual string TransformText(TemplateModel templateModel)
        {
            this.TemplateModel = templateModel;
            return this.TransformText().Trim();
        }
    }
}
