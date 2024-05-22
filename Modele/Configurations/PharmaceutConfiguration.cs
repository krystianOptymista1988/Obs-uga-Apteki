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
        }
    }
}
