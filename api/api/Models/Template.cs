using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models {
    public class Template {
        [Key]
        public long id { get; set; }

        public string title { get; set; }

        [Column("expired_at")]
        public long? expiredAt { get; set; }

        [Column("user_id")]
        public long userId { get; set; }

        public User user { get; set; }

        [Column("medical_company_id")]
        public long medicalCompanyId { get; set; }

        public MedicalCompany medicalCompany { get; set; }
    }
}
