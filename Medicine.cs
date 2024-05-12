using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    public abstract class Medicine
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string category { get; set; }
       public DateTime ExpiredDate { get; set; }
       private double PriceOfBuy { get; set; }
       public double PriceOfSell { get; set; }
       private double MargePrice { get; set; }
       public int QuantityInPackage { get; set; }
       public int QuantityOfPackages { get; set; }
       public bool IsRefunded { get; set; }
       public string ActiveSubstance { get; set; }
    }
}
