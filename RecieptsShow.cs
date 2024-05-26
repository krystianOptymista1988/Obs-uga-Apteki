using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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
            DataLoad();
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
            if (reciepts != null)
            {
                dataGridView1.Columns[nameof(Reciept.RecieptId)].HeaderText = "ID";
                dataGridView1.Columns[nameof(Reciept.RecieptId)].DisplayIndex = 0;
                dataGridView1.Columns[nameof(Reciept.DateOfRegistry)].HeaderText = "Data wydania";
                dataGridView1.Columns[nameof(Reciept.DateOfRegistry)].DisplayIndex = 1;
                dataGridView1.Columns[nameof(Reciept.DateOfExpire)].HeaderText = "Data ważności";
                dataGridView1.Columns[nameof(Reciept.DateOfExpire)].DisplayIndex = 2;
                dataGridView1.Columns[nameof(Reciept.PatientId)].HeaderText = "Pacjent";
                dataGridView1.Columns[nameof(Reciept.PatientId)].DisplayIndex = 3;
                dataGridView1.Columns[nameof(Reciept.AddedMedicines)].HeaderText = "Leki";
                dataGridView1.Columns[nameof(Reciept.AddedMedicines)].DisplayIndex = 5;
                dataGridView1.Columns[nameof(Reciept.DoctorFullName)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.Quantity)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.MedicineReciept)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.Medicines)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.Patient)].Visible = false;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
