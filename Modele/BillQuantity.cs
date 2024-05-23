using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele
{
    public class BillQuantity
    {
        [Key, Column(Order = 0)]
        public int BillId { get; set; }
        [Key, Column(Order = 1)]
        public int QuantityOnMagazineId { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual QuantityOnMagazine QuantityOnMagazine { get; set; }

        public int Quantity { get; set; }
    }
}
