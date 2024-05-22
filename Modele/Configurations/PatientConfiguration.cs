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
        }
    }
}
