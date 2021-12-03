using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Waste
    {
        [Key]
        public long id { get; set; }
        public string uid { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string certificate { get; set; }
    }
}