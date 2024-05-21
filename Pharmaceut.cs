using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    public class Pharmaceut : Person
    {
        [Key]
        public int PharmaceutId { get; set; }
        private int Salary {  get; set; }
        public DateTime DateOfHire {  get; set; }

        public List<Patient> Patients { get; set; }

    }
}
