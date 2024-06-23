using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obsługa_Apteki.Modele
{
    public class Reciept
    {
        public Reciept()
        {
            MedicineReciepts = new List<MedicineReciept>();
            AddedMedicines = new List<Medicine>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecieptId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string PatientFullName { get; set; }
        public string DoctorFullName { get; set; }
        public virtual ICollection<MedicineReciept> MedicineReciepts { get; set; } // Dodano właściwość MedicineReciepts
        public virtual ICollection<Medicine> AddedMedicines { get; set; }
        public ICollection<object> Medicines { get; internal set; }
        public DateTime DateOfRegistry { get; internal set; }
        
        public DateTime DateOfExpire { get; set; }
        public int PatientId { get; internal set; }
        public int Quantity { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
