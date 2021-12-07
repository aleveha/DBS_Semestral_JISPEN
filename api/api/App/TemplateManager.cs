using System.Collections.Generic;
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

        public List<Template> GetAllTemplates(long userId) {
            return _templateRepository.GetAll(userId);
        }

        public Template Get(long templateId) {
            return _templateRepository.Get(templateId);
        }

        public Template Add(Template template) {
            return _templateRepository.Add(template);
        }

        public Template Update(Template template) {
            return _templateRepository.Update(template);
        }

        public bool Delete(Template template) {
            return _templateRepository.Delete(template);
        }
    }
}
