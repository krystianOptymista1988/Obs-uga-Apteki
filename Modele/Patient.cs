using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Obsługa_Apteki.Modele;

namespace Obsługa_Apteki
{
    public class Patient : Person
    {
        public Patient()
        {
            Reciepts = new List<Reciept>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PatientId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Comment { get; set; }
        public int? PharmaceutId { get; set; }  //1 do 1    1 pacjent ma 1 opiekuna

        public Pharmaceut Pharmaceut { get; set; } // 1 do 1
        public ICollection<Reciept> Reciepts { get; set; }
        public string FullName => $"{Name} {Surname}";


    }
}
