using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele.Configurations
{
    public class MedicineConfiguration : EntityTypeConfiguration<Medicine>
    {
        public MedicineConfiguration()
        {
            ToTable("dbo.Medicines");

            HasKey(x => x.MedicineId);

            HasMany(m => m.Deliveries)
                .WithMany(d => d.OrderedMedicines)
                .Map(md =>
                {
                    md.ToTable("MedicineDeliveries"); 
                    md.MapLeftKey("MedicineId");     
                    md.MapRightKey("DeliveryId");     
                });

            // Has(m => m.MedicineDeliveries)
            // .WithRequired(md => md.Medicine)
            // .HasForeignKey(md => md.MedicineId);

        }
    }
}
