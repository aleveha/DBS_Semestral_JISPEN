using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models {
    public class MedicalCompany {
        public long id { get; set; }

        public int uid { get; set; }

        [Column("company_id")]
        public string companyId { get; set; }

        public string name { get; set; }

        [Column("territorial_unit_id")]
        public long territorialUnitId { get; set; }

        public TerritorialUnit territorialUnit { get; set; }

        [Column("address_id")]
        public long addressId { get; set; }

        public Address address { get; set; }

        [Column("contact_firstname")]
        public string contactFirstName { get; set; }

        [Column("contact_lastname")]
        public string contactLastName { get; set; }

        [Column("contact_phone")]
        public int? contactPhone { get; set; }

        [Column("contact_email")]
        public string contactEmail { get; set; }

        [Column("user_id")]
        public long userId { get; set; }
    }
}
