using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class RecieptsShow : Form
    {
        private DbActions _dbAction = new DbActions();
        private List<Reciept> reciepts = new List<Reciept>();

        public RecieptsShow()
        {
            InitializeComponent();
            DataLoad();
            DGVHeadersSet();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var RecieptAddEdit = new RecieptAddEdit();
            RecieptAddEdit.ShowDialog();
        }

        private void DataLoad()
        {
            reciepts = _dbAction.GetReciepts();

            if (reciepts == null || reciepts.Count == 0)
            {
                var columnNames = _dbAction.GetColumnNames<Reciept>();
                var dataTable = new DataTable();
                foreach (var columnName in columnNames)
                {
                    dataTable.Columns.Add(columnName);
                }
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                dataGridView1.DataSource = reciepts;
            }
        }

        private void DGVHeadersSet()
        {
            dataGridView1.Columns[nameof(Reciept.RecieptId)].HeaderText = "ID";
            dataGridView1.Columns[nameof(Reciept.RecieptId)].DisplayIndex = 0;
            dataGridView1.Columns[nameof(Reciept.DoctorId)].HeaderText = "Lekarz wystawiający";
            dataGridView1.Columns[nameof(Reciept.DoctorId)].DisplayIndex = 1;
            dataGridView1.Columns[nameof(Reciept.DateOfRegistry)].HeaderText = "Data Wystawienia";
            dataGridView1.Columns[nameof(Reciept.DateOfRegistry)].DisplayIndex = 2;
            dataGridView1.Columns[nameof(Reciept.DateOfExpire)].HeaderText = "Data Wygaśnięcia";
            dataGridView1.Columns[nameof(Reciept.DateOfExpire)].DisplayIndex = 3;
            dataGridView1.Columns[nameof(Reciept.Medicines)].Visible = false;
            dataGridView1.Columns[nameof(Reciept.PatientId)].Visible = false;
            dataGridView1.Columns[nameof(Reciept.Doctor)].Visible = false; ;
            dataGridView1.Columns[nameof(Reciept.Patient)].HeaderText = "Pacjent";
         


        }
    }
}
