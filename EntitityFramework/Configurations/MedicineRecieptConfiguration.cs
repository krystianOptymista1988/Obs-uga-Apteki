using Obsługa_Apteki.Modele;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.EntitityFramework.Configurations
{
    internal class MedicineRecieptConfiguration : EntityTypeConfiguration<MedicineReciept>
    {
        public MedicineRecieptConfiguration()
        {
            ToTable("dbo.MedicineReciepts");
            HasKey(m => m.MedicineRecieptId);

            HasRequired(a => a.Reciept)
                .WithMany(d => d.MedicineReciepts)
                .HasForeignKey(fk => fk.RecieptId);

            HasRequired(m => m.Medicine)
                .WithMany(m => m.MedicineReciepts)
                .HasForeignKey(fk => fk.MedicineId);
        }
    }
}
