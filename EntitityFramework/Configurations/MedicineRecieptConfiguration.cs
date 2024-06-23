using Obsługa_Apteki.Modele;
using System.Data.Entity.ModelConfiguration;

namespace Obsługa_Apteki.EntitityFramework.Configurations
{
    internal class MedicineRecieptConfiguration : EntityTypeConfiguration<MedicineReciept>
    {
        public MedicineRecieptConfiguration()
        {
            ToTable("dbo.MedicineReciepts");
            HasKey(m => m.MedicineRecieptId);

            HasRequired(mr => mr.Reciept)
                .WithMany(r => r.MedicineReciepts)
                .HasForeignKey(mr => mr.RecieptId);

            HasRequired(mr => mr.Medicine)
                .WithMany(m => m.MedicineReciepts)
                .HasForeignKey(mr => mr.MedicineId);
        }
    }
}
