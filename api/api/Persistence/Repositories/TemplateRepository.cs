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
            return SetIncludes(_context.templates.Where(template => template.user.id.Equals(userId)).OrderBy(template => template.id)).ToList();
        }

        public Template Get(long templateId) {
            return SetIncludes(_context.templates).OrderBy(temp => temp.id).SingleOrDefault(template => template.id.Equals(templateId));
        }

        public Template Add(Template template) {
            Template newTemplate = new Template {
                title = template.title,
                expiredAt = template.expiredAt,
                userId = template.userId,
                medicalCompanyId = template.medicalCompany.id
            };
            _context.templates.Add(newTemplate);

            UpdateLinks(newTemplate, template);
            _context.SaveChanges();

            return Get(newTemplate.id);
        }

        public bool Delete(long templateId) {
            Template template = SetIncludes(_context.templates)
                .Include(template => template.templateLoadingCodes)
                .Include(template => template.templateWastes)
                .OrderBy(temp => temp.id)
                .SingleOrDefault(template => template.id.Equals(templateId));

            if (template == null) {
                return false;
            }

            _context.templates.Remove(template);
            _context.SaveChanges();
            return !_context.templates.Any(t => t.id.Equals(templateId));
        }

        private static IQueryable<Template> SetIncludes(IQueryable<Template> templates) {
            return templates.Include(template => template.user)
                .Include(template => template.medicalCompany)
                .ThenInclude(comp => comp.address)
                .ThenInclude(ad => ad.zipcode)
                .Include(template => template.medicalCompany)
                .ThenInclude(comp => comp.territorialUnit)
                .Include(comp => comp.wastes)
                .Include(comp => comp.loadingCodes)
                .Include(comp => comp.wasteCompanies)
                .ThenInclude(wc => wc.address)
                .ThenInclude(ad => ad.zipcode)
                .Include(template => template.wasteCompanies)
                .ThenInclude(wc => wc.territorialUnit)
                .AsSplitQuery()
                .AsNoTracking();
        }

        public bool SameTemplateExists(long userId, string templateTitle) {
            return _context.templates.Any(template => template.user.id.Equals(userId) && template.title.Equals(templateTitle));
        }

        private static void UpdateLinks(Template newTemplate, Template oldTemplate) {
            foreach (LoadingCode loadingCode in oldTemplate.loadingCodes) {
                newTemplate.templateLoadingCodes.Add(
                new TemplateLoadingCode {
                    template = newTemplate,
                    loadingCode = loadingCode
                });
            }

            foreach (Waste waste in oldTemplate.wastes) {
                newTemplate.templateWastes.Add(
                new TemplateWaste {
                    template = newTemplate,
                    waste = waste
                });
            }
        }
    }
}
