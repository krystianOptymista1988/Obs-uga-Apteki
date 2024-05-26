using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            _dbAction = new DbActions();
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
                dataGridView1.Columns[nameof(Reciept.Medicines)].HeaderText = "Leki";
                dataGridView1.Columns[nameof(Reciept.Medicines)].DisplayIndex = 5;
                dataGridView1.Columns[nameof(Reciept.DoctorFullName)].HeaderText = "Lekarz";
                dataGridView1.Columns[nameof(Reciept.DoctorFullName)].DisplayIndex = 6;
                dataGridView1.Columns[nameof(Reciept.Quantity)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.MedicineReciept)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.AddedMedicines)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.Patient)].Visible = false;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int deleteId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RecieptId"].Value);
                foreach (Reciept item in reciepts.ToList())
                {
                    if (item.RecieptId == deleteId)
                    {
                        reciepts.Remove(item);
                    }
                };
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć Lek do usunięcia.");
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reciepts;
            DGVHeadersSet();
        }
    }
}
