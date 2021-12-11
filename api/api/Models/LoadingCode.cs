using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api.Models {
    public class LoadingCode {
        public long id { get; set; }

        public string uid { get; set; }
        public string name { get; set; }

        [JsonIgnore]
        public virtual List<Template> templates { get; set; } = new List<Template>();

        [JsonIgnore]
        public virtual List<TemplateLoadingCode> templateLoadingCodes { get; set; } = new List<TemplateLoadingCode>();
    }
}
