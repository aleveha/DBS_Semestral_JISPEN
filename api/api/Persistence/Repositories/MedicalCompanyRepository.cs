using System.Collections.Generic;
using System.Linq;
using api.Core.Repositories;
using api.Models;

namespace api.Persistence.Repositories {
    public class MedicalCompanyRepository : IMedicalCompanyRepository {
        private readonly ApplicationContext _context;

        public MedicalCompanyRepository(ApplicationContext context) {
            _context = context;
        }

        public MedicalCompany Get(long id) {
            return _context.medicalCompanies.SingleOrDefault(mc => mc.id.Equals(id));
        }

        public List<MedicalCompany> GetByUserId(long userId) {
            return _context.medicalCompanies.Where(medicalCompany => medicalCompany.userId.Equals(userId)).ToList();
        }

        public MedicalCompany Add(MedicalCompany medicalCompany) {
            MedicalCompany existingCompany = GetByUserId(medicalCompany.userId)
                .Find(mc => mc.uid.Equals(medicalCompany.uid) && mc.companyId.Equals(medicalCompany.companyId));

            if (existingCompany != null) {
                return existingCompany;
            }

            MedicalCompany newMedicalCompany = new MedicalCompany {
                uid = medicalCompany.uid,
                companyId = medicalCompany.companyId,
                territorialUnitId = medicalCompany.territorialUnit.id,
                name = medicalCompany.name,
                addressId = medicalCompany.address.id,
                contactFirstName = medicalCompany.contactFirstName,
                contactLastName = medicalCompany.contactLastName,
                contactPhone = medicalCompany.contactPhone,
                contactEmail = medicalCompany.contactEmail,
                userId = medicalCompany.userId
            };
            _context.medicalCompanies.Add(newMedicalCompany);
            _context.SaveChanges();
            return Get(newMedicalCompany.id);
        }
    }
}
