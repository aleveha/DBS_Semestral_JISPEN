using System;

namespace api.Models
{
    public class Record
    {
        public Template Template { get; set; }
        public DateTime Date { get; set; }
        public Waste Waste { get; set; }
        public float Amount { get; set; }
        public LoadingCode LoadingCode { get; set; }
        public WasteManagementCompany WasteManagementCompany { get; set; }
    }
}