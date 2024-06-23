using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele
{
    public class MedicineDelivery //: Medicine
    {
        [Key]
        public int MedicineDeliveryId { get; set; }
        public int DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
        public int Quantity { get; set; }

        [NotMapped]
        public string MedicineName => Medicine?.Name;

        [NotMapped]
        public int QuantityInPackage => Medicine?.QuantityInPackage ?? 0;
    }
            
        
}
