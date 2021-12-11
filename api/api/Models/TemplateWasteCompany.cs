using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models {
    public class TemplateWasteCompany {
        public long id { get; set; }

        [Column("template_id")]
        public long templateId { get; set; }

        public Template template { get; set; }

        [Column("waste_company_id")]
        public long wasteCompanyId { get; set; }

        public WasteCompany wasteCompany { get; set; }
    }
}
