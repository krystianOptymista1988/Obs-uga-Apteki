using Obsługa_Apteki.EntitityFramework.Configurations;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Modele.Configurations;
using System;
using System.Data.Entity;
using System.Linq;

namespace Obsługa_Apteki.Entities
{
    public class AptekaTestDbContext : DbContext
    {
      
        public AptekaTestDbContext()
            : base("name=AptekaTestDbContext.cs")
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Reciept> Reciepts{ get;set; }

        public DbSet<Delivery> Delivery { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Pharmaceut> Pharmaceuts { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<ExpiredDate> ExpiredDates { get; set; }

        public DbSet<QuantityOnMagazine> QuantitiesOnMagazine { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DeliveryConfiguration());
            modelBuilder.Configurations.Add(new MedicineConfiguration());
            modelBuilder.Configurations.Add(new DoctorConfiguration());
            modelBuilder.Configurations.Add(new ReicieptConfiguration());
            modelBuilder.Configurations.Add(new PatientConfiguration());
            modelBuilder.Configurations.Add(new PharmaceutConfiguration());
            modelBuilder.Configurations.Add(new BillConfiguration());
            modelBuilder.Configurations.Add(new ExpiredDateConfiguration());
            modelBuilder.Configurations.Add(new QuantityOnMagazineConfiguration());
           
            
        }

    }

}