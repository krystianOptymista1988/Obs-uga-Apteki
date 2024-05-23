using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele.Configurations
{
    public class BillConfiguration : EntityTypeConfiguration<Bill>
    {
        public BillConfiguration()
        {
            ToTable("dbo.Bills");

            HasKey(x => x.BillId);

            Property(x => x.DateOfBill)
                .IsRequired();

        }
    }
}
