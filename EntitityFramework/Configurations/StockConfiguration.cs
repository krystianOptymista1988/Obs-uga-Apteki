using Obsługa_Apteki.Modele;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.EntitityFramework.Configurations
{
    public class StockConfiguration : EntityTypeConfiguration<Stock>
    { 
        public StockConfiguration() 
        {
            ToTable("dbo.Stock")
            .HasKey(x => x.StockId);

            HasRequired(a => a.Medicine)
                .WithMany()
                .HasForeignKey(c => c.MedicineId);

            Property(b => b.Quantity)
                .IsRequired();



        }
       
    }
}
