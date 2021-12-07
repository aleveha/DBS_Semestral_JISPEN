using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models {
    public class Record {
        
        public long id { get; set; }

        public float amount { get; set; }
        public DateTime date { get; set; }

        [Column("template_id")]
        public long templateId { get; set; }

        public Template template { get; set; }

        [Column("waste_id")]
        public long wasteId { get; set; }

        public Waste waste { get; set; }

        [Column("loading_code_id")]
        public long loadingCodeId { get; set; }

        public LoadingCode loadingCode { get; set; }

        [Column("waste_company_id")]
        public long wasteCompanyId { get; set; }

        public WasteCompany wasteCompany { get; set; }
    }
}
