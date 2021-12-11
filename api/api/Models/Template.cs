using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models {
    public class Template {
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

        public virtual List<Waste> wastes { get; set; } = new List<Waste>();

        [JsonIgnore]
        public virtual List<TemplateWaste> templateWastes { get; set; } = new List<TemplateWaste>();

        public virtual List<LoadingCode> loadingCodes { get; set; } = new List<LoadingCode>();

        [JsonIgnore]
        public virtual List<TemplateLoadingCode> templateLoadingCodes { get; set; } = new List<TemplateLoadingCode>();

        public virtual List<WasteCompany> wasteCompanies { get; set; } = new List<WasteCompany>();
    }
}
