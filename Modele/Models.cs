using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Obsługa_Apteki.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PESEL { get; set; }
        public string Mobile { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string Comment { get; set; }
    }
    public class Reciept
    {
        [Key]
        public int RecieptId { get; set; }
        public Patient Patient { get; set; }
        public List<Medicine> Medicines { get; set; }
        public DateTime DateOfRegistry { get; set; }
        public DateTime DateOfExpire { get; set; }

    }

    public class Pharmaceut
    {
        [Key]
        public int PharmaceutId { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string PESEL { get; set; }
        public string Mobile { get; set; }

        public string Adress { get; set; }
        public string PostalCode { get; set; }
        private int Salary { get; set; }
        public DateTime DateOfHire { get; set; }


    }
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; internal set; }
        public DateTime DateOfDelivery { get; set; }

        public DateTime DateOfCreate { get; set; }
        public double Value { get; set; }
        public int PharmaceutId { get; set; }

    }

    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Producent { get; set; }
        public DateTime ExpiredDate { get; set; }
        private double PriceOfBuy { get; set; }
        public double PriceOfSell { get; set; }
        private double PriceMarge { get; set; }
        public int QuantityInPackage { get; set; }
        public int QuantityOfPackages { get; set; }
        public bool IsRefunded { get; set; }
        public double? PercentageOfRefunding { get; set; }
        public double? PriceAfterRefunding { get; set; }

        public string ActiveSubstance { get; set; }
        public bool IsAntibiotique { get; set; }

        public bool IsOnReciept { get; set; }

    }

}
