using Obsługa_Apteki.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Obsługa_Apteki
{
    public class Medicine 
    {
        public Medicine()
        {
         Reciepts = new List<Reciept>();
         Doctor = new List<Doctor>();
         Deliveries = new List<Delivery>();
         ExpiredDates = new List<ExpiredDate>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Producent { get; set; }
        public ICollection<ExpiredDate> ExpiredDates { get; set; }
        private double PriceOfBuy { get; set; }
        public double PriceOfSell { get; set; }
        private double PriceMarge { get; set; }
        public int QuantityInPackage { get; set; } //jak to zrobić ? 
        public int QuantityOfPackages { get; set; }
        public bool IsRefunded { get; set; }
        public double? PercentageOfRefunding { get; set; }
        public double? PriceAfterRefunding { get; set; }
        public string ActiveSubstance { get; set; }
        public bool IsAntibiotique { get; set; }

        public bool IsOnReciept { get; set; }
        public ICollection<Doctor> Doctor { get; set; } // 1 do wielu
        public ICollection<Reciept> Reciepts { get; set; } // 1 do wielu tzn 1 lek może znaleźć się na wielu receptach
        public ICollection<Delivery> Deliveries { get; set; }

    }
}
