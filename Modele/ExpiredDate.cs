using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele
{
    public class ExpiredDate
    {
        public ExpiredDate()
        {
            Deliveries = new List<Delivery>();
            Medicines = new List<Medicine>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpiredDateId { get; set; }
        public DateTime DateofExpire{ get; set; }
        public ICollection<Delivery> Deliveries { get; set; }
        public ICollection<Medicine> Medicines { get; set;}
        
    }
}
