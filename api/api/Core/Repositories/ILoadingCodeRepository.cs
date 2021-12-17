using System.Collections.Generic;
using api.Models;

namespace api.Core.Repositories {
    public interface ILoadingCodeRepository {
        List<LoadingCode> GetAll();
    }
}
