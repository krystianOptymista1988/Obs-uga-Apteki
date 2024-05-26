using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obsługa_Apteki
{
    public class Doctor : Person
    {
        public Doctor()
        {
            Patients = new List<Patient>();
            Reciepts = new List<Reciept>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }
        public ICollection<Patient> Patients = new List<Patient>();
        public ICollection<Reciept> Reciepts = new List<Reciept>();
    }
}
