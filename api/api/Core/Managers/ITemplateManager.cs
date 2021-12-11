using System.Collections.Generic;
using api.Models;

namespace api.Core.Managers {
    public interface ITemplateManager {
        List<Template> GetAllTemplates(long userId);
        Template Get(long templateId);
        Template Add(Template template);
        bool Delete(long templateId);
    }
}
