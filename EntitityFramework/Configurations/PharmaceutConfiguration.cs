using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele.Configurations
{
    public class PharmaceutConfiguration : EntityTypeConfiguration<Pharmaceut>
    {
        public PharmaceutConfiguration()
        {
            ToTable("dbo.Pharmaceuts");

            HasKey(x => x.PharmaceutId);

            Property(c => c.Adress)
               .HasMaxLength(100);

            Property(c => c.Name)
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.Surname)
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.Mobile)
               .HasMaxLength(15);

            Property(c => c.DateOfBirth)
               .HasColumnType("date");

            Property(d => d.DateOfHire)
                .HasColumnType("date");
        }
    }
}
