using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obsługa_Apteki.Modele
{
    public class Medicine
    {
        public Medicine()
        {
            MedicineReciepts = new List<MedicineReciept>();
            Deliveries = new List<Delivery>();
            ExpiredDates = new List<ExpiredDate>();
            QuantityOnMagazines = new List<QuantityOnMagazine>();
            MedicineDeliveries = new List<MedicineDelivery>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Producent { get; set; }
        public ICollection<ExpiredDate> ExpiredDates { get; set; }
        public double PriceOfBuy { get; set; }
        public double Price { get; set; }
        public double PriceMarge { get; set; }
        public int QuantityInPackage { get; set; }
        public bool IsRefunded { get; set; }
        public double? PercentageOfRefunding { get; set; }
        public double? PriceAfterRefunding { get; set; }
        public string ActiveSubstance { get; set; }
        public bool IsAntibiotique { get; set; }
        public bool IsOnReciept { get; set; }
        public virtual ICollection<Reciept> Reciepts { get; set; } // 1 do wielu tzn 1 lek może znaleźć się na wielu receptach
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<QuantityOnMagazine> QuantityOnMagazines { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<MedicineDelivery> MedicineDeliveries { get; set; }
        public virtual ICollection<MedicineReciept> MedicineReciepts { get; set; } // Dodano właściwość MedicineReciepts
    }
}
