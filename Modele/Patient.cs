using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obsługa_Apteki
{
    public class Patient : Person
    {
        public Patient()
        {
            RecieptList = new List<Reciept>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PatientId { get; set; }
        public string Comment { get; set; }
        public int? PharmaceutId { get; set; }  //1 do 1    1 pacjent ma 1 opiekuna

        public Pharmaceut Pharmaceut { get; set; } // 1 do 1
        public ICollection<Reciept> RecieptList { get; set; }


    }
}
