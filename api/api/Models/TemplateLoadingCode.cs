using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models {
    public class TemplateLoadingCode {
        public long id { get; set; }

        [Column("template_id")]
        public long templateId { get; set; }

        public Template template { get; set; }

        [Column("loading_code_id")]
        public long loadingCodeId { get; set; }

        public LoadingCode loadingCode { get; set; }
    }
}
