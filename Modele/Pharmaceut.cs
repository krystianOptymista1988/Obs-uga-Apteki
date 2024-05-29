using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obsługa_Apteki
{
    public class Pharmaceut : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PharmaceutId { get; set; }
        public int Salary { get; set; }
        public DateTime DateOfHire { get; set; }

        public string Comment { get; set; } 

        public List<Patient> Patients { get; set; }

        public string FullName => $"{Name} {Surname}";

        public string password { get; set; }

    }
}
