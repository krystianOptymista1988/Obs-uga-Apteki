using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class Pharmaceuts : Form
    {
        private DbActions _dbAction = new DbActions();
        private List<Pharmaceut> pharmaceuts;

        public Pharmaceuts()
        {
            InitializeComponent();
            InitializeDataGridView();
            DataLoad();
            DGVHeadersSet();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var PharmaceutAddEdit = new PharmaceutAddEdit();
            PharmaceutAddEdit.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string patientId = (string)dataGridView1.CurrentRow.Cells["PESEL"].Value;
                    using (var _context = _dbAction.GetContext())
                    {
                        PharmaceutAddEdit editForm = new PharmaceutAddEdit(patientId, _context);
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

        private void DataLoad()
        {
            pharmaceuts = _dbAction.GetPharmaceuts();

            if (pharmaceuts == null || pharmaceuts.Count == 0)
            {
                var columnNames = _dbAction.GetColumnNames<Pharmaceut>();
                var dataTable = new DataTable();
                foreach (var columnName in columnNames)
                {
                    dataTable.Columns.Add(columnName);
                }
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                dataGridView1.DataSource = pharmaceuts;
            }
        }
        private void DGVHeadersSet()
        {
            dataGridView1.Columns[nameof(Pharmaceut.FullName)].HeaderText = "Imię i nazwisko";
            dataGridView1.Columns[nameof(Pharmaceut.FullName)].DisplayIndex = 0;
            dataGridView1.Columns[nameof(Pharmaceut.DateOfBirth)].HeaderText = "Data Urodzenia";
            dataGridView1.Columns[nameof(Pharmaceut.DateOfBirth)].DisplayIndex = 4;
            dataGridView1.Columns[nameof(Pharmaceut.PESEL)].HeaderText = "PESEL";
            dataGridView1.Columns[nameof(Pharmaceut.PESEL)].DisplayIndex = 1;
            dataGridView1.Columns[nameof(Pharmaceut.Adress)].HeaderText = "Adress";
            dataGridView1.Columns[nameof(Pharmaceut.Adress)].DisplayIndex = 3;
            dataGridView1.Columns[nameof(Pharmaceut.Name)].Visible = false;
            dataGridView1.Columns[nameof(Pharmaceut.Surname)].Visible = false;
            dataGridView1.Columns[nameof(Pharmaceut.DateOfHire)].HeaderText = "Data zatrudnienia";
            dataGridView1.Columns[nameof(Pharmaceut.PostalCode)].DisplayIndex = 8;
            dataGridView1.Columns[nameof(Pharmaceut.PostalCode)].HeaderText = "Kod Pocztowy";
            dataGridView1.Columns[nameof(Pharmaceut.Mobile)].HeaderText = "Telefon";
            dataGridView1.Columns[nameof(Pharmaceut.PharmaceutId)].Visible = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                int deleteId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PharmaceutId"].Value);

                using(var context = new AptekaTestDbContext())
                {
                    Pharmaceut pharmaceutToRemove = context.Pharmaceuts.Find(deleteId);
                    if(pharmaceutToRemove != null)
                    {
                        var result = MessageBox.Show("Usunięcie tego farmaceuty spowoduje usunięcie powiązań z pacjentami. Czy na pewno chcesz kontynuować?",
                                                     "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if(result == DialogResult.Yes)
                        {
                            var patientsWithPharmaceut = context.Patients.Where(p => p.PharmaceutId == deleteId).ToList();
                            foreach(var patient in patientsWithPharmaceut)
                            {
                                patient.PharmaceutId = null;
                            }

                            context.Pharmaceuts.Remove(pharmaceutToRemove);
                            context.SaveChanges();

                            pharmaceuts = _dbAction.GetPharmaceuts();
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = pharmaceuts;
                            DGVHeadersSet();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Proszę znaleziono farmaceuty.");
                    }
                }

            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć farmaceutę do usunięcia.");
            }
        }

        private void InitializeDataGridView()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.ReadOnly = false;
            dataGridView1.EnableHeadersVisualStyles = true;
            dataGridView1.RowHeadersVisible = true;
        }
    }
}
