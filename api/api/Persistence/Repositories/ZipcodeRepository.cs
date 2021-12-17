using System.Collections.Generic;
using System.Linq;
using api.Core.Repositories;
using api.Models;

namespace api.Persistence.Repositories {
    public class ZipcodeRepository : IZipcodeRepository {
        private readonly ApplicationContext _context;

        public ZipcodeRepository(ApplicationContext context) {
            _context = context;
        }

        public List<ZipCode> GetAll() {
            return _context.zipCodes.ToList();
        }
    }
}
