using api.Models;

namespace api.Core.Managers {
    public interface ITemplateManager {
        Template GetAllTemplates(string email);
    }
}
