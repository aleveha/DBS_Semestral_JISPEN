using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models {
    public class TemplateWaste {
        public long id { get; set; }

        [Column("template_id")]
        public long templateId { get; set; }

        public Template template { get; set; }

        [Column("waste_id")]
        public long wasteId { get; set; }

        public Waste waste { get; set; }
    }
}
