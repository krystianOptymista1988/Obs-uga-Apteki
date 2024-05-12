using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    internal class Pharmaceut : Person
    {
        private int Salary {  get; set; }
        public DateTime DateOfHire {  get; set; }

        public List<Patient> Patients { get; set; }

    }
}
