using Obsługa_Apteki.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class Pharmaceuts : Form
    {
        private DbActions _dbAction = new DbActions();
        private Pharmaceut _pharmaceut;
        private List<Pharmaceut> pharmaceuts;

        public Pharmaceuts()
        {
            InitializeComponent();
            DataLoad();
            DGVHeadersSet();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var PharmaceutAddEdit = new PharmaceutAddEdit();
            PharmaceutAddEdit.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var PharmaceutAddEdit = new PharmaceutAddEdit();
            PharmaceutAddEdit.ShowDialog();
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
            dataGridView1.Columns[nameof(Pharmaceut.Patients)].Visible = false;
            dataGridView1.Columns[nameof(Pharmaceut.PostalCode)].DisplayIndex = 8;
            dataGridView1.Columns[nameof(Pharmaceut.PostalCode)].HeaderText = "Kod Pocztowy";
            dataGridView1.Columns[nameof(Pharmaceut.Mobile)].HeaderText = "Telefon";
            dataGridView1.Columns[nameof(Pharmaceut.PharmaceutId)].Visible = false;

        }
    }
}
