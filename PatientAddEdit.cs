using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;


namespace Obsługa_Apteki
{
    public partial class PatientAddEdit : Form
    {
        private int _patientId;
        private string pesel;
        private DbActions _dbAction;
        private Patient patient;
        private int _pharmaceutId;
        List<Pharmaceut> _pharmaceuts;
        

        public PatientAddEdit(string patientId, AptekaTestDbContext context)
        {
            InitializeComponent();
            LoadComboboxData();
            pesel = patientId;
            GetPatientData();
        }
        public PatientAddEdit()
        {
            InitializeComponent();
            LoadComboboxData();
        }

        private void button2_Click(object sender, EventArgs e)
        {  
                    var _context = _dbAction.GetContext();
            try
            {
                if (!string.IsNullOrEmpty(tbId.Text))
                {
                    // var existingPatient = _context.Patients.SingleOrDefault(p => p.PatientId == patient.PatientId);
                    _context.Patients.Attach(patient);
                    patient = CreatePatient(patient);
                    _context.Entry(patient).State = EntityState.Modified;
                    MessageBox.Show("Aktualizowano dane Pacjenta");
                }
                else
                {
                    patient = new Patient();
                    patient = CreatePatient();
                    _context.Entry(patient);
                    MessageBox.Show(patient.PatientId.ToString() + patient.Name.ToString() );
                    _context.Patients.Add(patient);
                }
                _context.SaveChanges();
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
            PatientShow patientShowForm = new PatientShow();
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
            patient.Pharmaceut = GetPharmaceutFromId(pharmaceutID);
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
            patient.Pharmaceut = GetPharmaceutFromId(pharmaceutID);
            MessageBox.Show(patient.PharmaceutId.ToString());
            
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
    }

}
