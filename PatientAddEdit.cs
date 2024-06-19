using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;


namespace Obsługa_Apteki
{
    public partial class PatientAddEdit : Form
    {
        private string pesel;
        private DbActions _dbAction = new DbActions();
        private AptekaTestDbContext _context = new AptekaTestDbContext();
        private Patient patient;
        List<Pharmaceut> _pharmaceuts;
        

        public PatientAddEdit(string patientId, AptekaTestDbContext context)
        {
            InitializeComponent();
            _context = context;
            pesel = patientId;
            LoadComboboxData();
            GetPatientData();
        }
        public PatientAddEdit()
        {
            InitializeComponent();
            LoadComboboxData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (_context)
                {

                    if (!string.IsNullOrEmpty(tbId.Text))
                    {
                        int id = int.Parse(tbId.Text);
                        patient = _context.Patients.SingleOrDefault(p => p.PatientId == id);
                        if (patient != null)
                        {
                            patient = CreatePatient();
                            _context.Entry(patient).State = EntityState.Modified;
                            _context.SaveChanges();
                            MessageBox.Show("Aktualizowano dane Pacjenta");
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono Pacjenta o podanym ID");
                            return;
                        }
                    }
                    else
                    {
                        patient = new Patient();
                        patient = CreatePatient(patient);
                        _context.Patients.Add(patient);
                        _context.SaveChanges();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetPatientData()
        {
            var _context = _dbAction.GetContext();
            if (pesel != null)
            {
                Text = "Edytowanie danych Pacjenta";
                patient = _context.Patients.FirstOrDefault(x => x.PESEL == pesel);

                if (patient == null)
                {
                    throw new Exception("Brak użytkownika o podanym Id");
                }

                FillTextBoxes(patient);
            }
        }
        private void FillTextBoxes(Patient patient)
        {

            tbId.Text = patient.PatientId.ToString();
            tbName.Text = patient.Name;
            tbSurname.Text = patient.Surname;
            tbAdress.Text = patient.Adress;
            tbComment.Text = patient.Comment;
            tbMobile.Text = patient.Mobile;
            tbPESEL.Text = patient.PESEL;
            tbPostalCode.Text = patient.PostalCode;
            dtpDateOfBirth.Text = patient.DateOfBirth.ToString();

        }

        private Patient CreatePatient()
        {
            int pharmaceutID = int.Parse(cbPharmaceut.SelectedValue.ToString());

            patient.Name = tbName.Text;
            patient.Surname = tbSurname.Text;
            patient.DateOfBirth = DateTime.Parse(dtpDateOfBirth.Text);
            patient.PESEL = tbPESEL.Text;
            patient.Adress = tbAdress.Text;
            patient.PostalCode = tbPostalCode.Text;
            patient.Mobile = tbMobile.Text;
            patient.Comment = tbComment.Text;
            patient.PharmaceutId = int.Parse(cbPharmaceut.SelectedValue.ToString());
            //patient.Pharmaceut = GetPharmaceutFromId(pharmaceutID);
            var selectedPharmaceut = cbPharmaceut.SelectedItem as Patient;

            if (selectedPharmaceut != null)
            {
                patient.Pharmaceut.Surname = selectedPharmaceut.FullName;
            }
            else
            {
                MessageBox.Show("Proszę wybrać farmaceutę.");
                return patient;
            }
                return patient;
        }

        private Patient CreatePatient(Patient patient)
        {
            int pharmaceutID = int.Parse(cbPharmaceut.SelectedValue.ToString());

            patient.Name = tbName.Text;
            patient.Surname = tbSurname.Text;
            patient.DateOfBirth = DateTime.Parse(dtpDateOfBirth.Text);
            patient.PESEL = tbPESEL.Text;
            patient.Adress = tbAdress.Text;
            patient.PostalCode = tbPostalCode.Text;
            patient.Mobile = tbMobile.Text;
            patient.Comment = tbComment.Text;
            patient.PharmaceutId = int.Parse(cbPharmaceut.SelectedValue.ToString());
            //patient.Pharmaceut = GetPharmaceutFromId(pharmaceutID);
            //var selectedPharmaceut = cbPharmaceut.SelectedItem as Pharmaceut;

            //if (selectedPharmaceut != null)
            //{
            //    patient.Pharmaceut.FullName = selectedPharmaceut.FullName;
            //}
            //else
            //{
            //    MessageBox.Show("Proszę wybrać farmaceutę.");
            //    return;
            //}

            return patient;
        }

        private void cbPharmaceut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadComboboxData()
        {
            _pharmaceuts = _dbAction.GetPharmaceuts();
            cbPharmaceut.DataSource = _pharmaceuts;
            cbPharmaceut.DisplayMember = "FullName";
            cbPharmaceut.ValueMember = "PharmaceutId";
        }
        public Pharmaceut GetPharmaceutFromId(int pharmaceutId)
        {
            var _context = _dbAction.GetContext();
            return _context.Pharmaceuts.Find(pharmaceutId);
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbId_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbComment_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
