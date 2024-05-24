using Obsługa_Apteki.Modele;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.EntitityFramework.Configurations
{
    public class MedicineDeliveryConfiguration : EntityTypeConfiguration<MedicineDelivery>
    {
        public MedicineDeliveryConfiguration() 
        {
            ToTable("dbo.MedicineDeliveries");
            HasKey(m => m.MedicineDeliveryId);

            HasRequired(a => a.Delivery)
                .WithMany(d => d.MedicineDeliveries)
                .HasForeignKey(fk => fk.DeliveryId);

            HasRequired(m => m.Medicine)
                .WithMany(m => m.MedicineDeliveries)
                .HasForeignKey(fk => fk.MedicineId);

        }  
    }
}
