using System.Collections.Generic;
using api.Models;

namespace api.Core.Repositories {
    public interface ITerritorialUnitRepository {
        List<TerritorialUnit> GetAll();
    }
}
