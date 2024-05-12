using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    public abstract class Medicine
    {
        int Id { get; set; }
        string Name { get; set; }
        string category { get; set; }
        DateTime ExpiredDate { get; set; }
        double Price { get; set; }
        bool IsRefunded { get; set; }
        double PercentageOfRefunding { get; set; }
        string ActiveSubstance { get; set; }
    }
}
