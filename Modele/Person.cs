using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string PESEL { get; set; }
        public string Mobile { get; set; }

        public string Adress { get; set; }
        public string PostalCode { get; set; }

        public List<Reciept> RecieptList { get; set; }




    }
}
