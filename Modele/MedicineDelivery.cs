using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele
{
    public class MedicineDelivery
    {

        public int MedicineDeliveryId { get; set; }
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }
    }
            
        
}
