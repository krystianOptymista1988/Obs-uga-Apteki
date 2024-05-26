using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele.Configurations
{
    public class DoctorConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorConfiguration()
        {
                ToTable("dbo.Doctors");

                HasKey(x => x.DoctorId);

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

        }
    }
}
