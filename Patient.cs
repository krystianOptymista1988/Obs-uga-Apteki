using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    public class Patient : Person
    {
        [Key]
        public int PatientId { get; set; }
        public string Comment { get; set; }
    }
}
