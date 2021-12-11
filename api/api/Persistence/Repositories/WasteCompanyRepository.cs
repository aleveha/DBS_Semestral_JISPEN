using System.Collections.Generic;
using System.Linq;
using api.Core.Repositories;
using api.Models;

namespace api.Persistence.Repositories {
    public class WasteCompanyRepository : IWasteCompanyRepository {
        private readonly ApplicationContext _context;

        public WasteCompanyRepository(ApplicationContext context) {
            _context = context;
        }

        public List<WasteCompany> Get(long templateId) {
            return _context.templates.Single(template => template.id.Equals(templateId)).wasteCompanies.ToList();
        }

        public List<WasteCompany> Add(List<WasteCompany> wasteCompanies) {
            _context.wasteCompanies.AddRange(wasteCompanies);
            _context.SaveChanges();
            return wasteCompanies.Select(wasteCompany => _context.wasteCompanies.Find(wasteCompany.id)).ToList();
        }
    }
}
