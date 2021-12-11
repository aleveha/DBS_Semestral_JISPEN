using System.Collections.Generic;
using api.Models;

namespace api.Core.Repositories {
    public interface ITemplateRepository {
        List<Template> GetAll(long userId);
        Template Get(long templateId);
        Template Add(Template template);
        bool Delete(long templateId);
        bool SameTemplateExists(long userId, string templateTitle);
    }
}
