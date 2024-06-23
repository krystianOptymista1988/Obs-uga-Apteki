using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele.Configurations
{
    public class DeliveryConfiguration : EntityTypeConfiguration<Delivery>
    {
        public DeliveryConfiguration()
        {
            ToTable("dbo.Deliveries");

            HasKey(x => x.DeliveryId);

            // Usuwamy poniższy fragment, ponieważ powoduje on zduplikowanie EntitySet
            /*
            HasMany(d => d.OrderedMedicines)
                .WithMany(m => m.Deliveries)
                .Map(md =>
                {
                    md.ToTable("MedicineDeliveries");
                    md.MapLeftKey("DeliveryId");
                    md.MapRightKey("MedicineId");
                });
            */

            HasMany(d => d.MedicineDeliveries)
                .WithRequired(md => md.Delivery)
                .HasForeignKey(md => md.DeliveryId);

            Property(c => c.DateOfDelivery)
                .HasColumnType("date");
        }
    }
}
