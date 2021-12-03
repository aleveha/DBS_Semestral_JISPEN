using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Persistence {
    public class ApplicationContext : DbContext {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Address> addresses { get; set; }
        public DbSet<LoadingCode> loadingCodes { get; set; }
        public DbSet<MedicalCompany> medicalCompanies { get; set; }
        public DbSet<Record> records { get; set; }
        public DbSet<Template> templates { get; set; }
        public DbSet<TerritorialUnit> territorialUnits { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Waste> wastes { get; set; }
        public DbSet<WasteCompany> wasteCompanies { get; set; }
        public DbSet<ZipCode> zipCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Address>().ToTable("address");
            modelBuilder.Entity<LoadingCode>().ToTable("loading_code");
            modelBuilder.Entity<MedicalCompany>().ToTable("medical_company");
            modelBuilder.Entity<Record>().ToTable("record");
            modelBuilder.Entity<Template>().ToTable("template");
            modelBuilder.Entity<TerritorialUnit>().ToTable("territorial_unit");
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Waste>().ToTable("waste");
            modelBuilder.Entity<WasteCompany>().ToTable("waste_company");
            modelBuilder.Entity<ZipCode>().ToTable("zip_code");
        }
    }
}
