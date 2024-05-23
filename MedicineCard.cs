using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class MedicineCard : Form
    {
        private int medicineId = 0;
        private DbActions _dbAction = new DbActions();
        private Medicine medicine = new Medicine();
        private AptekaTestDbContext _context = new AptekaTestDbContext();

        public MedicineCard()
        {
            InitializeComponent();

        }

        public MedicineCard(int MediniceId, AptekaTestDbContext context)
        {
            InitializeComponent();
            _context = context;
            medicineId = MediniceId;
            GetMedicineData();
        }

        private void GetMedicineData()
        {
            if (_context == null) 
            _context = _dbAction.GetContext();
            if (medicineId != null)
            {
                Text = "Edytowanie danych Pacjenta";
                medicine = _context.Medicines.FirstOrDefault(x => x.MedicineId == medicineId);

                if (medicine == null)
                {
                    throw new Exception("Brak użytkownika o podanym Id");
                }

                FillTextBoxes(medicine);
            }
            else
            {
                MessageBox.Show("Błąd przekazania");
            }
        }

        private void FillTextBoxes(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {

        }
    }
}
