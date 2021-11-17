namespace api.Models
{
    public class MedicalCompany
    {
        public int Uid { get; set; }
        public int TerritoryUnitId { get; set; }
        public string CompanyId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public ContactPerson ContactPerson { get; set; }
    }
}