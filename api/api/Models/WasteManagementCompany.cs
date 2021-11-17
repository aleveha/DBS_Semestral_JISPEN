namespace api.Models
{
    public class WasteManagementCompany
    {
        public int Uid { get; set; }
        public int TerritoryUnitId { get; set; }
        public string CompanyId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public Address Address { get; set; }
    }
}