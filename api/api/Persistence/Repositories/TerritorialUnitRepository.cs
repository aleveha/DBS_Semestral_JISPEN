using System.Collections.Generic;
using System.Linq;
using api.Core.Repositories;
using api.Models;

namespace api.Persistence.Repositories {
    public class TerritorialUnitRepository : ITerritorialUnitRepository {
        private readonly ApplicationContext _context;

        public TerritorialUnitRepository(ApplicationContext context) {
            _context = context;
        }

        public List<TerritorialUnit> GetAll() {
            return _context.territorialUnits.ToList();
        }
    }
}
