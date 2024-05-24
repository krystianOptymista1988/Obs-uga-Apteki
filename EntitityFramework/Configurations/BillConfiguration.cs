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
            ToTable("dbo.Bills");    //komenda do tworzenia nowej tabeli

            HasKey(x => x.BillId); // ta ustawia klucz w tej tabeli na Id 

            Property(x => x.DateOfBill) // Wymaga wprowadzenia daty  
                .IsRequired();

        }
    }
}
