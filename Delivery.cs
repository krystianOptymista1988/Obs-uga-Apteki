using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    public class Delivery
    {
        
        public int DeliveryId { get; set; } 
        public DateTime DateOfDelivery { get; set; }

        public DateTime DateOfCreate { get; set; }
        public int PharmaceutOrdering { get; set; }

        public List<Medicine> OrderedMedicines { get; set; }

        public double Value { get; set; }

    }
}
