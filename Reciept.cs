using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    public class Reciept
    {
        [Key]
        public int RecieptId { get; set; }
        public Patient Patient { get; set; }
        public List<Medicine> Medicines { get; set; }
        public DateTime DateOfRegistry { get; set; }
        public DateTime DateOfExpire { get; set; }
        public Doctor Doctor { get; set; }

    }
}
