using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    internal class Delivery
    {
        public List<Medicine> Medicines { get; set; }  
        public DateTime DateOfDelivery { get; set; }

        public DateTime DateOfCreate { get; set; }
        public Pharmaceut PharmaceutOrdering { get; set; }

        public double Value { get; set; }

    }
}
