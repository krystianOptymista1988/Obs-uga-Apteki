using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    internal class Reciept
    { 
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public List<Medicine> Medicines { get; set; }
        public DateTime DateOfRegistry { get; set; }
        public DateTime DateOfExpire { get; set; }

    }
}
