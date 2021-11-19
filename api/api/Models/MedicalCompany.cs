namespace api.Models
{
    public class MedicalCompany
    {
        public string Uuid { get; set; }
        public int Uid { get; set; }
        public int TerritoryUnitId { get; set; }
        public string CompanyId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public int? ContactPhoneName { get; set; }
        public string ContactEmail { get; set; }
    }
}