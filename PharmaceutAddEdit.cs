using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class PharmaceutAddEdit : Form
    {
        private string _patientId;
        private string pesel;
        private DbActions _dbAction = new DbActions();
        private Pharmaceut pharmaceut = new Pharmaceut();
        private AptekaTestDbContext _context = new AptekaTestDbContext();
       // private int _pharmaceutId;
       // List<Pharmaceut> _pharmaceuts;
        public PharmaceutAddEdit()
        {
            InitializeComponent();
 
        }

        public PharmaceutAddEdit(string pharmaceutId, AptekaTestDbContext context)
        {
            InitializeComponent();
            _context = context;
            pesel = pharmaceutId;
            GetPharmaceutData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Pharmaceut CreatePharmaceut()
        {
            pharmaceut.Name = tbName.Text;
            pharmaceut.Surname = tbSurname.Text;
            pharmaceut.DateOfBirth = DateTime.Parse(dtpDateOfBirth.Text);
            pharmaceut.PESEL = tbPESEL.Text;
            pharmaceut.Adress = tbAdress.Text;
            pharmaceut.PostalCode = tbPostalCode.Text;
            pharmaceut.Mobile = tbMobile.Text;
            pharmaceut.Salary= int.Parse(nmSallary.Value.ToString());
            pharmaceut.DateOfHire = DateTime.Parse(dtpHire.Value.ToString());
            pharmaceut.Comment = tbComment.Text;
           // pharmaceut.Patients = new List<Patient>();
            return pharmaceut;
        }

        private Pharmaceut CreatePharmaceut(Pharmaceut pharmaceut)
        {
            int pharmaceutID = int.Parse(tbId.Text);

            pharmaceut.Name = tbName.Text;
            pharmaceut.Surname = tbSurname.Text;
            pharmaceut.DateOfBirth = DateTime.Parse(dtpDateOfBirth.Text);
            pharmaceut.PESEL = tbPESEL.Text;
            pharmaceut.Adress = tbAdress.Text;
            pharmaceut.PostalCode = tbPostalCode.Text;
            pharmaceut.Mobile = tbMobile.Text;
            pharmaceut.Salary = int.Parse(nmSallary.Value.ToString());
            pharmaceut.DateOfHire = DateTime.Parse(dtpHire.Value.ToString());
            pharmaceut.Comment = tbComment.Text;
            
            return pharmaceut;
        }

        private void GetPharmaceutData()
        {
            var _context = _dbAction.GetContext();
            if (pesel != null)
            {
                Text = "Edytowanie danych Pacjenta";
                pharmaceut = _context.Pharmaceuts.FirstOrDefault(x => x.PESEL == pesel);

                if (pharmaceut == null)
                {
                    throw new Exception("Brak użytkownika o podanym Id");
                }

                FillTextBoxes(pharmaceut);
            }
        }

        private void FillTextBoxes(Pharmaceut pharmaceut)
        {

            tbId.Text = pharmaceut.PharmaceutId.ToString();
            tbName.Text = pharmaceut.Name;
            tbSurname.Text = pharmaceut.Surname;
            tbAdress.Text = pharmaceut.Adress;
            tbComment.Text = pharmaceut.Comment;
            tbMobile.Text = pharmaceut.Mobile;
            tbPESEL.Text = pharmaceut.PESEL;
            tbPostalCode.Text = pharmaceut.PostalCode;
            dtpDateOfBirth.Text = pharmaceut.DateOfBirth.ToString();
            dtpHire.Text = pharmaceut.DateOfHire.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (_context)
                {
                   
                    if (!string.IsNullOrEmpty(tbId.Text))
                    {
                        // Aktualizowanie istniejącego farmaceuty
                        int id = int.Parse(tbId.Text);
                        pharmaceut = _context.Pharmaceuts.SingleOrDefault(p => p.PharmaceutId == id);
                        if (pharmaceut != null)
                        {
                            pharmaceut = CreatePharmaceut();
                            _context.Entry(pharmaceut).State = EntityState.Modified;
                            MessageBox.Show("Aktualizowano dane Farmaceuty");
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono Farmaceuty o podanym ID");
                            return;
                        }
                    }
                    else
                    {
                        // Dodawanie nowego farmaceuty
                        pharmaceut = new Pharmaceut();
                        pharmaceut = CreatePharmaceut(pharmaceut);
                        _context.Pharmaceuts.Add(pharmaceut);
                        MessageBox.Show($"Dodano nowego Farmaceutę: ID {pharmaceut.PharmaceutId}, Name {pharmaceut.Name}");
                    }
                    _context.SaveChanges();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania danych: " + ex.Message);
            }
        }
    }
}
