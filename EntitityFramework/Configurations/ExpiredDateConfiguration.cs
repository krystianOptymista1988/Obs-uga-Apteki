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
                    md.ToTable("ExpiredDateMedicines"); //To jest relacja wiele do wielu
                    md.MapLeftKey("ExpiredDateId");     //łączy leki z terminami ważności
                    md.MapRightKey("MedicineId");       // w nowej tabeli ale nie wiem czy będzie działać
                });

            HasMany(d => d.Deliveries)
                .WithMany(d => d.ExpiredDates)
                .Map(md =>
                {
                    md.ToTable("ExpiredDateDeliveries");
                    md.MapLeftKey("ExpiredDateId");     // tak samo jak wyżej
                    md.MapRightKey("DeliveryId");       // ten gostek na udemy to ciężko tłumaczy
                });

            HasMany(e => e.QuantityOnMagazines)
                .WithMany(q => q.ExpiredDates)
                .Map(eq =>
                {
                    eq.ToTable("ExpiredDateQuantities"); 
                    eq.MapLeftKey("ExpiredDateId");      // tak samo jak wyżej
                    eq.MapRightKey("QuantityOnMagazineId"); 
                });
        }
    }
}
