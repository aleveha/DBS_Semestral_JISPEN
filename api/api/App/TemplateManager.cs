using api.Core.Managers;
using api.Core.Repositories;
using api.Models;
using api.Persistence;
using api.Persistence.Repositories;

namespace api.App {
    public class TemplateManager : ITemplateManager {
        private readonly ITemplateRepository _templateRepository;

        public TemplateManager(ApplicationContext context) {
            _templateRepository = new TemplateRepository(context);
        }

        public Template GetAllTemplates(string email) {
            return _templateRepository.GetAllTemplates(email);
        }
    }
}
