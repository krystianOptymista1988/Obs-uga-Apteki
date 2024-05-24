using Obsługa_Apteki.Entities;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            var DeliveryAddEdit = new DeliveryAddEdit();
            

            DeliveryAddEdit.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var DeliveryAddEdit = new DeliveryAddEdit();

            DeliveryAddEdit.ShowDialog();
        }

        private void DGVHeadersSet()
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
}
