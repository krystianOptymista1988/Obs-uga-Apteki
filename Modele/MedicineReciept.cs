using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele
{
    public class MedicineReciept
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineRecieptId { get; set; }
        public int RecieptId { get; set; }
        public virtual Reciept Reciept { get; set; }
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
        public int Quantity { get; set; }
        public string DoctorFullName {  get; set; }
        public string MedicineName {  get; set; }
    }
}
