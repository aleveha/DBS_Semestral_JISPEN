using System.Collections.Generic;
using System.Linq;
using api.Core.Repositories;
using api.Models;

namespace api.Persistence.Repositories {
    public class WasteRepository : IWasteRepository {
        private readonly ApplicationContext _context;

        public WasteRepository(ApplicationContext context) {
            _context = context;
        }

        public List<Waste> GetAll() {
            return _context.wastes.ToList();
        }
    }
}
