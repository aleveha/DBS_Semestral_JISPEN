using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api.Models {
    public class Waste {
        public long id { get; set; }
        public long uid { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string certificate { get; set; }

        [JsonIgnore]
        public virtual List<Template> templates { get; set; } = new List<Template>();

        [JsonIgnore]
        public virtual List<TemplateWaste> templateWastes { get; set; } = new List<TemplateWaste>();
    }
}
