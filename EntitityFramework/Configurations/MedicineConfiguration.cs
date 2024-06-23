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

            HasMany(m => m.MedicineReciepts)
                .WithRequired(mr => mr.Medicine)
                .HasForeignKey(mr => mr.MedicineId);
            // Usuwamy poniższy fragment, ponieważ powoduje on zduplikowanie EntitySet
            /*
            HasMany(m => m.Deliveries)
                .WithMany(d => d.OrderedMedicines)
                .Map(md =>
                {
                    md.ToTable("MedicineDeliveries");
                    md.MapLeftKey("MedicineId");
                    md.MapRightKey("DeliveryId");
                });
            */
            // Relacja wiele-do-wielu z tabelą Reciepts
          //  HasMany(m => m.Reciepts)
          //      .WithMany(r => (ICollection<Medicine>)r.Medicines)
          //      .Map(mr =>
          //      {
          //          mr.ToTable("MedicineReciepts");
          //          mr.MapLeftKey("MedicineId");
           //         mr.MapRightKey("RecieptId");
           //     });

      

        }
    }
}
