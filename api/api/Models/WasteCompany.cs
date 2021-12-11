using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models {
    public class WasteCompany {
        public long id { get; set; }

        public int uid { get; set; }

        [Column("company_id")]
        public string companyId { get; set; }

        public string name { get; set; }
        public int type { get; set; }

        [Column("expired_at")]
        public long? expiredAt { get; set; }

        [Column("territorial_unit_id")]
        public long territorialUnitId { get; set; }

        public TerritorialUnit territorialUnit { get; set; }

        [Column("address_id")]
        public long addressId { get; set; }

        public Address address { get; set; }

        [Column("template_id")]
        public long templateId { get; set; }

        [JsonIgnore]
        public virtual Template template { get; set; }
    }
}
