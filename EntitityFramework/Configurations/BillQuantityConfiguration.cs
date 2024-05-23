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

            HasKey(iq => new { iq.BillId, iq.QuantityOnMagazineId });

            HasRequired(iq => iq.Bill)
                .WithMany(b => b.BillQuantities)
                .HasForeignKey(iq => iq.BillId);

            HasRequired(iq => iq.QuantityOnMagazine)
                .WithMany(q => q.BillQuantities)
                .HasForeignKey(iq => iq.QuantityOnMagazineId);
        }
    }
}
