using System.Collections.Generic;
using api.Core.Managers;
using api.Core.Repositories;
using api.Models;
using api.Persistence;
using api.Persistence.Repositories;

namespace api.App {
    public class TemplateManager : ITemplateManager {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMedicalCompanyRepository _medicalCompanyRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IWasteCompanyRepository _wasteCompanyRepository;

        public TemplateManager(ApplicationContext context) {
            _templateRepository = new TemplateRepository(context);
            _medicalCompanyRepository = new MedicalCompanyRepository(context);
            _addressRepository = new AddressRepository(context);
            _wasteCompanyRepository = new WasteCompanyRepository(context);
        }

        public List<Template> GetAllTemplates(long userId) {
            return _templateRepository.GetAll(userId);
        }

        public Template Get(long templateId) {
            return _templateRepository.Get(templateId);
        }

        public Template Add(Template template) {
            if (_templateRepository.SameTemplateExists(template.userId, template.title)) {
                return null;
            }

            MedicalCompany medicalCompany = template.medicalCompany;
            medicalCompany.address = _addressRepository.Add(medicalCompany.address);
            template.medicalCompany = _medicalCompanyRepository.Add(medicalCompany);
            Template savedTemplate = _templateRepository.Add(template);
            savedTemplate.wasteCompanies = template.wasteCompanies;
            savedTemplate.wasteCompanies.ForEach(wc => wc.templateId = savedTemplate.id);
            savedTemplate.wasteCompanies = _wasteCompanyRepository.Add(savedTemplate.wasteCompanies);
            return Get(savedTemplate.id);
        }

        public bool Delete(long templateId) {
            return _templateRepository.Delete(templateId);
        }
    }
}
