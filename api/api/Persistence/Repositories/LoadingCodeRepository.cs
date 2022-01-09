using System.Collections.Generic;
using System.Linq;
using api.Core.Repositories;
using api.Models;

namespace api.Persistence.Repositories {
    public class LoadingCodeRepository : ILoadingCodeRepository {
        private readonly ApplicationContext _context;

        public LoadingCodeRepository(ApplicationContext context) {
            _context = context;
        }

        public List<LoadingCode> GetAll() {
            return _context.loadingCodes.ToList();
        }
    }
}
