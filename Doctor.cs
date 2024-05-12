using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    internal class Doctor : Person
    {
        public List<Patient> Patients = new List<Patient>();
        public List<Reciept> Reciepts = new List<Reciept>();
    }
}
