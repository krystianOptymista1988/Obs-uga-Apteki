using System.Data.Entity;

namespace Obsługa_Apteki.Entities
{
    public class AptekaDbContext : DbContext
    {


        public DbSet<Patient> Patients { get; set; }

        public DbSet<Pharmaceut> Pharmaceuts { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Reciept> Reciepts { get; set; }
        public DbSet<Doctor> Doctors { get; set; }




        public AptekaDbContext() : base("name=AptekaContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.PatientId);

            modelBuilder.Entity<Pharmaceut>()
                .HasKey(c => c.PharmaceutId);

            modelBuilder.Entity<Delivery>()
                .HasKey(d => d.DeliveryId);

            modelBuilder.Entity<Medicine>()
                .HasKey(m => m.MedicineId);
            modelBuilder.Entity<Reciept>()
                .HasKey(r => r.RecieptId);
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.DoctorId);
        }
        public void TablesCheck()
        {
            {
                using (var context = this)
                {

                    context.Database.ExecuteSqlCommand(@"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Patients')
                    BEGIN
                        CREATE TABLE Patients (
                            PatientId INT PRIMARY KEY IDENTITY,
                            Name NVARCHAR(100),
                            Surname NVARCHAR(100),
                            DateOfBirth DATETIME,
                            PESEL NVARCHAR(20),
                            Mobile NVARCHAR(20),
                            Adress NVARCHAR(200),
                            PostalCode NVARCHAR(20),
                            Comment NVARCHAR(MAX)
                        )
                    END
                ");


                    context.Database.ExecuteSqlCommand(@"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Pharmaceuts')
                    BEGIN
                        CREATE TABLE Pharmaceuts (
                            PharmaceutId INT PRIMARY KEY IDENTITY,
                            Name NVARCHAR(100),
                            Surname NVARCHAR(100),
                            DateOfBirth DATETIME,
                            PESEL NVARCHAR(20),
                            Mobile NVARCHAR(20),
                            Adress NVARCHAR(200),
                            PostalCode NVARCHAR(20),
                            Salary INT,
                            DateOfHire DATETIME
                        )
                    END
                ");


                    context.Database.ExecuteSqlCommand(@"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Deliveries')
                    BEGIN
                        CREATE TABLE Deliveries (
                            DeliveryId INT PRIMARY KEY IDENTITY,
                            DateOfDelivery DATETIME,
                            DateOfCreate DATETIME,
                            Value FLOAT,
                            PharmaceutId INT
                        )
                    END
                ");


                    context.Database.ExecuteSqlCommand(@"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Medicines')
                    BEGIN
                        CREATE TABLE Medicines (
                            MedicineId INT PRIMARY KEY IDENTITY,
                            Name NVARCHAR(100),
                            Category NVARCHAR(100),
                            Producent NVARCHAR(100),
                            ExpiredDate DATETIME,
                            PriceOfBuy FLOAT,
                            PriceOfSell FLOAT,
                            PriceMarge FLOAT,
                            QuantityInPackage INT,
                            QuantityOfPackages INT,
                            IsRefunded BIT,
                            PercentageOfRefunding FLOAT,
                            PriceAfterRefunding FLOAT,
                            ActiveSubstance NVARCHAR(100),
                            IsAntibiotique BIT,
                            IsOnReciept BIT
                        )
                    END
                ");


                    context.Database.ExecuteSqlCommand(@"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Reciepts')
                    BEGIN
                        CREATE TABLE Reciepts (
                            RecieptId INT PRIMARY KEY IDENTITY,
                            PatientId INT,
                            DateOfRegistry DATETIME,
                            DateOfExpire DATETIME
                        )
                    END
                ");


                    context.Database.ExecuteSqlCommand(@"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Doctors')
                    BEGIN
                        CREATE TABLE Doctors (
                            DoctorId INT PRIMARY KEY IDENTITY,
                            Name NVARCHAR(100),
                            Surname NVARCHAR(100),
                            DateOfBirth DATETIME,
                            PESEL NVARCHAR(20),
                            Mobile NVARCHAR(20),
                            Adress NVARCHAR(200),
                            PostalCode NVARCHAR(20)
                        )
                    END
                ");
                }
            }
        }
    }
}
