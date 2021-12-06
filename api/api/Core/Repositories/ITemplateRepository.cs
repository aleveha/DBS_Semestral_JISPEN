using api.Models;

namespace api.Core.Repositories {
    public interface ITemplateRepository {
        Template GetAllTemplates(string email);
    }
}
