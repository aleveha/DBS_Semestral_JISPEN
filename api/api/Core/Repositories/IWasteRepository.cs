using System.Collections.Generic;
using api.Models;

namespace api.Core.Repositories {
    public interface IWasteRepository {
        List<Waste> GetAll();
    }
}
