using api.Models;

namespace api.Core.Repositories {
    public interface IAddressRepository {
        Address Get(long id);
        Address Add(Address address);
    }
}
