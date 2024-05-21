using Obsługa_Apteki.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Obsługa_Apteki
{
    public partial class PatientAddEdit : Form
    {
        public Patient patient = new Patient();
           private AptekaDbContext context;
        public PatientAddEdit()
        {
            InitializeComponent();
            context = new AptekaDbContext();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Close();
            PatientShow patientShowForm = new PatientShow();
            patientShowForm.RefreshPatients();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("klik");
            using (var context = new AptekaDbContext())
            {
                MessageBox.Show("Dodawanie Pacjenta");
                Patient patient = new Patient();
                patient.Name = tbName.Text;
                patient.Surname = tbSurname.Text;
                patient.DateOfBirth = DateTime.Parse(dtpDateOfBirth.Text);
                patient.PESEL = tbPESEL.Text;
                patient.Adress = tbAdress.Text;
                patient.PostalCode = tbPostalCode.Text;
                patient.Mobile = tbMobile.Text;
                patient.Comment = tbComment.Text;

                context.Patients.Add(patient);

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Dodano Pacjenta");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas zapisywania danych: " + ex.Message);
                }

            }
        }

     
    }

}
