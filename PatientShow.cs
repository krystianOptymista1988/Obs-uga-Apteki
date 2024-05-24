using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace Obsługa_Apteki
{
    public partial class PatientShow : Form
    {
        private DbActions _dbAction = new DbActions();
        private List<Patient> patients = new List<Patient>();
        public PatientShow()
        {
            
            InitializeComponent();
            DataLoad();
            DGVHeadersSet();
            ComboboxDataLoad();
        }

        private void DataLoad()
        {
            patients = _dbAction.GetPatients();

            if (patients == null || patients.Count == 0)
            {
                var columnNames = _dbAction.GetColumnNames<Patient>();
                var dataTable = new DataTable();
                foreach (var columnName in columnNames)
                {
                    dataTable.Columns.Add(columnName);
                }
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                dataGridView1.DataSource = patients;
            }
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
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string patientId = (string)dataGridView1.CurrentRow.Cells["PESEL"].Value;
                    using (var _context = _dbAction.GetContext())
                    {
                        PatientAddEdit editForm = new PatientAddEdit(patientId, _context);
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            DataLoad();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wybierz pacjenta do edycji.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas edycji pacjenta: " + ex.Message);
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
            dataGridView1.Columns[nameof(Patient.PatientId)].DisplayIndex = 0;
            dataGridView1.Columns[nameof(Patient.Name)].HeaderText = "Imię";
            dataGridView1.Columns[nameof(Patient.Name)].DisplayIndex = 1;
            dataGridView1.Columns[nameof(Patient.Surname)].HeaderText = "Nazwisko";
            dataGridView1.Columns[nameof(Patient.Surname)].DisplayIndex = 2;
            dataGridView1.Columns[nameof(Patient.Comment)].HeaderText = "Uwagi";
            dataGridView1.Columns[nameof(Patient.Comment)].DisplayIndex = 8;
            dataGridView1.Columns[nameof(Patient.Adress)].HeaderText = "Adres";
            dataGridView1.Columns[nameof(Patient.DateOfBirth)].HeaderText = "Data Urodzenia";
            dataGridView1.Columns[nameof(Patient.PostalCode)].HeaderText = "Kod Pocztowy";
            dataGridView1.Columns[nameof(Patient.Pharmaceut)].HeaderText = "Farmaceuta";
            dataGridView1.Columns[nameof(Patient.RecieptList)].HeaderText = "Recepty";
            dataGridView1.Columns[nameof(Patient.Mobile)].HeaderText = "Telefon";
            dataGridView1.Columns[nameof(Patient.PharmaceutId)].Visible = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int patientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PatientId"].Value);

                var result = MessageBox.Show("Czy na pewno chcesz usunąć tego pacjenta?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (var context = new AptekaTestDbContext())
                    {
                        var patient = context.Patients.FirstOrDefault(p => p.PatientId == patientId);

                        if (patient != null)
                        {
                            context.Patients.Remove(patient);

                            try
                            {
                                context.SaveChanges();
                                MessageBox.Show("Pacjent został usunięty.");

                                DataLoad();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchPatient_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
