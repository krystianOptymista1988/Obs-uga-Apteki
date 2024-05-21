using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    public class Medicine : IMedicineRefunded, IMedicineOnReciept
    {

        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Producent { get; set; }
        public DateTime ExpiredDate { get; set; }
        private double PriceOfBuy { get; set; }
        public double PriceOfSell { get; set; }
        private double PriceMarge { get; set; }
        public int QuantityInPackage { get; set; }
        public int QuantityOfPackages { get; set; }
        public bool IsRefunded { get; set; }
        public double? PercentageOfRefunding { get; set; }
        public double? PriceAfterRefunding { get; set; }
        public string ActiveSubstance { get; set; }
        public bool IsAntibiotique { get; set; }

        public bool IsOnReciept { get; set; }
        public int? DoctorId { get; }
        public int? RecieptId { get; }

    }
}
