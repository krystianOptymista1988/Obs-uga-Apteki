using Obsługa_Apteki.Modele;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Obsługa_Apteki
{
    public class QuantityOnMagazine
    {
        public QuantityOnMagazine()
        {
            BillQuantities = new List<BillQuantity>();
            ExpiredDates = new List<ExpiredDate>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuantityOnMagazineId { get; set; }

        public int Quantities { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public ICollection<BillQuantity> BillQuantities { get; set; }
        public ICollection<ExpiredDate> ExpiredDates { get; set; }

    }
}