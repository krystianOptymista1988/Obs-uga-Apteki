using Obsługa_Apteki.Entities;
using System.Data.Entity;

namespace Obsługa_Apteki.Entities
{
    public class AptekaDbInitializer : CreateDatabaseIfNotExists<AptekaDbContext>
    {


        protected override void Seed(AptekaDbContext context)
        {
            base.Seed(context);
        }
    }
}