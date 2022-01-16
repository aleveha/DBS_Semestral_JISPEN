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
        
        public Template Add(Template inputTemplate) {
            Template databaseTemplate = new Template {
                title = inputTemplate.title,
                expiredAt = inputTemplate.expiredAt,
                userId = inputTemplate.userId,
                medicalCompanyId = inputTemplate.medicalCompany.id
            };
            _context.templates.Add(databaseTemplate);

            UpdateDatabaseLinks(databaseTemplate, inputTemplate);
            _context.SaveChanges();

            return Get(databaseTemplate.id);
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

        /// <summary>Set default includes to get whole linked object from database</summary>
        /// <param name="templates">collection of templates</param>
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

        /// <summary>Create a record in the reference table</summary>
        /// <param name="databaseTemplate">template entity from database</param>
        /// <param name="inputTemplate">template entity from input</param>
        private static void UpdateDatabaseLinks(Template databaseTemplate, Template inputTemplate) {
            foreach (LoadingCode loadingCode in inputTemplate.loadingCodes) {
                databaseTemplate.templateLoadingCodes.Add(
                new TemplateLoadingCode {
                    template = databaseTemplate,
                    loadingCode = loadingCode
                });
            }

            foreach (Waste waste in inputTemplate.wastes) {
                databaseTemplate.templateWastes.Add(
                new TemplateWaste {
                    template = databaseTemplate,
                    waste = waste
                });
            }
        }
    }
}
