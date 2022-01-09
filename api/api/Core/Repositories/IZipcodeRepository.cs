using System.Collections.Generic;
using api.Models;

namespace api.Core.Repositories {
    public interface IZipcodeRepository {
        List<ZipCode> GetAll();
    }
}
