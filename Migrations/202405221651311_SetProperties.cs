namespace Obsługa_Apteki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PESEL = c.String(),
                        Mobile = c.String(),
                        Adress = c.String(),
                        PostalCode = c.String(),
                        Medicine_MedicineId = c.Int(),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Medicines", t => t.Medicine_MedicineId)
                .Index(t => t.Medicine_MedicineId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Producent = c.String(),
                        ExpiredDate = c.DateTime(nullable: false),
                        PriceOfSell = c.Double(nullable: false),
                        QuantityInPackage = c.Int(nullable: false),
                        QuantityOfPackages = c.Int(nullable: false),
                        IsRefunded = c.Boolean(nullable: false),
                        PercentageOfRefunding = c.Double(),
                        PriceAfterRefunding = c.Double(),
                        ActiveSubstance = c.String(),
                        IsAntibiotique = c.Boolean(nullable: false),
                        IsOnReciept = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false, identity: true),
                        DateOfDelivery = c.DateTime(nullable: false, storeType: "date"),
                        DateOfCreate = c.DateTime(nullable: false),
                        PharmaceutOrdering = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryId);
            
            CreateTable(
                "dbo.Reciepts",
                c => new
                    {
                        RecieptId = c.Int(nullable: false, identity: true),
                        DateOfRegistry = c.DateTime(nullable: false),
                        DateOfExpire = c.DateTime(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecieptId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        PharmaceutId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                        PESEL = c.String(),
                        Mobile = c.String(maxLength: 15),
                        Adress = c.String(maxLength: 100),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Pharmaceuts", t => t.PharmaceutId)
                .Index(t => t.PharmaceutId);
            
            CreateTable(
                "dbo.Pharmaceuts",
                c => new
                    {
                        PharmaceutId = c.Int(nullable: false, identity: true),
                        DateOfHire = c.DateTime(nullable: false, storeType: "date"),
                        Name = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                        PESEL = c.String(),
                        Mobile = c.String(maxLength: 15),
                        Adress = c.String(maxLength: 100),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.PharmaceutId);
            
            CreateTable(
                "dbo.MedicineDeliveries",
                c => new
                    {
                        MedicineId = c.Int(nullable: false),
                        DeliveryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MedicineId, t.DeliveryId })
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .ForeignKey("dbo.Deliveries", t => t.DeliveryId, cascadeDelete: true)
                .Index(t => t.MedicineId)
                .Index(t => t.DeliveryId);
            
            CreateTable(
                "dbo.RecieptMedicines",
                c => new
                    {
                        Reciept_RecieptId = c.Int(nullable: false),
                        Medicine_MedicineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reciept_RecieptId, t.Medicine_MedicineId })
                .ForeignKey("dbo.Reciepts", t => t.Reciept_RecieptId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.Medicine_MedicineId, cascadeDelete: true)
                .Index(t => t.Reciept_RecieptId)
                .Index(t => t.Medicine_MedicineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reciepts", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "PharmaceutId", "dbo.Pharmaceuts");
            DropForeignKey("dbo.RecieptMedicines", "Medicine_MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.RecieptMedicines", "Reciept_RecieptId", "dbo.Reciepts");
            DropForeignKey("dbo.Reciepts", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "Medicine_MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.MedicineDeliveries", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.MedicineDeliveries", "MedicineId", "dbo.Medicines");
            DropIndex("dbo.RecieptMedicines", new[] { "Medicine_MedicineId" });
            DropIndex("dbo.RecieptMedicines", new[] { "Reciept_RecieptId" });
            DropIndex("dbo.MedicineDeliveries", new[] { "DeliveryId" });
            DropIndex("dbo.MedicineDeliveries", new[] { "MedicineId" });
            DropIndex("dbo.Patients", new[] { "PharmaceutId" });
            DropIndex("dbo.Reciepts", new[] { "PatientId" });
            DropIndex("dbo.Reciepts", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "Medicine_MedicineId" });
            DropTable("dbo.RecieptMedicines");
            DropTable("dbo.MedicineDeliveries");
            DropTable("dbo.Pharmaceuts");
            DropTable("dbo.Patients");
            DropTable("dbo.Reciepts");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Medicines");
            DropTable("dbo.Doctors");
        }
    }
}
