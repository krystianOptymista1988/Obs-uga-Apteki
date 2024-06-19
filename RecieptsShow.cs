using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            InitializeDataGridView();
            DataLoad();
            DGVHeadersSet();
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        public void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int selectedRecieptId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["RecieptId"].Value);
                Reciept selectedReciept = reciepts.SingleOrDefault(r => r.RecieptId == selectedRecieptId);

                if(selectedReciept != null)
                {
                    var recieptAddEdit = new RecieptAddEdit(selectedReciept);
                    recieptAddEdit.ShowDialog();
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var recieptAddEdit = new RecieptAddEdit();
            recieptAddEdit.ShowDialog();
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
                dataGridView1.Columns[nameof(Reciept.PatientFullName)].HeaderText = "Pacjent";
                dataGridView1.Columns[nameof(Reciept.PatientFullName)].DisplayIndex = 3;
                dataGridView1.Columns[nameof(Reciept.DoctorFullName)].HeaderText = "Lekarz";
                dataGridView1.Columns[nameof(Reciept.DoctorFullName)].DisplayIndex = 4;
                dataGridView1.Columns[nameof(Reciept.PatientId)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.Medicines)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.Quantity)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.MedicineReciept)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.AddedMedicines)].Visible = false;
                dataGridView1.Columns[nameof(Reciept.Patient)].Visible = false;
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int deleteId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RecieptId"].Value);
                Reciept itemToRemove = reciepts.SingleOrDefault(r => r.RecieptId == deleteId);
                if (itemToRemove != null)
                {
                    _dbAction.RemoveReciept(itemToRemove);
                    reciepts.Remove(itemToRemove);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = reciepts;
                    DGVHeadersSet();
                }

            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć receptę do usunięcia.");
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

        private void btnImplement_Click(object sender, EventArgs e)
        {

        }
    }
}
