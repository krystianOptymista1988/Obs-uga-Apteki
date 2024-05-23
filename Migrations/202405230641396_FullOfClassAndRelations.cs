namespace Obsługa_Apteki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullOfClassAndRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        DatoOfBill = c.DateTime(nullable: false),
                        BillPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Producent = c.String(),
                        PriceOfSell = c.Double(nullable: false),
                        QuantityInPackage = c.Int(nullable: false),
                        IsRefunded = c.Boolean(nullable: false),
                        PercentageOfRefunding = c.Double(),
                        PriceAfterRefunding = c.Double(),
                        ActiveSubstance = c.String(),
                        IsAntibiotique = c.Boolean(nullable: false),
                        IsOnReciept = c.Boolean(nullable: false),
                        Bill_BillId = c.Int(),
                    })
                .PrimaryKey(t => t.MedicineId)
                .ForeignKey("dbo.Bills", t => t.Bill_BillId)
                .Index(t => t.Bill_BillId);
            
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
                "dbo.ExpiredDates",
                c => new
                    {
                        ExpiredDateId = c.Int(nullable: false, identity: true),
                        DateofExpire = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ExpiredDateId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                        PESEL = c.String(),
                        Mobile = c.String(maxLength: 15),
                        Adress = c.String(maxLength: 100),
                        PostalCode = c.String(),
                        Medicine_MedicineId = c.Int(),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Medicines", t => t.Medicine_MedicineId)
                .Index(t => t.Medicine_MedicineId);
            
            CreateTable(
                "dbo.QuantitiesOnMagazine",
                c => new
                    {
                        QuantityAddId = c.Int(nullable: false, identity: true),
                        Quantities = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuantityAddId);
            
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
                "dbo.ExpiredDateTables",
                c => new
                    {
                        ExpiredDateID = c.Int(nullable: false),
                        DeliveryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExpiredDateID, t.DeliveryId })
                .ForeignKey("dbo.ExpiredDates", t => t.ExpiredDateID, cascadeDelete: true)
                .ForeignKey("dbo.Deliveries", t => t.DeliveryId, cascadeDelete: true)
                .Index(t => t.ExpiredDateID)
                .Index(t => t.DeliveryId);
            
            CreateTable(
                "dbo.ExpiredDateMedicines",
                c => new
                    {
                        ExpiredDateId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExpiredDateId, t.MedicineId })
                .ForeignKey("dbo.ExpiredDates", t => t.ExpiredDateId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.ExpiredDateId)
                .Index(t => t.MedicineId);
            
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
                "dbo.QuantitiesOfMedicines",
                c => new
                    {
                        QuantityAddId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuantityAddId, t.MedicineId })
                .ForeignKey("dbo.QuantitiesOnMagazine", t => t.QuantityAddId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.QuantityAddId)
                .Index(t => t.MedicineId);
            
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
            DropForeignKey("dbo.Medicines", "Bill_BillId", "dbo.Bills");
            DropForeignKey("dbo.Reciepts", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "PharmaceutId", "dbo.Pharmaceuts");
            DropForeignKey("dbo.RecieptMedicines", "Medicine_MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.RecieptMedicines", "Reciept_RecieptId", "dbo.Reciepts");
            DropForeignKey("dbo.Reciepts", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.QuantitiesOfMedicines", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.QuantitiesOfMedicines", "QuantityAddId", "dbo.QuantitiesOnMagazine");
            DropForeignKey("dbo.Doctors", "Medicine_MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.MedicineDeliveries", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.MedicineDeliveries", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.ExpiredDateMedicines", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.ExpiredDateMedicines", "ExpiredDateId", "dbo.ExpiredDates");
            DropForeignKey("dbo.ExpiredDateTables", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.ExpiredDateTables", "ExpiredDateID", "dbo.ExpiredDates");
            DropIndex("dbo.RecieptMedicines", new[] { "Medicine_MedicineId" });
            DropIndex("dbo.RecieptMedicines", new[] { "Reciept_RecieptId" });
            DropIndex("dbo.QuantitiesOfMedicines", new[] { "MedicineId" });
            DropIndex("dbo.QuantitiesOfMedicines", new[] { "QuantityAddId" });
            DropIndex("dbo.MedicineDeliveries", new[] { "DeliveryId" });
            DropIndex("dbo.MedicineDeliveries", new[] { "MedicineId" });
            DropIndex("dbo.ExpiredDateMedicines", new[] { "MedicineId" });
            DropIndex("dbo.ExpiredDateMedicines", new[] { "ExpiredDateId" });
            DropIndex("dbo.ExpiredDateTables", new[] { "DeliveryId" });
            DropIndex("dbo.ExpiredDateTables", new[] { "ExpiredDateID" });
            DropIndex("dbo.Patients", new[] { "PharmaceutId" });
            DropIndex("dbo.Reciepts", new[] { "PatientId" });
            DropIndex("dbo.Reciepts", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "Medicine_MedicineId" });
            DropIndex("dbo.Medicines", new[] { "Bill_BillId" });
            DropTable("dbo.RecieptMedicines");
            DropTable("dbo.QuantitiesOfMedicines");
            DropTable("dbo.MedicineDeliveries");
            DropTable("dbo.ExpiredDateMedicines");
            DropTable("dbo.ExpiredDateTables");
            DropTable("dbo.Pharmaceuts");
            DropTable("dbo.Patients");
            DropTable("dbo.Reciepts");
            DropTable("dbo.QuantitiesOnMagazine");
            DropTable("dbo.Doctors");
            DropTable("dbo.ExpiredDates");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Medicines");
            DropTable("dbo.Bills");
        }
    }
}
