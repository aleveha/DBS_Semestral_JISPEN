using System.Linq;
using api.Core.Repositories;
using api.Models;

namespace api.Persistence.Repositories {
    public class AddressRepository : IAddressRepository {
        private readonly ApplicationContext _context;

        public AddressRepository(ApplicationContext context) {
            _context = context;
        }

        public Address Get(long id) {
            return _context.addresses.SingleOrDefault(ad => ad.id.Equals(id));
        }

        public Address Add(Address address) {
            Address newAddress = new Address {
                city = address.city,
                street = address.street,
                buildingNumber = address.buildingNumber,
                registryNumber = address.registryNumber,
                zipCodeId = address.zipcode.id
            };
            _context.addresses.Add(newAddress);
            _context.SaveChanges();
            return Get(newAddress.id);
        }
    }
}
