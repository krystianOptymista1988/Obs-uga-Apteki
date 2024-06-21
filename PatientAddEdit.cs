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

        public PatientAddEdit()
        {
            InitializeComponent();
            LoadComboboxData();
        }
        public PatientAddEdit(string patientId)
        {
            InitializeComponent();
            pesel = patientId;
            LoadComboboxData();
            GetPatientData();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                    if (!string.IsNullOrEmpty(tbId.Text))
                    {
                        int id = int.Parse(tbId.Text);

                        patient = _context.Patients.SingleOrDefault(p => p.PatientId == id);
                        if (patient != null)
                        {
                            patient = CreatePatient();
                            _context.Entry(patient).State = EntityState.Modified;
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
            Close();
        }

        private void GetPatientData()
        {
            if (!string.IsNullOrEmpty(pesel))
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
            patient.Pharmaceut = _context.Pharmaceuts.Find(pharmaceutID);

            return patient;
        }

        private Patient CreatePatient(Patient newPatient)
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
            patient.Pharmaceut = _context.Pharmaceuts.Find(pharmaceutID);
            return newPatient;
        }

        private void LoadComboboxData()
        {
            _pharmaceuts = _dbAction.GetPharmaceuts();
            cbPharmaceut.DataSource = _pharmaceuts;
            cbPharmaceut.DisplayMember = "FullName";
            cbPharmaceut.ValueMember = "PharmaceutId";
        }

    }

}
