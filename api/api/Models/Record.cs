using System;

namespace api.Models
{
    public class Record
    {
        public Waste Waste { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public LoadingCode LoadingCode { get; set; }
        public MedicalCompany MedicalCompany { get; set; }
        public WasteManagementCompany WasteManagementCompany { get; set; }
    }
}