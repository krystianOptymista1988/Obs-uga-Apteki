using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;

namespace Obsługa_Apteki
{
    public class Bill
    {
        public Bill()
        {
            Medicines = new List<Modele.Medicine>();
            BillQuantities = new List<BillQuantity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }
        public DateTime DateOfBill { get; set; }
        public double BillPrice { get; set; }

        public ICollection<Modele.Medicine> Medicines { get; set; }

        public ICollection<BillQuantity> BillQuantities { get; set; }
    }
}
