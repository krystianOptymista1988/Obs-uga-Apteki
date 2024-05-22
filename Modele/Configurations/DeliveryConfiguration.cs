using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele.Configurations
{
    internal class DeliveryConfiguration : EntityTypeConfiguration<Delivery>
    {
        public DeliveryConfiguration()
        {
            ToTable("dbo.Deliveries");

            HasKey(x => x.DeliveryId);
            HasMany(m => m.OrderedMedicines);
            

        }
    }
}
