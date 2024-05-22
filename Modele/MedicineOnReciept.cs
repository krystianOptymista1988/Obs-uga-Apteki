using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    internal interface IMedicineOnReciept
    {
        int? DoctorId { get; }
        int? RecieptId { get; }  
    }
}
