using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Obsługa_Apteki
{
    public partial class Deliveries : Form
    {
        private DbActions _dbAction = new DbActions();
        private List<Delivery> deliveries;
        

        public Deliveries()
        {
            InitializeComponent();
            DataLoad();
            DGVHeadersSet();
            
        }

        private void DataLoad()
        {
            _dbAction = new DbActions();
            deliveries = _dbAction.GetDeliveries();

            if (deliveries == null || deliveries.Count == 0)
            {
                var columnNames = _dbAction.GetColumnNames<Delivery>();
                var dataTable = new DataTable();
                foreach (var columnName in columnNames)
                {
                    dataTable.Columns.Add(columnName);
                }
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                dataGridView1.DataSource = deliveries;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var deliveryAddEdit = new DeliveryAddEdit();
            deliveryAddEdit.ShowDialog();
           DataLoad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var DeliveryAddEdit = new DeliveryAddEdit();

            DeliveryAddEdit.ShowDialog();
           DataLoad();
        }

        private void DGVHeadersSet()
        {
            if (deliveries != null)
            {
                dataGridView1.Columns[nameof(Delivery.DeliveryId)].HeaderText = "ID";
                dataGridView1.Columns[nameof(Delivery.DeliveryId)].DisplayIndex = 0;
                dataGridView1.Columns[nameof(Delivery.DateOfCreate)].HeaderText = "Data zamówienia";
                dataGridView1.Columns[nameof(Delivery.DateOfCreate)].DisplayIndex = 1;
                dataGridView1.Columns[nameof(Delivery.DateOfDelivery)].HeaderText = "Termin Realizacji";
                dataGridView1.Columns[nameof(Delivery.DateOfDelivery)].DisplayIndex = 2;
                dataGridView1.Columns[nameof(Delivery.Value)].HeaderText = "Wartość";
                dataGridView1.Columns[nameof(Delivery.Value)].DisplayIndex = 3;
                dataGridView1.Columns[nameof(Delivery.ExpiredDates)].Visible = false;
                dataGridView1.Columns[nameof(Delivery.OrderedMedicines)].Visible = false;
                dataGridView1.Columns[nameof(Delivery.PharmaceutOrdering)].HeaderText = "Zamawiający";
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int deleteId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DeliveryId"].Value);
                DeleteRowFromDatabase(deleteId);
                Delivery itemToRemove = deliveries.SingleOrDefault(r => r.DeliveryId == deleteId);
                if (itemToRemove != null)
                {
                    deliveries.Remove(itemToRemove);
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = deliveries;
                DGVHeadersSet();
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć receptę do usunięcia.");
            }
        }

        private void DeleteRowFromDatabase(int recieptId)
        {
            string connectionString = "Server=57.128.195.227;Database=aptekaProjekt;User Id=apteka;Password=Projekt123!;";
            string query = "DELETE FROM Deliveries WHERE DeliveryId = @DeliveryId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DeliveryId", recieptId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
