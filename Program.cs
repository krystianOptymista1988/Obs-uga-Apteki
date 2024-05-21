using Obsługa_Apteki.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    internal static class Program
    {
       // public static string FilePath =
       //  Path.Combine(Environment.CurrentDirectory, "pharmacy.txt");
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(new AptekaDbInitializer());
            using (var context = new AptekaDbContext())
            {
               context.TablesCheck();
            }

            DbContextTester.TestConnection();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
        public static class DbContextTester
        {
            public static void TestConnection()
            {
                using (var context = new AptekaDbContext())
                {
                    if (context.Database.Exists())
                    {
                        MessageBox.Show("Baza danych istnieje i wszystkie tabele są już utworzone");
                    }
                    else
                    {
                        MessageBox.Show("Baza danych nie istnieje. Tworzenie nowej bazy danych.");
                        context.Database.Create();
                        MessageBox.Show("Baza danych została utworzona.");
                    }
                }
            }
        }

    }
}
