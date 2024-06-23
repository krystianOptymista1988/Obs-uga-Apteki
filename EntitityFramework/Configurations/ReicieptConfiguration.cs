using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele.Configurations
{
    public class ReicieptConfiguration : EntityTypeConfiguration<Reciept>
    {
        public ReicieptConfiguration()
        {
            ToTable("dbo.Reciepts");

            HasKey(x => x.RecieptId);

            HasMany(r => r.MedicineReciepts)
                .WithRequired(mr => mr.Reciept)
                .HasForeignKey(mr => mr.RecieptId);
            // Konfiguracja właściwości DateOfExpire do używania datetime2
     //       Property(r => r.DateOfExpire)
              
         //       .IsRequired();

            // Konfiguracja innych właściwości podobnie
            Property(r => r.DateOfRegistry)
               
                .IsRequired();

            // Usuń zduplikowane mapowania, jeżeli są
            // HasMany(m => m.Medicines)
            //     .WithMany()
            //     .Map(md =>
            //     {
            //         md.ToTable("RecieptMedicines");
            //         md.MapLeftKey("RecieptId");
            //         md.MapRightKey("MedicineId");
            //     });
        }
    }
}
