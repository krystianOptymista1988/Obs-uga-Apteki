﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki
{
    internal class MedicineRefunded : Medicine
    {
        public double PercentageOfRefunding { get; set; }
        public double PriceAfterRefunding { get; set; }
    }
}
