using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
            tbSearchValue.KeyDown += tbSearchValue_KeyDown;
        }
       
        private void DataLoad()
        {
            _dbAction = new DbActions();
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
                dataGridView1.ColumnHeadersVisible = false;
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = patients;
                DGVHeadersSet();
            }
        }


        private void btnAddPatient_Click(object sender, EventArgs e)
        {

            var addEditPatient = new PatientAddEdit();
            addEditPatient.ShowDialog();
            DataLoad();
        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string patientId = (string)dataGridView1.CurrentRow.Cells["PESEL"].Value;

                    using (var context = _dbAction.GetContext())
                    {
                        PatientAddEdit editForm = new PatientAddEdit(patientId);

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

        private void DGVHeadersSet()
        {
            if (patients != null && patients.Count > 0)
            {
                dataGridView1.Columns[nameof(Patient.PatientId)].HeaderText = "ID";
                dataGridView1.Columns[nameof(Patient.PatientId)].DisplayIndex = 0;
                dataGridView1.Columns[nameof(Patient.Name)].HeaderText = "Imię";
                dataGridView1.Columns[nameof(Patient.Name)].DisplayIndex = 1;
                dataGridView1.Columns[nameof(Patient.Surname)].HeaderText = "Nazwisko";
                dataGridView1.Columns[nameof(Patient.Surname)].DisplayIndex = 2;
                dataGridView1.Columns[nameof(Patient.Comment)].HeaderText = "Uwagi";
                dataGridView1.Columns[nameof(Patient.Comment)].DisplayIndex = 3;
                dataGridView1.Columns[nameof(Patient.Adress)].HeaderText = "Adres";
                dataGridView1.Columns[nameof(Patient.Adress)].DisplayIndex = 4;
                dataGridView1.Columns[nameof(Patient.DateOfBirth)].HeaderText = "Data Urodzenia";
                dataGridView1.Columns[nameof(Patient.DateOfBirth)].DisplayIndex = 6;
                dataGridView1.Columns[nameof(Patient.PostalCode)].HeaderText = "Kod Pocztowy";
                dataGridView1.Columns[nameof(Patient.PostalCode)].DisplayIndex = 5;
                dataGridView1.Columns[nameof(Patient.Pharmaceut)].Visible = false;
                dataGridView1.Columns[nameof(Patient.Reciepts)].Visible = false;
                dataGridView1.Columns[nameof(Patient.Mobile)].HeaderText = "Telefon";
                dataGridView1.Columns[nameof(Patient.Mobile)].DisplayIndex = 7;
                dataGridView1.Columns[nameof(Patient.PharmaceutId)].Visible = false;
                dataGridView1.Columns[nameof(Patient.FullName)].Visible = false;
            }
        }

        private void btnDeletePatient_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int deleteId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PatientId"].Value);

                var result = MessageBox.Show("Czy na pewno chcesz usunąć tego pacjenta?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Patient itemToRemove = patients.SingleOrDefault(r => r.PatientId == deleteId);
                    if (itemToRemove != null)
                    {
                        _dbAction.RemovePatient(itemToRemove);
                        patients.Remove(itemToRemove);
                        DataLoad();

                    }
                    else
                    {
                        MessageBox.Show("Proszę zaznaczyć pacjenta do usunięcia.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć pacjenta do usunięcia.");
            }

        }
        //Wyszukiwanie pacjenta po wciśnięciu klawisza enter
        private void tbSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearchPatient_Click(sender, e);
            }
        }

        //wyszukiwanie pacjenta po kliknięciu przycisku "wyszukaj"
        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            string searchText = tbSearchValue.Text.Trim();

            if(!string.IsNullOrEmpty(searchText))
            {
                var filteredPatients = patients.Where(p => p.FullName.Contains(searchText)).ToList();

                if(filteredPatients.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = filteredPatients;
                    DGVHeadersSet();
                }
                else
                {
                    MessageBox.Show("Nie znaleziono pacjenta o podanym nazwisku.");
                }
            }
            else
            {
                //jeśli pole wyszukiwania jest puste, wczytuje listę pacjentów jeszcze raz

                DataLoad();
            }
        }
    }
}
