using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele
{
    public class ExpiredMedicines
    {
        public class ExpiredMedicineInfo
        {
            public int MedicineId { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public DateTime DateOfExpire { get; set; }
            public int ExpiredQuantity { get; set; }
        }
    }
}
