using api.Models;

namespace api.Core.Repositories {
    public interface IMedicalCompanyRepository {
        MedicalCompany Get(long id);
        MedicalCompany Add(MedicalCompany medicalCompany);
    }
}
