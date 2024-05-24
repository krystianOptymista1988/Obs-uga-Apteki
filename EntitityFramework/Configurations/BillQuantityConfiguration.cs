using Obsługa_Apteki.Modele;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.EntitityFramework.Configurations
{
    public class BillQuantityConfiguration : EntityTypeConfiguration<BillQuantity>
    {
         public BillQuantityConfiguration() 
        {
            ToTable("dbo.BillQuantities");

            HasKey(a => new { a.BillId, a.QuantityOnMagazineId });

            HasRequired(b => b.Bill)                
                .WithMany(b => b.BillQuantities)
                .HasForeignKey(b => b.BillId);

            HasRequired(c => c.QuantityOnMagazine)
                .WithMany(c => c.BillQuantities)
                .HasForeignKey(c => c.QuantityOnMagazineId);
        }
    }
}
