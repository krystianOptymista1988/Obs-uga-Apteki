using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele.Configurations
{
    internal class DoctorConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorConfiguration()
        {
                ToTable("dbo.Patients");

                HasKey(x => x.DoctorId);

        }
    }
}
