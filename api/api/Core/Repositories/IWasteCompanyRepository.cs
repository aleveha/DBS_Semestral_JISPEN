using System.Collections.Generic;
using api.Models;

namespace api.Core.Repositories {
    public interface IWasteCompanyRepository {
        List<WasteCompany> Get(long templateId);
        List<WasteCompany> Add(List<WasteCompany> wasteCompany);
    }
}
