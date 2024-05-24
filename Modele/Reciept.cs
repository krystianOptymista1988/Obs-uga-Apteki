using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obsługa_Apteki
{
    public class Reciept
    {
        public Reciept()
        {
            Medicines = new List<Medicine>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecieptId { get; set; }
        public ICollection<Medicine> Medicines { get; set; } // 1 do wielu, 1 recepta może zawierać wiele leków
        public DateTime DateOfRegistry { get; set; }
        public DateTime DateOfExpire { get; set; }

        public int DoctorId { get; set; } // 1 do 1 tzn 1 lekarz może wystawić 1 receptę
        public Doctor Doctor { get; set; } // 1 do 1
        public int PatientId { get; set; }  // 1 do 1
        public Patient Patient { get; set; } // 1 do 1

        public int Quantity { get; set; }

    }
}
