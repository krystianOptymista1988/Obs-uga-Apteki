using System;
using System.Collections;
using System.Collections.Generic;

namespace Obsługa_Apteki
{
    internal class Bill
    {
        public Bill()
        {
           Medicines = new List<Medicine>();
        }
        public int BillId { get; set; }
        public DateTime DatoOfBill { get; set; }
        public int BillPrice { get; set; }

        public ICollection<Medicine> Medicines { get; set; }

    }
}
