using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Obsługa_Apteki
{
    public class Doctor : Person
    {
        public Doctor()
        {
            Patients = new List<Patient>();
            Reciepts = new List<Reciept>();
        }

        public int DoctorId { get; set; }
        public ICollection<Patient> Patients = new List<Patient>();
        public ICollection<Reciept> Reciepts = new List<Reciept>();
    }
}
