using MySql.Data.MySqlClient;
using Obsługa_Apteki.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Obsługa_Apteki.Entities.AptekaDbContext;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Obsługa_Apteki
{
    public partial class PatientShow : Form
    {
        private AptekaDbContext context;
        private List<Patient> patients = new List<Patient>();
        public PatientShow()
        {
            context = new AptekaDbContext();
            InitializeComponent();
           

            RefreshPatients();
        }

        public void RefreshPatients()
        {
            
            try
            {
                using (var context = new AptekaDbContext()) 
                {
                    patients = context.Patients.ToList();
                    dataGridView1.DataSource = patients;
                }


                if (patients.Any())
                {
                    dataGridView1.DataSource = patients;
                }
                else
                {
                    MessageBox.Show("Brak pacjentów w bazie danych.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Wystąpił błąd podczas odświeżania listy pacjentów: {ex.Message}\nSzczegóły: {ex.InnerException.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Wystąpił błąd podczas odświeżania listy pacjentów: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            DGVHeadersSet();
            ComboboxDataLoad();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            var addEditPatient = new PatientAddEdit();
            addEditPatient.ShowDialog();
            Close();
        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string patientId = (string)dataGridView1.CurrentRow.Cells["PESEL"].Value;
                PatientAddEdit editForm = new PatientAddEdit(patientId, context);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshPatients();
                }
            }
            else
            {
                MessageBox.Show("Wybierz pacjenta do edycji.");
            }
        }
        private void ComboboxDataLoad()
        {
            cbCategory.Items.Clear();
            
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                cbCategory.Items.Add(column.HeaderText);
            }

            if (cbCategory.Items.Count > 0)
            {
                cbCategory.SelectedIndex = 0;
            }
        }
        private void DGVHeadersSet()
        {
            dataGridView1.Columns[nameof(Patient.PatientId)].HeaderText = "ID";
            dataGridView1.Columns[nameof (Patient.PatientId)].DisplayIndex = 0;
            dataGridView1.Columns[nameof(Patient.Name)].HeaderText = "Imię";
            dataGridView1.Columns[nameof(Patient.Name)].DisplayIndex = 1;
            dataGridView1.Columns[nameof(Patient.Surname)].HeaderText = "Nazwisko";
            dataGridView1.Columns[nameof(Patient.Surname)].DisplayIndex = 2;
            dataGridView1.Columns[nameof(Patient.Comment)].HeaderText = "Uwagi";
            dataGridView1.Columns[nameof(Patient.Comment)].DisplayIndex = 8;
            dataGridView1.Columns[nameof(Patient.Adress)].HeaderText = "Adres";
            dataGridView1.Columns[nameof(Patient.DateOfBirth)].HeaderText = "Data Urodzenia";
            dataGridView1.Columns[nameof(Patient.PostalCode)].HeaderText = "Kod Pocztowy";
            dataGridView1.Columns[nameof(Patient.Mobile)].HeaderText = "Telefon";
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int patientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PatientId"].Value);

                var result = MessageBox.Show("Czy na pewno chcesz usunąć tego pacjenta?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (var context = new AptekaDbContext()) 
                    {
                        var patient = context.Patients.FirstOrDefault(p => p.PatientId == patientId);

                        if (patient != null)
                        {
                            context.Patients.Remove(patient);

                            try
                            {
                                context.SaveChanges();
                                MessageBox.Show("Pacjent został usunięty.");

                                RefreshPatients();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Wystąpił błąd podczas usuwania pacjenta: " + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono pacjenta w bazie danych.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć pacjenta do usunięcia.");
            }
        }
    }
}
