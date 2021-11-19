namespace api.Models
{
    public class Address
    {
        public string Uid { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int RegistryNumber { get; set; }
        public int BuildingNumber { get; set; }
        public int Zipcode { get; set; }
    }
}