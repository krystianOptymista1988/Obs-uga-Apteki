using Obsługa_Apteki.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;


namespace Obsługa_Apteki
{
    public partial class PatientAddEdit : Form
    {
        public int _patientId;
        private string pesel;
        private AptekaTestDbContext _context;
        public Patient patient;
        public int _pharmaceutId;
        List<Pharmaceut> _pharmaceuts;


        public PatientAddEdit(string patientId, AptekaTestDbContext context)
        {
            InitializeComponent();
            _context = context;
            LoadComboboxData();
            pesel = patientId;
            GetPatientData();
        }
        public PatientAddEdit()
        {
            InitializeComponent();
            _context = new AptekaTestDbContext();
            LoadComboboxData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {



                if (tbId.Text != null)
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
                    _context.Patients.Add(patient);
                    MessageBox.Show("Dodano Pacjenta");
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
            patient.Name = tbName.Text;
            patient.Surname = tbSurname.Text;
            patient.DateOfBirth = DateTime.Parse(dtpDateOfBirth.Text);
            patient.PESEL = tbPESEL.Text;
            patient.Adress = tbAdress.Text;
            patient.PostalCode = tbPostalCode.Text;
            patient.Mobile = tbMobile.Text;
            patient.Comment = tbComment.Text;
            patient.PharmaceutId = int.Parse(cbPharmaceut.SelectedValue.ToString());
            return patient;
        }

        private Patient CreatePatient(Patient id)
        {

            patient.Name = tbName.Text;
            patient.Surname = tbSurname.Text;
            patient.DateOfBirth = DateTime.Parse(dtpDateOfBirth.Text);
            patient.PESEL = tbPESEL.Text;
            patient.Adress = tbAdress.Text;
            patient.PostalCode = tbPostalCode.Text;
            patient.Mobile = tbMobile.Text;
            patient.Comment = tbComment.Text;
            patient.PharmaceutId = int.Parse(cbPharmaceut.SelectedValue.ToString());
            id = patient;
            return id;
        }

        private void cbPharmaceut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadComboboxData()
        {
            _pharmaceuts = _context.Pharmaceuts.ToList();
            cbPharmaceut.DataSource = _pharmaceuts;
            cbPharmaceut.DisplayMember = "FullName";
            cbPharmaceut.ValueMember = "PharmaceutId";
        }
    }

}
