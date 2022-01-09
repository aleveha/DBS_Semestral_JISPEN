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
            modelBuilder.Entity<TerritorialUnit>().ToTable("territorial_unit");
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Waste>().ToTable("waste");
            modelBuilder.Entity<WasteCompany>().ToTable("waste_company");
            modelBuilder.Entity<ZipCode>().ToTable("zip_code");
            modelBuilder.Entity<Template>()
                .ToTable("template")
                // MANY-TO-MANY WASTE
                .HasMany(t => t.wastes)
                .WithMany(w => w.templates)
                .UsingEntity<TemplateWaste>(
                e => e.HasOne(tw => tw.waste).WithMany(w => w.templateWastes).HasForeignKey(tw => tw.wasteId),
                e => e.HasOne(tw => tw.template).WithMany(t => t.templateWastes).HasForeignKey(tw => tw.templateId),
                e => {
                    e.ToTable("template_waste");
                    e.HasKey(tw => tw.id);
                })
                // MANY-TO-MANY LOADING CODES
                .HasMany(t => t.loadingCodes)
                .WithMany(l => l.templates)
                .UsingEntity<TemplateLoadingCode>(
                e => e.HasOne(tlc => tlc.loadingCode).WithMany(lc => lc.templateLoadingCodes).HasForeignKey(tlc => tlc.loadingCodeId),
                e => e.HasOne(tlc => tlc.template).WithMany(t => t.templateLoadingCodes).HasForeignKey(tlc => tlc.templateId),
                e => {
                    e.ToTable("template_loading_code");
                    e.HasKey(tlc => tlc.id);
                });
        }
    }
}
