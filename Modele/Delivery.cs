using System;
using System.Collections.Generic;

namespace Obsługa_Apteki
{
    public class Delivery
    {
        public Delivery()
        {
            OrderedMedicines = new List<Medicine>();
        }

        public int DeliveryId { get; set; }
        public DateTime DateOfDelivery { get; set; }

        public DateTime DateOfCreate { get; set; }
        public int PharmaceutOrdering { get; set; }

        public ICollection<Medicine> OrderedMedicines { get; set; }

        public double Value { get; set; }

    }
}
