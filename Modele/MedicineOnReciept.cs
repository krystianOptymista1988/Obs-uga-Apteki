using System.Collections.Generic;

namespace Obsługa_Apteki
{
    public interface IMedicineOnReciept
    {
       ICollection<Doctor> Doctor { get; set; } // 1 do wielu
       ICollection<Reciept> Reciepts { get; set; } // 1 do wielu tzn 1 lek może znaleźć się na wielu receptach
    }
}
