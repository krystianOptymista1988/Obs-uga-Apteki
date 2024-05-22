using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele.Configurations
{
    public class PatientConfiguration : EntityTypeConfiguration<Patient>

    {
        public PatientConfiguration()
        {
            ToTable("dbo.Patients");

            HasKey(x => x.PatientId);

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
