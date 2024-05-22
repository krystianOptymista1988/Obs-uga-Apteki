using System.Data.Entity;

namespace Obsługa_Apteki.Entities
{
    public class AptekaDbInitializer : CreateDatabaseIfNotExists<AptekaTestDbContext>
    {


        protected override void Seed(AptekaTestDbContext context)
        {
            base.Seed(context);
        }
    }
}