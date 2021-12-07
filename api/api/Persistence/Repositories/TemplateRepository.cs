using System.Collections.Generic;
using System.Linq;
using api.Core.Repositories;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Persistence.Repositories {
    public class TemplateRepository : ITemplateRepository {
        private readonly ApplicationContext _context;

        public TemplateRepository(ApplicationContext context) {
            _context = context;
        }

        public List<Template> GetAll(long userId) {
            return !UserHasTemplate(userId)
                ? new List<Template>()
                : _context.templates.Where(template => template.user.id.Equals(userId)).OrderBy(template => template.id)
                    .Include(template => template.user).Include(template => template.medicalCompany).ThenInclude(comp => comp.address)
                    .Include(template => template.medicalCompany).ThenInclude(comp => comp.address.zipcode)
                    .Include(template => template.medicalCompany).ThenInclude(comp => comp.territorialUnit).ToList();
        }

        public Template Get(long templateId) {
            return TemplateExists(templateId)
                ? _context.templates.Include(template => template.user).Include(template => template.medicalCompany).ThenInclude(comp => comp.address)
                    .Include(template => template.medicalCompany).ThenInclude(comp => comp.address.zipcode)
                    .Include(template => template.medicalCompany).ThenInclude(comp => comp.territorialUnit)
                    .SingleOrDefault(template => template.id.Equals(templateId))
                : null;
        }

        public Template Add(Template template) {
            _context.templates.Add(template);
            _context.SaveChanges();
            return Get(template.id);
        }

        public Template Update(Template template) {
            _context.templates.Update(template);
            _context.SaveChanges();
            return Get(template.id);
        }

        public bool Delete(Template template) {
            _context.templates.Remove(template);
            _context.SaveChanges();
            return !TemplateExists(template.id);
        }

        private bool UserHasTemplate(long userId) {
            return _context.templates.Any(template => template.user.id.Equals(userId));
        }

        private bool TemplateExists(long templateId) {
            return _context.templates.Any(template => template.id.Equals(templateId));
        }
    }
}
