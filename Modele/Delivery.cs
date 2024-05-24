using Obsługa_Apteki.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obsługa_Apteki
{
    public class Delivery
    {
        public Delivery()
        {
            OrderedMedicines = new List<Medicine>();
            ExpiredDates = new List<ExpiredDate>();
            MedicineDeliveries = new List<MedicineDelivery>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryId { get; set; }
        public DateTime DateOfDelivery { get; set; }

        public DateTime DateOfCreate { get; set; }
        public int PharmaceutOrdering { get; set; }

        public ICollection<Medicine> OrderedMedicines { get; set; }

        public ICollection<ExpiredDate> ExpiredDates { get; set; }

        public double Value { get; set; }
        public ICollection<MedicineDelivery> MedicineDeliveries { get; set; }

    }
}
