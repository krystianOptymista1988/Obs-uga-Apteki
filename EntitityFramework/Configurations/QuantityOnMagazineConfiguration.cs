using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.EntitityFramework.Configurations
{
    public class QuantityOnMagazineConfiguration : EntityTypeConfiguration<QuantityOnMagazine>
    {
        public QuantityOnMagazineConfiguration()
        {
            ToTable("dbo.QuantitiesOnMagazine");

            HasKey(x => x.QuantityAddId);



            HasMany(m => m.Medicines)
                        .WithMany(d => d.QuantityOfPackages)
                        .Map(md =>
                        {
                            md.ToTable("QuantitiesOfMedicines"); // Nazwa tabeli pośredniczącej
                            md.MapLeftKey("QuantityAddId");      // Nazwa kolumny dla Medicine
                            md.MapRightKey("MedicineId");     // Nazwa kolumny dla Delivery
                        });
        }
    } 
}
