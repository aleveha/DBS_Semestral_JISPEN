using api.Core.Repositories;
using api.Models;

namespace api.Persistence.Repositories {
    public class TemplateRepository : ITemplateRepository {
        private readonly ApplicationContext _context;

        public TemplateRepository(ApplicationContext context) {
            _context = context;
        }

        public Template GetAllTemplates(string email) {
            return new Template();
        }
    }
}
