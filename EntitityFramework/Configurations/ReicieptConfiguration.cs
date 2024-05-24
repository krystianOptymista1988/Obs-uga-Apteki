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
            HasMany(m => m.Medicines)
           .WithMany()
           .Map(md =>
           {
               md.ToTable("RecieptMedicines");
               md.MapLeftKey("RecieptId");
               md.MapRightKey("MedicineId");
           });
        }
    }
}
