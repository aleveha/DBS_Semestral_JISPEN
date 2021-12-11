using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models {
    public class User {
        public User(string email, string password) {
            this.email = email;
            this.password = password;
        }

        public User(string email, string password, string serviceCode) {
            this.email = email;
            this.password = password;
            this.serviceCode = serviceCode;
        }

        public User(string email, string password, long verifiedAt) {
            this.email = email;
            this.password = password;
            this.verifiedAt = verifiedAt;
        }

        public long id { get; set; }

        public string email { get; set; }
        public string password { get; set; }

        [Column("service_code")]
        public string serviceCode { get; set; }

        [Column("verified_at")]
        public long? verifiedAt { get; set; }
    }
}
