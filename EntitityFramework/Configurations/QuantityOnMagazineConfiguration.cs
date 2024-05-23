using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

            HasKey(x => x.QuantityOnMagazineId);

            Property(x => x.Quantities)
                .IsRequired();

            
            Property(x => x.QuantityOnMagazineId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("QuantityOnMagazineId")
                .IsRequired();
        }
    } 
}
