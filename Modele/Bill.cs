using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Obsługa_Apteki
{
    internal class Bill
    {
        public Bill()
        {
           Medicines = new List<Medicine>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }
        public DateTime DatoOfBill { get; set; }
        public int BillPrice { get; set; }

        public ICollection<Medicine> Medicines { get; set; }

    }
}
