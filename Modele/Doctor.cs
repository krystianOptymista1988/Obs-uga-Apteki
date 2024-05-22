using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    public class Doctor : Person
    {
        [Key]
        public int DoctorId { get; set; }   
        public List<Patient> Patients = new List<Patient>();
        public List<Reciept> Reciepts = new List<Reciept>();
    }
}
