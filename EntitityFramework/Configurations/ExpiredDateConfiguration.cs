using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele.Configurations
{
    public class ExpiredDateConfiguration : EntityTypeConfiguration<ExpiredDate>
    {
        public ExpiredDateConfiguration()
        {
            ToTable("dbo.ExpiredDates");

            HasKey(x => x.ExpiredDateId);

            Property(c => c.DateofExpire)
            .HasColumnType("date");

            HasMany(m => m.Medicines)
                    .WithMany(d => d.ExpiredDates)
                    .Map(md =>
                    {
                        md.ToTable("ExpiredDateMedicines"); // Nazwa tabeli pośredniczącej
                        md.MapLeftKey("ExpiredDateId");      // Nazwa kolumny dla Medicine
                        md.MapRightKey("MedicineId");     // Nazwa kolumny dla Delivery
                    });
            HasMany(d => d.Deliveries)
                .WithMany(d => d.ExpiredDates)
                .Map(md =>
                {
                    md.ToTable("ExpiredDateTables");
                    md.MapLeftKey("ExpiredDateID");
                    md.MapRightKey("DeliveryId");
                });
        }
    }
}
