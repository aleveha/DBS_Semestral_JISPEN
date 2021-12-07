using System.Collections.Generic;
using api.Models;

namespace api.Core.Repositories {
    public interface ITemplateRepository {
        List<Template> GetAll(long userId);
        Template Get(long templateId);
        Template Add(Template template);
        Template Update(Template template);
        bool Delete(Template template);
    }
}
