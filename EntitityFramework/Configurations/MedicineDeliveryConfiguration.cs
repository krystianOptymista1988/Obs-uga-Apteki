using Obsługa_Apteki.Modele;
using System.Data.Entity.ModelConfiguration;

namespace Obsługa_Apteki.EntitityFramework.Configurations
{
    public class MedicineDeliveryConfiguration : EntityTypeConfiguration<MedicineDelivery>
    {
        public MedicineDeliveryConfiguration()
        {
            ToTable("dbo.MedicineDeliveries");
            HasKey(m => m.MedicineDeliveryId);

            HasRequired(md => md.Delivery)
                .WithMany(d => d.MedicineDeliveries)
                .HasForeignKey(md => md.DeliveryId);

            HasRequired(md => md.Medicine)
                .WithMany(m => m.MedicineDeliveries)
                .HasForeignKey(md => md.MedicineId);
        }
    }
}
