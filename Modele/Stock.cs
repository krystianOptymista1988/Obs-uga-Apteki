using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele
{
    public class Stock
    {
        public int StockId { get; set; } 
        public int MedicineId { get; set; } 
        public Medicine Medicine { get; set; }

        public int Quantity { get; set; }
    }
}
