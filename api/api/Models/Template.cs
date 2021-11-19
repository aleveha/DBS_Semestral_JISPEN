namespace api.Models
{
    public class Template
    {
        public string Uuid { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
        public MedicalCompany MedicalCompany { get; set; }
        public long? ExpiredAt { get; set; }
    }
}