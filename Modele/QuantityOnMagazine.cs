using System.Collections;
using System.Collections.Generic;

namespace Obsługa_Apteki
{
    public class QuantityOnMagazine
    {
        public QuantityOnMagazine()
        {
            Medicines = new List<Medicine>();
        }

        public int QuantityAddId { get; set; } 
        public int Quantities { get; set; }
        public ICollection<Medicine> Medicines { get; set; }    

    }
}